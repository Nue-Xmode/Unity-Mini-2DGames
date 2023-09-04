using UnityEngine.SceneManagement;
using UnityEngine;

namespace MiniGames.ColorSwitch
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float m_JumpForce = 10f;
        private string m_currentColor;
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
            if (m_currentColor != other.tag && m_spriteRenderer.color != Color.white)
            {
                // SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
                Debug.Log("Game Over");
            }

            m_spriteRenderer.color = other.tag switch
            {
                "Yellow" => Color.yellow,
                "Green" => Color.green,
                "Pink" => Color.magenta,
                "Blue" => Color.blue,

                _ => Color.white,
            };
            
            m_currentColor = other.tag switch
            {
                "Yellow" => "Yellow",
                "Green" => "Green",
                "Pink" => "Pink",
                "Blue" => "Blue",

                _ => "Blue",
            };
        }
    }
}