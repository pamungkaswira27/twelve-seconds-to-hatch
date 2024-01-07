using JSAM;
using StinkySteak.SimulationTimer;
using UnityEngine;

namespace ProjectHatch.Player.Movement.Visual
{
    public class PlayerMovementVisual : MonoBehaviour
    {
        [SerializeField] private Transform _spriteTransform;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private GameObject _vfxDustPrefab;
        [SerializeField] private Transform _positionVfxDust;
        [SerializeField] private SoundFileObject _jumpSfx;
        [SerializeField] private SoundFileObject _dashSfx;
        [SerializeField] private SoundFileObject _landSfx;

        [Header("Dash Trail")]
        [SerializeField] private GameObject _dashTrailPrefab;
        [SerializeField] private float _dashTrailInterval = 0.1f;
        [SerializeField] private float _dashTrailDuration = 0.5f;
        private SimulationTimer _dashTrailIntervalTimer;
        private SimulationTimer _dashTrailDurationTimer;

        private void Start()
        {
            _playerMovement.OnPlayerJustGrounded += PlayDustVFX;
            _playerMovement.OnPlayerJumped += OnPlayerJumped;
            _playerMovement.OnPlayerDashed += OnPlayerDash;
            _playerMovement.OnPlayerWallJumped += OnPlayerJumped;
        }

        private void LateUpdate()
        {
            UpdateDashTrail();
        }

        private void UpdateDashTrail()
        {
            if (!_dashTrailDurationTimer.IsRunning) return;

            if (_dashTrailIntervalTimer.IsExpiredOrNotRunning())
            {
                SpawnTrail();
                _dashTrailIntervalTimer = SimulationTimer.CreateFromSeconds(_dashTrailInterval);
            }

            if (_dashTrailDurationTimer.IsExpired())
            {
                _dashTrailDurationTimer = SimulationTimer.None;
            }
        }

        private void SpawnTrail()
        {
            GameObject go = Instantiate(_dashTrailPrefab, _spriteTransform.position, Quaternion.identity);
            go.transform.localScale = transform.localScale;
            Destroy(go, 2f);
        }

        private void OnPlayerDash()
        {
            AudioManager.PlaySound(_dashSfx);

            _dashTrailDurationTimer = SimulationTimer.CreateFromSeconds(_dashTrailDuration);
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

            AudioManager.PlaySound(_landSfx);
        }
    }
}