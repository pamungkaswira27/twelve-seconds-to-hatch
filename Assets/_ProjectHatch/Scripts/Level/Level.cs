using UnityEngine;

namespace ProjectHatch
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private Transform _initialSpawnPoint;

        private void OnEnable()
        {
            PlayerSpawnManager.Instance.SetInitialSpawnPosition(_initialSpawnPoint.position);
            PlayerSpawnManager.Instance.SpawnPlayer();
        }
    }
}
