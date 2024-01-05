using JSAM;
using UnityEngine;

namespace ProjectHatch.Player.Movement.Visual
{
    public class PlayerMovementVisual : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private GameObject _vfxDustPrefab;
        [SerializeField] private Transform _positionVfxDust;
        [SerializeField] private SoundFileObject _jumpSfx;
        [SerializeField] private SoundFileObject _dashSfx;

        private void Start()
        {
            _playerMovement.OnPlayerJustGrounded += PlayDustVFX;
            _playerMovement.OnPlayerJumped += OnPlayerJumped;
            _playerMovement.OnPlayerDashed += OnPlayerDash;
        }

        private void OnPlayerDash()
        {
            AudioManager.PlaySound(_dashSfx);
        }

        private void OnPlayerJumped()
        {
            PlayDustVFX();
            AudioManager.PlaySound(_jumpSfx);
        }

        private void PlayDustVFX()
        {
            var go = Instantiate(_vfxDustPrefab, _positionVfxDust.position, Quaternion.Euler(-90, 0, 0));
            Destroy(go, 2f);
        }
    }
}