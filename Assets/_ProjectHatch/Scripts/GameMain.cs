using UnityEngine;

namespace ProjectHatch
{
    public static class GameMain
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            InitializeSingleton();
            SpawnGameObject("EventSystem");
            SpawnGameObject("AudioManager");
        }

        private static void InitializeSingleton()
        {
            InputManager.Instance = null;
            LevelManager.Instance = null;
            PlayerManager.Instance = null;
            PlayerSpawnManager.Instance = null;
        }

        private static void SpawnGameObject(string name)
        {
            GameObject go = Resources.Load<GameObject>(name);
            Object.Instantiate(go);
        }
    }
}
