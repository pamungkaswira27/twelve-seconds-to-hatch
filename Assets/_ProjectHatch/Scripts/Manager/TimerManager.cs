using UnityEngine;

namespace ProjectHatch
{
    public class TimerManager : MonoBehaviour
    {
        public static TimerManager Instance;

        [SerializeField]
        private float _gameTime;

        private Timer _timer;

        public float GameTime => _gameTime;

        private void Awake()
        {
            Instance = this;
        }

        public void SetupTimer(Timer timer)
        {
            _timer = timer;
        }

        public void ResetTimer()
        {
            _timer.ResetTimer();
        }

        public void PauseTimer()
        {
            _timer.PauseTimer();
        }
    }
}
