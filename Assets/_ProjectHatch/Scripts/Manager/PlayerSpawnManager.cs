using UnityEngine;

namespace ProjectHatch
{
    public class PlayerSpawnManager : MonoBehaviour
    {
        public static PlayerSpawnManager Instance;

        [SerializeField]
        private GameObject _playerPrefab;

        private GameObject _player;
        private Vector3 _initialSpawnPosition;

        private void Awake()
        {
            Instance = this;
            InstantiatePlayer();
        }

        public Vector3 GetInitialSpawnPosition()
        {
            return _initialSpawnPosition;
        }

        public void SetInitialSpawnPosition(Vector3 position)
        {
            _initialSpawnPosition = position;
        }

        public void SpawnPlayer()
        {
            _player.transform.position = _initialSpawnPosition;
            _player.SetActive(true);
        }

        private void InstantiatePlayer()
        {
            _player = Instantiate(_playerPrefab, _playerPrefab.transform.position, Quaternion.identity, transform);
            _player.SetActive(false);
        }
    }
}
