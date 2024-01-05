using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectHatch.UI.Animation
{
    public class UIAnimationScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _scaleTarget = 1.2f;

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = Vector3.one * _scaleTarget;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = Vector3.one;
        }
    }
}