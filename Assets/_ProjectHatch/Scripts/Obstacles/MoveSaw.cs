using UnityEngine;

namespace ProjectHatch
{
    public class MoveSaw : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private Transform position1;
        [SerializeField]
        private Transform position2;

        private bool turnback;

        private void Update()
        {
            if (Vector2.Distance(transform.position, position1.position) <= 0f)
            {
                turnback = true;
            }

            if (Vector2.Distance(transform.position, position2.position) <= 0f)
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
