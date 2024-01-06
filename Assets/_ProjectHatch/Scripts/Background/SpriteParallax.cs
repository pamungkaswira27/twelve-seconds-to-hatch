using UnityEngine;

namespace ProjectHatch.Background
{
    public class SpriteParallax : MonoBehaviour
    {
        [SerializeField] private float _maxXPos;
        [SerializeField] private float _newXPos;
        [SerializeField] private float _moveSpeed = 3f;

        private void LateUpdate()
        {
            transform.position += Vector3.right * Time.deltaTime * _moveSpeed;

            if(transform.position.x >= _maxXPos)
            {
                transform.position = Vector3.right * _newXPos;
            }
        }
    }
}