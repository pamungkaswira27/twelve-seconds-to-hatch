using UnityEngine;

namespace ProjectHatch.Player.Movement.Visual
{
    public class PlayerTrail : MonoBehaviour
    {
        [SerializeField] private Color _initialColor;
        [SerializeField] private Color _targetColor;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Material _material;
        [SerializeField] private float _blendDuration;

        private Material _instanceMaterial;
        private float _blend;

        private void Start()
        {
            _instanceMaterial = new Material(_material);
            _spriteRenderer.material = _instanceMaterial;
        }

        private void LateUpdate()
        {
            _blend += (1f / _blendDuration) * Time.deltaTime;

            Color color = Color.Lerp(_initialColor, _targetColor, _blend);
            _instanceMaterial.SetColor("_TargetColor", color);

            _spriteRenderer.color = color;

            print(color);
        }
    }
}