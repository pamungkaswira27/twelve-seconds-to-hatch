using UnityEngine;

namespace ProjectHatch
{
    public class Objective : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BasePlayer>(out _))
            {
                LevelManager.Instance.DeactivateCurrentLevel();
                LevelManager.Instance.GetNextLevel();
            }
        }
    }
}
