using StinkySteak.SimulationTimer;
using UnityEngine;

namespace ProjectHatch.UI.Animation
{
    public class UIAnimationScale : MonoBehaviour
    {
        [SerializeField] private float _interval = 0.5f;
        [SerializeField] private float _scaleTarget = 1.2f;
        private bool _flipFlop;

        private SimulationTimer _timerInterval;

        private void LateUpdate()
        {
            if (_timerInterval.IsExpiredOrNotRunning())
            {
                transform.localScale = GetNextScale();
                _timerInterval = SimulationTimer.CreateFromSeconds(_interval);
            }
        }

        private Vector3 GetNextScale()
        {
            _flipFlop = !_flipFlop;
            return _flipFlop ? Vector3.one : Vector3.one * _scaleTarget;
        }
    }
}