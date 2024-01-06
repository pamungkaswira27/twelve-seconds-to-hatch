using UnityEngine;

namespace ProjectHatch
{
    public class PlayerSpawnManager : MonoBehaviour
    {
        public static PlayerSpawnManager Instance;

        [SerializeField]
        private GameObject _playerPrefab;

        private GameObject _player;

        private void Awake()
        {
            Instance = this;
            InstantiatePlayer();
        }

        public void SpawnPlayer(Vector3 spawnPos)
        {
            _player.transform.position = spawnPos;
            _player.SetActive(true);
        }

        private void InstantiatePlayer()
        {
            _player = Instantiate(_playerPrefab, _playerPrefab.transform.position, Quaternion.identity, transform);
            _player.SetActive(false);
        }
    }
}
