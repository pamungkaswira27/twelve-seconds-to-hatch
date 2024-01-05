using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace ProjectHatch.UI.GUI.Game.Transition
{
    public class GUITransition : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform _top;
        [SerializeField] private Transform _bottom;

        [Header("Enter")]
        [SerializeField] private float _enterDuration;
        [SerializeField] private Ease _enterEasing;

        [Header("Exit")]
        [SerializeField] private float _exitDuration;
        [SerializeField] private Ease _exitEasing;

        private Vector3 _scaleOrigin = new Vector3(1, 0, 1);

        [Button]
        private void FullTransition()
        {
            StartTransition();
            DOVirtual.DelayedCall(_enterDuration, ExitTransition);
        }
        [Button]
        private void StartTransition()
        {
            _top.transform.localScale = _scaleOrigin;
            _bottom.transform.localScale = _scaleOrigin;

            _top.DOScale(Vector3.one, _enterDuration).SetEase(_enterEasing);
            _bottom.DOScale(Vector3.one, _enterDuration).SetEase(_enterEasing);
        }
        [Button]
        private void ExitTransition()
        {
            _top.DOScale(_scaleOrigin, _exitDuration).SetEase(_exitEasing);
            _bottom.DOScale(_scaleOrigin, _exitDuration).SetEase(_exitEasing);
        }
    }
}