using UnityEngine;

namespace ProjectHatch
{
    public static class GameMain
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            InitializeSingleton();
        }

        private static void InitializeSingleton()
        {
            InputManager.Instance = null;
            PlayerManager.Instance = null;
        }
    }
}
