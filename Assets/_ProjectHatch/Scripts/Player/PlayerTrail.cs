using UnityEngine;

namespace ProjectHatch.Player.Movement.Visual
{
    public class PlayerTrail : MonoBehaviour
    {
        [SerializeField] private Color _initialColor;
        [SerializeField] private Color _targetColor;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _blendDuration;

        private float _blend;

        private void LateUpdate()
        {
            _blend += (1f / _blendDuration) * Time.deltaTime;

            Color color = Color.Lerp(_initialColor, _targetColor, _blend);

            _spriteRenderer.color = color;

            print(color);
        }
    }
}