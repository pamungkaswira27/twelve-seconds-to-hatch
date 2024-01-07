using UnityEngine;

namespace ProjectHatch
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;

        private PlayerMovement _playerMovement;
        private RespawnPlayer _respawnPlayer;

        public PlayerMovement PlayerMovement => _playerMovement;
        public RespawnPlayer RespawnPlayer => _respawnPlayer;

        private void Awake()
        {
            Instance = this;
        }

        public void SetupPlayer(BasePlayer player)
        {
            _playerMovement = player.GetComponent<PlayerMovement>();
            _respawnPlayer = player.GetComponent<RespawnPlayer>();
        }
    }
}
