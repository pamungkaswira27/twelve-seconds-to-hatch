using UnityEngine;

namespace ProjectHatch
{
    public class PlayerMovement : BasePlayer
    {
        private const int GROUND_CHECK_RESULT_SIZE = 5;

        [SerializeField]
        private Transform _groundCheckTransform;
        [SerializeField]
        private LayerMask _groundLayerMask;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpPower;

        private Rigidbody2D _rigidbody;
        private Collider2D[] _groundCheckResults;
        private float _horizontalInput;
        private bool _isFacingRight = true;
        private float _groundCheckRadius = 0.25f;
        private float _coyoteTime = 0.25f;
        private float _coyoteTimeCounter;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _groundCheckResults = new Collider2D[GROUND_CHECK_RESULT_SIZE];
        }

        private void Update()
        {
            CoyoteTime();
            HandleInput();
            FlipPlayer();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        public void Jump()
        {
            if (_coyoteTimeCounter <= 0f)
            {
                return;
            }

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
        }

        public void ResetCoyoteTime()
        {
            _coyoteTimeCounter = 0f;
        }

        private void HandleInput()
        {
            _horizontalInput = InputManager.Instance.GetMoveInputVector().x;
        }

        private void MovePlayer()
        {
            _rigidbody.velocity = new Vector2(_horizontalInput * Time.deltaTime * _speed, _rigidbody.velocity.y);
        }

        private void FlipPlayer()
        {
            if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
            {
                _isFacingRight = !_isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }

        private void CoyoteTime()
        {
            if (IsGrounded())
            {
                _coyoteTimeCounter = _coyoteTime;
                return;
            }

            _coyoteTimeCounter -= Time.deltaTime;
        }

        private bool IsGrounded()
        {
            int numberOfCollider = Physics2D.OverlapCircleNonAlloc(_groundCheckTransform.position, _groundCheckRadius, _groundCheckResults, _groundLayerMask);

            for (int i = 0; i < numberOfCollider; i++)
            {
                if (_groundCheckResults[i] == null)
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
