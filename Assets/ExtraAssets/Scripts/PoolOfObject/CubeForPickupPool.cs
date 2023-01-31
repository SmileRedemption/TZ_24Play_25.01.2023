using ExtraAssets.Scripts.Stacking;
using UnityEngine;

namespace ExtraAssets.Scripts.PoolOfObject
{
    public class CubeForPickupPool : ObjectsPool<CubeForPickup>
    {
        [SerializeField] private CubeForPickup cubeForPickupTemplate;

        private void Awake()
        {
            Initialize(cubeForPickupTemplate);
        }

        public void GetCube(Transform transformOfCube)
        {
            if (TryGetObject(out CubeForPickup cubeForPickup))
            {
                SetCube(cubeForPickup, transformOfCube);
            }
        }

        private void SetCube(CubeForPickup cubeForPickup, Transform transformOfCube)
        {
            var startTransform = cubeForPickup.transform;
            var halfOffset = startTransform.localScale.y / 2;
            var newPosition = transformOfCube.position + Vector3.up * halfOffset;

            startTransform.parent = transformOfCube;
        
            cubeForPickup.SetPosition(newPosition);
            cubeForPickup.StopStacking();
            cubeForPickup.TurnOn();
        }
    }
}