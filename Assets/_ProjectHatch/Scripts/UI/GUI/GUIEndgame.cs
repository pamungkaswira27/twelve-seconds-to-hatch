using JSAM;
using ProjectHatch.UI.GUI.Game.Transition;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectHatch.UI.GUI.Game.Endgame
{
    public class GUIEndgame : MonoBehaviour
    {
        [SerializeField]
        private Canvas _endGameCanvas;
        [SerializeField]
        private Button _quitButton;
        [SerializeField]
        private SoundFileObject _sFXUIButtonClick;

        private void Start()
        {
            LevelManager.Instance.OnLevelEnd += DisplayEndGameCanvas;
            _quitButton.onClick.AddListener(QuitToMenu);
        }

        private void QuitToMenu()
        {
            StartCoroutine(QuitToMenu_Coroutine());
        }

        private void DisplayEndGameCanvas()
        {
            _endGameCanvas.enabled = true;
        }

        private IEnumerator QuitToMenu_Coroutine()
        {
            AudioManager.PlaySound(_sFXUIButtonClick);
            GUITransition.Instance.PlayEnterTransition();
            yield return new WaitForSeconds(GUITransition.Instance.EnterDuration);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
