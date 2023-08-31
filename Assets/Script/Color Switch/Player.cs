using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.ColorSwitch
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float m_JumpForce = 10f;
        private Rigidbody2D m_RigidBody2D;
        private SpriteRenderer m_spriteRenderer;

        private void Awake()
        {
            m_RigidBody2D = GetComponent<Rigidbody2D>();
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_RigidBody2D.velocity = Vector2.up * m_JumpForce;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            m_spriteRenderer.color = other.tag switch
            {
                "Yellow" => Color.yellow,
                "Green" => Color.green,
                "Pink" => Color.magenta,
                "Blue" => Color.blue,

                _ => Color.white,
            };
        }
    }
}