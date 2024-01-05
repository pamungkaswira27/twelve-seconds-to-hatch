using UnityEngine;

namespace ProjectHatch
{
    public class BasePlayer : MonoBehaviour
    {
        private void Start()
        {
            PlayerManager.Instance.SetupPlayer(this);
        }
    }
}
