using UnityEngine;

namespace ProjectHatch
{
    public class RotateSaw : MonoBehaviour
    {
        public float rotatespeed;

        private void Update()
        {
            transform.Rotate(0, 0, rotatespeed);
        }
    }
}
