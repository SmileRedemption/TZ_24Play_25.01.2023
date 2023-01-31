using UnityEngine;

namespace ExtraAssets.Scripts.UserInput
{
    public class UserInput : MonoBehaviour, IDirectionInput
    {
        private readonly Vector3 _leftDirection = new (-1, 0, 1);
        private readonly Vector3 _rightDirection = new (1, 0, 1);

        public Vector3 Direction { get; private set; } = Vector3.forward;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var mouseDelta = Input.GetAxis("Mouse X");
                Direction = mouseDelta > 0 ? _rightDirection : _leftDirection;
            }
        
            if (Input.GetMouseButtonUp(0))
            {
                Direction = Vector3.forward;
            }
        }
    }
}