using TMPro;
using UnityEngine;

namespace ProjectHatch.UI.GUI.Game
{
    public class GUIGame : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textTimer;

        public TMP_Text TextTimer => _textTimer;
    }
}