using JSAM;
using UnityEngine;

namespace ProjectHatch.Audio.Player
{
    public class AutoMusicPlayer : MonoBehaviour
    {
        [SerializeField] private MusicFileObject _music;

        private void Start()
        {
            AudioManager.PlayMusic(_music, true);
        }
    }
}