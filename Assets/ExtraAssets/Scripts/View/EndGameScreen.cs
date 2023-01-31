using System;
using UnityEngine;
using UnityEngine.UI;

namespace ExtraAssets.Scripts.View
{
    public class EndGameScreen : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        public void Show(Action onReloadClick)
        {
            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(() => onReloadClick());

            gameObject.SetActive(true);
        }
    }
}
