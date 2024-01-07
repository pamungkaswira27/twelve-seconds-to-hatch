using UnityEngine;
using StinkySteak.SimulationTimer;
using ProjectHatch.UI.GUI.Game;
using System;

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
                PlayerManager.Instance.RespawnPlayer.Die();
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

            _gUIGame.TextTimer.text = TimeSpan.FromSeconds(timeToDisplay).ToString(@"ss\:ff");
        }
    }
}
