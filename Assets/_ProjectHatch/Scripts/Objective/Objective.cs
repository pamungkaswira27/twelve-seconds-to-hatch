using UnityEngine;

namespace ProjectHatch
{
    public class Objective : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _playerLayerMask;
        [SerializeField]
        private float _checkRadius;

        private Collider2D[] _resultColliders;
        private bool _isTriggered = false;

        private void Start()
        {
            _resultColliders = new Collider2D[1];
        }

        private void Update()
        {
            if (_isTriggered)
            {
                return;
            }

            int numberOfCollider = Physics2D.OverlapCircleNonAlloc(transform.position, _checkRadius, _resultColliders, _playerLayerMask);

            if (numberOfCollider <= 0)
            {
                return;
            }

            if (!_resultColliders[0].TryGetComponent<BasePlayer>(out _))
            {
                return;
            }

            LevelManager.Instance.GetNextLevel();
            _isTriggered = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _checkRadius);
        }
    }
}
