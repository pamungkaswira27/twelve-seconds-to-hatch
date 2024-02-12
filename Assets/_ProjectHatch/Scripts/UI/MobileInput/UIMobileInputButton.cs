using StinkySteak.CustomInput;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectHatch.UI.MobileInput
{
    public class UIMobileInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private CustomInputProviderButton _inputProvider;

        public event Action OnButtonUp;
        public event Action OnButtonDown;

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputProvider.SendValue(0f);
            OnButtonUp?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _inputProvider.SendValue(1f);
            OnButtonDown?.Invoke();
        }
    }
}