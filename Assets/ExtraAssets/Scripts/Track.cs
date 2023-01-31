using System.Linq;
using ExtraAssets.Scripts.PoolOfObject;
using UnityEngine;

namespace ExtraAssets.Scripts
{
    public class Track : MonoBehaviour, ISpawnable
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform[] _cubesForPickupPosition;
    
        private UnityEngine.Camera _camera;
        private CubeForPickupPool _cubesForPickupPool;
    
        public Vector3 SpawnPoint => _spawnPoint.position;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void FixedUpdate()
        {
            if (IsTargetVisible() == false)
            {
                TurnOff();
            }
        }

        private bool IsTargetVisible()
        {
            var planes = GeometryUtility.CalculateFrustumPlanes(_camera);
            var point = SpawnPoint;

            return planes.All(plane => plane.GetDistanceToPoint(point) < 0 == false);
        }
    
        public void Restart()
        {
            foreach (var transformOfCube in _cubesForPickupPosition)
            {
                _cubesForPickupPool.GetCube(transformOfCube);
            }
        }
    
        public void Initialize(CubeForPickupPool cubesForPickupPool) => _cubesForPickupPool = cubesForPickupPool;

        public void TurnOff() => gameObject.SetActive(false);

        public void TurnOn() => gameObject.SetActive(true);
    }
}