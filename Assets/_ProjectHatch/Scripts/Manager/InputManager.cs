using UnityEngine;

namespace ProjectHatch
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        private PlayerInputAction _playerInputAction;

        private void Awake()
        {
            Instance = this;
            _playerInputAction = new PlayerInputAction();
        }

        private void OnEnable()
        {
            _playerInputAction.Enable();

            SubscribeInputEvents();
        }

        private void OnDisable()
        {
            _playerInputAction.Disable();

            UnsubscribeInputEvents();
        }

        public Vector2 GetMoveInputVector()
        {
            Vector2 moveInput = _playerInputAction.Player.Move.ReadValue<Vector2>();
            return moveInput;
        }

        private void SubscribeInputEvents()
        {
            _playerInputAction.Player.Jump.performed += Jump_performed;
            _playerInputAction.Player.Jump.canceled += Jump_canceled;
        }

        private void UnsubscribeInputEvents()
        {
            _playerInputAction.Player.Jump.performed -= Jump_performed;
            _playerInputAction.Player.Jump.canceled -= Jump_canceled;
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            PlayerManager.Instance.PlayerMovement.Jump();
        }

        private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            PlayerManager.Instance.PlayerMovement.ResetCoyoteTime();
        }
    }
}
