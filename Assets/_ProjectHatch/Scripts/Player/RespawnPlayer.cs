using UnityEngine;

namespace ProjectHatch
{
    public class RespawnPlayer : MonoBehaviour
    {
        Vector2 startPosition;

        private void Start()
        {
            startPosition = transform.position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacles"))
            {
                Die();
            }
        }

        void Die ()
        {
            Respawn();
        }

        void Respawn()
        {
            transform.position = startPosition;
        }       
    }
}
