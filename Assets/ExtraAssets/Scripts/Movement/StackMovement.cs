using ExtraAssets.Scripts.UserInput;
using UnityEngine;

namespace ExtraAssets.Scripts.Movement
{
    public class StackMovement : MonoBehaviour
    {
        [SerializeField] private PhysicsMovement _movement;
    
        private IDirectionInput _input;

        private void FixedUpdate()
        {
            _movement.Move(_input.Direction);
        }
    
        public void Initialize(IDirectionInput input) => _input = input;
    }
}