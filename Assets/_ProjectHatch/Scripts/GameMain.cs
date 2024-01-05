using UnityEngine;

namespace ProjectHatch
{
    public static class GameMain
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            InitializeSingleton();
            SpawnGameObject("EventSystem");
        }

        private static void InitializeSingleton()
        {
            InputManager.Instance = null;
            LevelManager.Instance = null;
            PlayerManager.Instance = null;
        }

        private static void SpawnGameObject(string name)
        {
            GameObject go = Resources.Load<GameObject>(name);
            Object.Instantiate(go);
        }
    }
}
