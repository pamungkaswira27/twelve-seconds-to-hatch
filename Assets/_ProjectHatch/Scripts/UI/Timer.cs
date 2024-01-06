using TMPro;
using UnityEngine;
using UnityEngine.UI;
using StinkySteak.SimulationTimer;

namespace ProjectHatch
{
    public class Timer : MonoBehaviour
    {
        //
        public float timerValue = 12;
        public TMP_Text TextTimer;

        public bool GameOn = true;
        public GameObject CanvasLose;

        private SimulationTimer gameTimer;

        private void Start()
        {
            gameTimer = SimulationTimer.CreateFromSeconds(timerValue);
        }


        private void Update()
        {
            if (gameTimer.IsExpired())
            {
                Debug.Log("You Lose");
                CanvasLose.SetActive(true);
                GameOn = false;
            }

            SetText(gameTimer.RemainingSeconds);
        }

        private void SetText(float timeToDisplay)
        {
            int Minutes = Mathf.FloorToInt(timeToDisplay / 60);
            int Seconds = Mathf.FloorToInt(timeToDisplay % 60);
            float MilleSeconds = timeToDisplay % 1 * 99;

            TextTimer.text = string.Format("{0:0}:{1:00}:{2:00}", Minutes, Seconds, MilleSeconds);
        }
    }
}
