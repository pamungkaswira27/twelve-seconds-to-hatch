using UnityEngine;

namespace ProjectHatch
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private Transform _initialSpawnPoint;

        private void OnEnable()
        {
            PlayerSpawnManager.Instance.SpawnPlayer(_initialSpawnPoint.position);
        }
    }
}
