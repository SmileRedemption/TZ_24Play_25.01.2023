using UnityEngine;

namespace ExtraAssets.Scripts.Camera
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        private float _offset;
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            _offset = Vector3.Distance(_playerTransform.position, _transform.position);
        }

        private void Update()
        {
            var newPosition = _transform.position;
            newPosition = new Vector3(newPosition.x, newPosition.y, _playerTransform.position.z - _offset);
            _transform.position = newPosition;
        }
    }
}