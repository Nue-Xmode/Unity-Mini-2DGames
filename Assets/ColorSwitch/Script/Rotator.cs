using UnityEngine;

namespace MiniGames.ColorSwitch
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 100f;
        
        private void Update()
        {
            transform.Rotate(0f, 0f, m_Speed * Time.deltaTime);
        }
    }
}