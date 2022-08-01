using System;
using UnityEngine;
using UnityEngine.UI;

namespace Weapons.Ui.Menus
{
    public class QuitGameButton : MonoBehaviour
    {
        public Button button;

        private void Start()
        {
            
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            Application.Quit();
        }
    }
}