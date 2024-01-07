using System;
using System.Collections;
using UnityEngine;

namespace ProjectHatch
{
    public class PlayerMovement : BasePlayer
    {
        private const int CHECK_RESULT_SIZE = 5;

        [Header("Movement")]
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpPower;

        [Header("Dash")]
        [SerializeField]
        private float _dashPower;

        [Header("Ground Check")]
        [SerializeField]
        private Transform _groundCheckTransform;
        [SerializeField]
        private LayerMask _groundLayerMask;
        [SerializeField] private float _checkRadius = 0.25f;

        [Header("Wall Check")]
        [SerializeField]
        private float _wallSlidingSpeed;
        [SerializeField]
        private Transform _wallCheckTransform;
        [SerializeField]
        private LayerMask _wallLayerMask;

        private Rigidbody2D _rigidbody;
        private Collider2D[] _groundCheckResults;
        private Collider2D[] _wallCheckResults;

        private float _horizontalInput;
        private float _originalGravity;
        private bool _isFacingRight = true;
        private bool _isGrounded;

        // Coyote Time Properties
        private float _coyoteTime = 0.25f;
        private float _coyoteTimeCounter;

        // Wall Jump Properties
        private bool _isWallSliding;
        private bool _isWallJumping;
        private float _wallJumpingDirection;
        private float _wallJumpingTime = 0.25f;
        private float _wallJumpingCounter;
        private float _wallJumpingDuration = 0.5f;
        private Vector2 _wallJumpingPower;

        // Dash
        private bool _canDash = true;
        private bool _isDashing;
        private float _dashingTime = 0.2f;
        private float _dashingCooldown = 1f;
        private Coroutine _dashCoroutine;

        public event Action OnPlayerJustGrounded;
        public event Action OnPlayerJumped;
        public event Action OnPlayerWallJumped;
        public event Action OnPlayerWallSlide;
        public event Action OnPlayerDashed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _groundCheckResults = new Collider2D[CHECK_RESULT_SIZE];
            _wallCheckResults = new Collider2D[CHECK_RESULT_SIZE];

            _wallJumpingPower = new Vector2(_speed * (1 / 60f), _jumpPower);
            _originalGravity = _rigidbody.gravityScale;
        }

        private void Update()
        {
            UpdateIsGrounded();

            if (_isDashing)
            {
                return;
            }

            CoyoteTime();
            HandleInput();
            WallSlide();
            WallJump();
            FlipPlayer();
        }

        private void OnDisable()
        {
            if (_dashCoroutine != null)
            {
                StopCoroutine(_dashCoroutine);
                _rigidbody.gravityScale = _originalGravity;
                _isDashing = false;
                _canDash = true;
            }
        }

        private void UpdateIsGrounded()
        {
            bool previousIsGroundedValue = _isGrounded;
            _isGrounded = GetIsGrounded();

            if (_isGrounded != previousIsGroundedValue)
                OnIsGroundedChanged();
        }

        private void OnIsGroundedChanged()
        {
            if (_isGrounded)
                OnPlayerJustGrounded?.Invoke();
        }

        private void OnIsWallJumpingChanged()
        {
            if (_isWallSliding)
                OnPlayerWallJumped?.Invoke();
        }

        private void OnIsWallSlideChanged()
        {
            if (_isWallSliding)
                OnPlayerWallSlide?.Invoke();
        }

        private void FixedUpdate()
        {
            if (_isDashing)
            {
                return;
            }

            MovePlayer();
        }

        public void Jump()
        {
            if (_isDashing)
            {
                return;
            }

            if (_coyoteTimeCounter <= 0f)
            {
                return;
            }

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
            OnPlayerJumped?.Invoke();
        }

        public void ResetCoyoteTime()
        {
            _coyoteTimeCounter = 0f;
        }

        public void Dash()
        {
            if (!_canDash)
            {
                return;
            }

            _dashCoroutine = StartCoroutine(Dash_Coroutine());
        }

        public void FlipSprite()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        private void HandleInput()
        {
            if (_isWallJumping)
            {
                return;
            }

            _horizontalInput = InputManager.Instance.GetMoveInputVector().x;
        }

        private void MovePlayer()
        {
            if (_isWallJumping)
            {
                return;
            }

            _rigidbody.velocity = new Vector2(_horizontalInput * _speed * Time.deltaTime, _rigidbody.velocity.y);
        }

        private void FlipPlayer()
        {
            if (_isWallJumping)
            {
                return;
            }

            if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
            {
                FlipSprite();
            }
        }

        private void CoyoteTime()
        {
            if (!_isGrounded)
            {
                _coyoteTimeCounter -= Time.deltaTime;
                return;
            }

            _coyoteTimeCounter = _coyoteTime;
        }

        private void WallSlide()
        {
            bool previousIsWallSliding = _isWallJumping;

            if (IsWalled() && !_isGrounded && _horizontalInput != 0f)
            {
                _isWallSliding = true;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Clamp(_rigidbody.velocity.y, -_wallSlidingSpeed, float.MaxValue));
            }
            else
            {
                _isWallSliding = false;
            }

            if (_isWallSliding != previousIsWallSliding)
                OnIsWallSlideChanged();
        }

        private void WallJump()
        {
            bool previousWallJumping = _isWallJumping;

            if (_isWallSliding)
            {
                _isWallJumping = false;
                _wallJumpingDirection = -transform.localScale.x;
                _wallJumpingCounter = _wallJumpingTime;

                CancelInvoke(nameof(StopWallJumping));
            }
            else
            {
                _wallJumpingCounter -= Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space) && _wallJumpingCounter > 0f)
            {
                _isWallJumping = true;
                _rigidbody.velocity = new Vector2(_wallJumpingDirection * _wallJumpingPower.x, _wallJumpingPower.y);
                _wallJumpingCounter = 0f;

                if (transform.localScale.x != _wallJumpingDirection)
                {
                    FlipSprite();
                }

                Invoke(nameof(StopWallJumping), _wallJumpingDuration);
            }

            if (_isWallJumping != previousWallJumping)
                OnIsWallJumpingChanged();
        }

        private void StopWallJumping()
        {
            _isWallJumping = false;
        }

        private IEnumerator Dash_Coroutine()
        {
            _canDash = false;
            _isDashing = true;
            _rigidbody.gravityScale = 0f;
            _rigidbody.velocity = new Vector2(transform.localScale.x * _dashPower, 0f);
            OnPlayerDashed?.Invoke();

            yield return new WaitForSeconds(_dashingTime);

            _rigidbody.gravityScale = _originalGravity;
            _isDashing = false;

            yield return new WaitForSeconds(_dashingCooldown);

            _canDash = true;
        }

        private bool GetIsGrounded()
        {
            int numberOfCollider = Physics2D.OverlapCircleNonAlloc(_groundCheckTransform.position, _checkRadius, _groundCheckResults, _groundLayerMask);

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

        private bool IsWalled()
        {
            int numberOfCollider = Physics2D.OverlapCircleNonAlloc(_wallCheckTransform.position, _checkRadius, _wallCheckResults, _wallLayerMask);

            for (int i = 0; i < numberOfCollider; i++)
            {
                if (_wallCheckResults[i] == null)
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
