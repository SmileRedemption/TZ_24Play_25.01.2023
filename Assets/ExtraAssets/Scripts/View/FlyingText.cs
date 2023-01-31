using System.Collections;
using UnityEngine;

namespace ExtraAssets.Scripts.View
{
    [RequireComponent(typeof(Animator))]
    public class FlyingText : MonoBehaviour
    {
        [SerializeField] private float _timeOfEnable;

        public void StartMoving()
        {
            gameObject.SetActive(true);
            StartCoroutine(Flying());
        }

        private IEnumerator Flying()
        {
            yield return new WaitForSeconds(_timeOfEnable);
            gameObject.SetActive(false);
        }
    }
}