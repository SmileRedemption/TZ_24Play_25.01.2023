using System;
using UnityEngine;

namespace ExtraAssets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsMovement : MonoBehaviour
    {
        [SerializeField] private Surface surface;
        [SerializeField] private float _speed;
    
        private Rigidbody _rigidbody;
        private float _xPositionMax;
        private float _xPositionMin;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _xPositionMin = surface.LeftLimitX.x;
            _xPositionMax = surface.RightLimitX.x;
        }
    
        public void Move(Vector3 direction)
        {
            var directionAlongSurface = surface.Project(direction.normalized);
            var offset = directionAlongSurface.normalized * _speed * Time.fixedDeltaTime;
            var newPosition = _rigidbody.position + offset;
            
            newPosition = new Vector3(Math.Clamp(newPosition.x, _xPositionMin, _xPositionMax), newPosition.y, newPosition.z);
        
            _rigidbody.MovePosition(newPosition);
        }
    }
}