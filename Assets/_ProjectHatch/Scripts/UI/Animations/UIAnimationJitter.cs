using NaughtyAttributes;
using StinkySteak.SimulationTimer;
using UnityEngine;

namespace ProjectHatch.UI.Animation
{
    public class UIAnimationJitter : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction = Vector3.up;
        [SerializeField] private float _interval;
        [SerializeField] private float _distance = 1f;
        [SerializeField][ReadOnly] private Vector3 _initialPosition;
        private bool _flipFlop;

        private SimulationTimer _timerInterval;

        private void LateUpdate()
        {
            if (_timerInterval.IsExpiredOrNotRunning())
            {
                transform.position = GetNextPosition();
                _timerInterval = SimulationTimer.CreateFromSeconds(_interval);
            }
        }

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private Vector3 GetNextPosition()
        {
            _flipFlop = !_flipFlop;
            return _flipFlop ? _initialPosition : _initialPosition + (_direction * _distance);
        }
    }
}