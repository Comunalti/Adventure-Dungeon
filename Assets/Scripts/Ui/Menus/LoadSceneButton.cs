using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Weapons.Ui.Menus
{
    public class LoadSceneButton : MonoBehaviour
    {
        public Button button;
        public string sceneName;
        private void OnEnable()
        {
            
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}