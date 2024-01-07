using UnityEngine;

namespace ProjectHatch
{
    public class MonoPersistence : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
