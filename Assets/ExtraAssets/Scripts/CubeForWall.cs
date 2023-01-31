using ExtraAssets.Scripts.Stacking;
using UnityEngine;

namespace ExtraAssets.Scripts
{
    public class CubeForWall : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out CubeForPickup cubeForPickup))
            {
                cubeForPickup.CollideWithWall();
                Vibration.Vibration.StartVibration();
            }
        }
    }
}