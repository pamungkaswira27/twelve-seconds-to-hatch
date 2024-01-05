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

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Initialize();
            GetNextLevel();
        }

        public void GetNextLevel()
        {
            Level level = _levelQueue.Dequeue();
            level.gameObject.SetActive(true);
            level.transform.position = Vector2.zero;
            _currentLevelPrefab = level;
            _levelQueue.Enqueue(level);
        }

        public void DeactivateCurrentLevel()
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
