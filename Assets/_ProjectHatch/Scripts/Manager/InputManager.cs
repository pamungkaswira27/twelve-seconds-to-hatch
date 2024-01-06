using UnityEngine;

namespace ProjectHatch
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        private PlayerInputAction _playerInputAction;

        public PlayerInputAction PlayerInputAction => _playerInputAction;

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

        public bool IsJumpButtonPressed()
        {
            return _playerInputAction.Player.Jump.IsPressed(); ;
        }

        public bool IsInputPerformed()
        {
            bool isMovePerformed = _playerInputAction.Player.Move.IsPressed();
            bool isJumpPerformed = _playerInputAction.Player.Jump.IsPressed();
            bool isDashPerformed = _playerInputAction.Player.Dash.IsPressed();

            return isMovePerformed || isJumpPerformed || isDashPerformed;
        }

        private void SubscribeInputEvents()
        {
            _playerInputAction.Player.Jump.performed += Jump_performed;
            _playerInputAction.Player.Jump.canceled += Jump_canceled;
            _playerInputAction.Player.Dash.performed += Dash_performed;
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

        private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            PlayerManager.Instance.PlayerMovement.Dash();
        }
    }
}
