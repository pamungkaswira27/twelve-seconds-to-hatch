using System.Collections.Generic;
using UnityEngine;

namespace ProjectHatch
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        [SerializeField]
        private Level[] _levelPrefabs;

        private Queue<Level> _levelQueue;
        private Level _currentLevelPrefab;
        private int _currentLevelIndex = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Initialize();
            SpawnNextLevel();
        }

        public void GetNextLevel()
        {
            if (_currentLevelIndex >= _levelQueue.Count)
            {
                Debug.Log($"[{nameof(LevelManager)}]: You've finished all levels!");
                return;
            }

            DeactivateCurrentLevel();
            SpawnNextLevel();
        }

        private void SpawnNextLevel()
        {
            Level level = _levelQueue.Dequeue();
            level.gameObject.SetActive(true);
            level.transform.position = Vector2.zero;
            _currentLevelPrefab = level;
            _levelQueue.Enqueue(level);
            _currentLevelIndex++;
        }

        private void DeactivateCurrentLevel()
        {
            _currentLevelPrefab.gameObject.SetActive(false);
            _currentLevelPrefab = null;
        }

        private void Initialize()
        {
            _levelQueue = new Queue<Level>();

            for (int i = 0;  i < _levelPrefabs.Length; i++)
            {
                Level level = Instantiate(_levelPrefabs[i], transform);
                level.gameObject.SetActive(false);
                _levelQueue.Enqueue(level);
            }
        }
    }
}
