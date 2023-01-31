using System.Collections;
using ExtraAssets.Scripts.PoolOfObject;
using UnityEngine;

namespace ExtraAssets.Scripts.Stacking
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubeForPickup : MonoBehaviour, ISpawnable
    {
        private Rigidbody _rigidbody;
    
        public Vector3 Position => transform.position;
        public bool IsStacking { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void StartMoving(Transform transformForFollowing)
        {
            transform.parent = transformForFollowing;
            StartStacking();
        }

        public void StartStacking()
        {
            IsStacking = true;
            StopKinematic();
        }

        public void StopStacking()
        {
            IsStacking = false;
            StarKinematic();
        }

        public void CollideWithWall()
        {
            transform.parent = null;
            StartCoroutine(DelayToTurnOff());
        }

        private IEnumerator DelayToTurnOff()
        {
            var timeDelay = 0.5f;
            yield return new WaitForSeconds(timeDelay);
            TurnOff();
        }

        public void StarKinematic() => _rigidbody.isKinematic = true;

        private void StopKinematic() => _rigidbody.isKinematic = false;

        public void SetPosition(Vector3 position) => transform.position = position;

        public void TurnOff() => gameObject.SetActive(false);

        public void TurnOn() => gameObject.SetActive(true);
    }
}