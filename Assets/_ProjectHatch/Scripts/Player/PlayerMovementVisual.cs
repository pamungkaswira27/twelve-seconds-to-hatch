using UnityEngine;

namespace ProjectHatch.Player.Movement.Visual
{
    public class PlayerMovementVisual : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private GameObject _vfxDustPrefab;
        [SerializeField] private Transform _positionVfxDust;

        private void Start()
        {
            _playerMovement.OnPlayerJustGrounded += OnPlayerIsGrounded;
        }

        private void OnPlayerIsGrounded()
        {
            var go = Instantiate(_vfxDustPrefab, _positionVfxDust.position, Quaternion.Euler(-90, 0, 0));
            Destroy(go, 2f);
        }
    }
}