using UnityEngine;
using UnityEngine.UI;

namespace ProjectHatch.UI.MobileInput
{
    public class UIMobileInputButtonVisual : MonoBehaviour
    {
        [SerializeField] private UIMobileInputButton _button;
        [SerializeField] private float _scaleOnPressed = 1.2f;
        [SerializeField] private Image _image;
        [SerializeField] private Color _colorDefault = Color.white;
        [SerializeField] private Color _colorPressed = Color.white;

        private void Start()
        {
            SubscribeEvents();
        }

        private void OnButtonDown()
        {
            _image.color = _colorPressed;
            transform.localScale = Vector2.one * _scaleOnPressed;
        }
        private void OnButtonUp()
        {
            _image.color = _colorDefault;
            transform.localScale = Vector2.one;
        }

        private void SubscribeEvents()
        {
            _button.OnButtonDown += OnButtonDown;
            _button.OnButtonUp += OnButtonUp;
        }
    }
}

