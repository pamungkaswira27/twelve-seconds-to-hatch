using UnityEngine;

namespace ProjectHatch
{
    public class MoveSaw : MonoBehaviour
    {
        public float speed;
        public Transform position1;
        public Transform position2;
        bool turnback;

        private void Start()
        {

        }

        private void Update()
        {
            if (transform.position.y >= position1.position.y)
            {
                turnback = true;
            }

            if (transform.position.y <= position2.position.y)
            {
                turnback = false;
            }

            if (turnback)
            {
                transform.position = Vector2.MoveTowards(transform.position, position2.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, position1.position, speed * Time.deltaTime);
            }
        }
    }
}
