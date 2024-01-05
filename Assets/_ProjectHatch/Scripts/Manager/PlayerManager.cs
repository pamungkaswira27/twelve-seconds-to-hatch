using UnityEngine;

namespace ProjectHatch
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        private PlayerMovement _playerMovement;

        public PlayerMovement PlayerMovement => _playerMovement;

        private void Awake()
        {
            Instance = this;
        }

        public void SetupPlayer(BasePlayer player)
        {
            _playerMovement = player.GetComponent<PlayerMovement>();
        }
    }
}
