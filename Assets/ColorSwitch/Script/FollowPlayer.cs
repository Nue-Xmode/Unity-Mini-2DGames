using UnityEngine;

namespace MiniGames.ColorSwitch
{
    public class FollowPlayer : MonoBehaviour
    {
        public Transform player;

        void Update()
        {
            if (transform.position.y < player.transform.position.y)
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}