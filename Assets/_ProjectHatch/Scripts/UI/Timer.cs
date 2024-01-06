using UnityEngine;
using StinkySteak.SimulationTimer;
using ProjectHatch.UI.GUI.Game;

namespace ProjectHatch
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private GUIGame _gUIGame;

        private PauseableSimulationTimer _gameTimer;

        private void Start()
        {
            TimerManager.Instance.SetupTimer(this);
        }

        private void Update()
        {
            if (InputManager.Instance.IsInputPerformed() && !_gameTimer.IsRunning)
            {
                _gameTimer = PauseableSimulationTimer.CreateFromSeconds(TimerManager.Instance.GameTime);
            }

            if (_gameTimer.IsExpired())
            {
                Debug.Log("Lose");
            }

            SetText(_gameTimer.RemainingSeconds);
        }

        public void ResetTimer()
        {
            _gameTimer = PauseableSimulationTimer.None;
        }

        public void PauseTimer()
        {
            _gameTimer.Pause();
        }

        private void SetText(float timeToDisplay)
        {
            if (timeToDisplay <= 0)
            {
                _gUIGame.TextTimer.text = "12:00";
                return;
            }

            int Minutes = Mathf.FloorToInt(timeToDisplay / 60);
            int Seconds = Mathf.FloorToInt(timeToDisplay % 60);
            float MilleSeconds = timeToDisplay % 1 * 99;

            _gUIGame.TextTimer.text = string.Format("{1:00}:{2:00}", Minutes, Seconds, MilleSeconds);
        }
    }
}
