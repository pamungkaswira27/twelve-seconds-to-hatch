using JSAM;
using ProjectHatch.UI.GUI.Game.Transition;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectHatch.UI.GUI.Game.Menu
{
    public class GUIMenu : MonoBehaviour
    {
        [SerializeField] private Button _buttonPlay;
        [SerializeField] private SoundFileObject _sfxUIButtonClick;

        private void Start()
        {
            GUITransition.Instance.PlayExitTransition();
            _buttonPlay.onClick.AddListener(PlayGame);
        }

        private void PlayGame()
        {
            StartCoroutine(PlayGame_Coroutine());
        }

        private IEnumerator PlayGame_Coroutine()
        {
            AudioManager.PlaySound(_sfxUIButtonClick);
            GUITransition.Instance.PlayEnterTransition();
            yield return new WaitForSeconds(GUITransition.Instance.EnterDuration);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
