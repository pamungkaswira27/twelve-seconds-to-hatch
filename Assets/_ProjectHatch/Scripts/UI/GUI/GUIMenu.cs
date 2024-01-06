using ProjectHatch.UI.GUI.Game.Transition;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectHatch.UI.GUI.Game.Menu
{
    public class GUIMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            StartCoroutine(PlayGame_Coroutine());
        }

        private IEnumerator PlayGame_Coroutine()
        {
            GUITransition.Instance.PlayEnterTransition();
            yield return new WaitForSeconds(GUITransition.Instance.EnterDuration);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
