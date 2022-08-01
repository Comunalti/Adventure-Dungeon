using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Weapons.Ui.Menus
{
    public class PauseResumeButton : MonoBehaviour
    {
        public PauseManager pauseManager;
        public Button button;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonClicked);
            
        }

        private void OnButtonClicked()
        {
            pauseManager.UnPause();
        }
    }
}