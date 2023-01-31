using System;
using System.Collections;
using ExtraAssets.Scripts.Movement;
using ExtraAssets.Scripts.Stacking;
using UnityEngine;

namespace ExtraAssets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private StackOfCube _stackOfCube;
        
        public event Action CollidedWithSurface;
        public event Action CollidedWithRedCube;

        private void OnEnable()
        {
            _stackOfCube.CubeAdded += OnCubeAdded;
        }

        private void OnDisable()
        {
            _stackOfCube.CubeAdded -= OnCubeAdded;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Surface _))
            {
                CollidedWithSurface?.Invoke();
            }

            if (collision.gameObject.TryGetComponent(out CubeForWall _))
            {
                CollidedWithRedCube?.Invoke();
            }
        }
        
        private void OnCubeAdded(Vector3 position, float offset) => transform.position = new Vector3(position.x, position.y + offset / 2, position.z);
    }
}