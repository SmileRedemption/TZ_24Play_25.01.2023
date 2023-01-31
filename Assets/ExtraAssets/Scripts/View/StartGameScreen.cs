using UnityEngine;

namespace ExtraAssets.Scripts.View
{
    public class StartGameScreen : MonoBehaviour
    {
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}