using JSAM;
using UnityEngine;

namespace ProjectHatch
{
    public class RespawnPlayer : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _deadVFX;
        [SerializeField]
        private SoundFileObject _deadSFX;
        [SerializeField]
        private float _respawnTime;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacles"))
            {
                Die();
            }
        }

        private void Die ()
        {
            GameObject vfx = Instantiate(_deadVFX.gameObject, transform.position, Quaternion.identity);
            Destroy(vfx, _deadVFX.main.duration);
            AudioManager.PlaySound(_deadSFX);
            InputManager.Instance.PlayerInputAction.Disable();
            gameObject.SetActive(false);

            Invoke(nameof(Respawn), _respawnTime);
        }

        private void Respawn()
        {
            InputManager.Instance.PlayerInputAction.Enable();
            transform.position = PlayerSpawnManager.Instance.GetInitialSpawnPosition();

            if (transform.localScale.x == -1f)
            {
                PlayerManager.Instance.PlayerMovement.FlipSprite();
            }
            
            gameObject.SetActive(true);
        }   
       
    }
}
