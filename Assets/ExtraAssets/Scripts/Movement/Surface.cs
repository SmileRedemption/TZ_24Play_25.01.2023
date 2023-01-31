using ExtraAssets.Scripts.Stacking;
using UnityEngine;

namespace ExtraAssets.Scripts.Movement
{
    public class Surface : MonoBehaviour
    {
        [SerializeField] private Transform _leftLimitX;
        [SerializeField] private Transform _rightLimitX;

        private Vector3 _normal;

        public Vector3 LeftLimitX => _leftLimitX.position;
        public Vector3 RightLimitX => _rightLimitX.position;
    
        private void OnCollisionEnter(Collision collision)
        {
            _normal = collision.contacts[0].normal;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CubeForPickup yellowCube))
            {
                if (yellowCube.IsStacking == false)
                {
                    yellowCube.StarKinematic();
                }
            }
        }
    
        public Vector3 Project(Vector3 direction) => direction - Vector3.Dot(direction, _normal) * _normal;
    }
}
