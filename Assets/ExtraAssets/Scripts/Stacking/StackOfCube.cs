using System;
using UnityEngine;

namespace ExtraAssets.Scripts.Stacking
{
    public class StackOfCube : MonoBehaviour
    {
        [SerializeField] private CubeForPickup firstCubeForPickup;

        private CubeForPickup _previouslyCubeForPickup;
        private Vector3 _nextPositionOfCube;
        private float _offsetByY;

        public event Action<Vector3, float> CubeAdded;

        private void Start()
        {
            _offsetByY = firstCubeForPickup.transform.localScale.y;
            _previouslyCubeForPickup = firstCubeForPickup;
            firstCubeForPickup.StartStacking();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CubeForPickup cube))
            {
                if (cube.IsStacking)
                    return;
            
                _nextPositionOfCube = new Vector3(_previouslyCubeForPickup.Position.x, _previouslyCubeForPickup.Position.y + _offsetByY, _previouslyCubeForPickup.Position.z);
                cube.SetPosition(_nextPositionOfCube);
                cube.StartMoving(transform);
                _previouslyCubeForPickup = cube;
            
                CubeAdded?.Invoke(cube.Position, _offsetByY);
            }
        }
    }
}