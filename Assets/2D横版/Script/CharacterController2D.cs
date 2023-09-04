using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGames.Roller
{
    /// <summary>
    /// 2D角色控制器
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float m_NormalSpeed;   //正常速度
        [SerializeField] private float m_DashSpeed; //冲刺速度
        [SerializeField] private float m_CrouchSpeed;   //蹲下时速度
        [SerializeField] private float m_JumpForce; //跳跃时的力

        [SerializeField] private float m_MovementSmoothing = .04f;  //移动平滑度

        [SerializeField] private Transform m_GroundCheck;   //地面检测圆心
        [SerializeField] private float m_GroundCheckRadius = .5f;   //地面检测半径
        [SerializeField] private Transform m_CeilingCheck;  //天花板检测圆心
        [SerializeField] private float m_CeilingCheckRadius = .5f;  //天花板检测半径

        [SerializeField] private bool m_AirControl; //跳跃时是否能操控
        [SerializeField] private LayerMask m_WhatIsGround;  //地面的layer
        [SerializeField] private Collider2D m_CrouchDisableCollider;    //蹲下时会取消的碰撞体

        private Rigidbody2D m_RigidBody2D;
        private bool m_Grounded = true;    //玩家是否在地面上
        private bool m_wasCrouching;    //玩家是否蹲下
        private Vector3 m_Velocity;

        [Header("行动触发事件")]
        [Space(10)]
        public UnityEvent OnLandEvent;  //着陆时触发的事件

        [Serializable]
        public class BoolEvent : UnityEvent<bool> { }

        public BoolEvent OnCrouchEvent; //下蹲时触发的事件

        private void Awake()
        {
            m_RigidBody2D = GetComponent<Rigidbody2D>();

            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();
            if (OnCrouchEvent == null)
                OnCrouchEvent = new BoolEvent();

        }

        /// <summary>
        /// 地面检测
        /// </summary>
        private void FixedUpdate()
        {
            //使用临时变量wasGrounded来记录地面检测的变化情况，正常移动时wasGrounded总为true,
            //跳跃并着陆时会触发一次变化而呼叫对应事件
            //若想让玩家在开始时触发一次落地，将m_Grounded的初始值置为false即可
            bool wasGrounded = m_Grounded;
            m_Grounded = false;
            
            //每一个检测到的碰撞体都会触发一次落地事件
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, m_GroundCheckRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
        }

        public void Move(Vector2 dir, float move, bool crouch, bool jump)
        {
            //玩家取消下蹲时需要检测周围是否有阻止起身的物体，如果有，保持下蹲
            if (!crouch)
            {
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, m_CeilingCheckRadius, m_WhatIsGround))
                    crouch = true;
            }

            //检查玩家是否处于可操控状态
            if (m_Grounded || m_AirControl)
            {
                //下蹲的判断
                if (crouch)
                {
                    if (!m_wasCrouching)
                    {
                        m_wasCrouching = true;
                        OnCrouchEvent.Invoke(true);
                    }

                    //进行减速
                    move = m_CrouchSpeed;

                    //取消对应碰撞体
                    if (m_CrouchDisableCollider != null)
                        m_CrouchDisableCollider.enabled = false;
                }
            }else
            {
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }

                //恢复原速
                move = m_NormalSpeed;
            }

            //移动角色
            Vector3 targetVelocity = new Vector2(dir.x * move * Time.deltaTime, m_RigidBody2D.velocity.y);
            //增加平滑
            m_RigidBody2D.velocity = Vector3.SmoothDamp(m_RigidBody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            //检测面向
            if (Mathf.Sign(transform.localScale.x) != Mathf.Sign(dir.x))
                Flip();

            //玩家按下跳跃
            if (m_Grounded && jump)
            {
                //增加力
                m_Grounded = false;
                m_RigidBody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }

        /// <summary>
        /// 玩家转向
        /// </summary>
        private void Flip()
        {
            Vector3 theScale = transform.localScale * -1;
            transform.localScale = theScale;
        }
    }
}