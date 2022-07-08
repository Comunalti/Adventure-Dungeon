using System;
using UnityEngine;


namespace Banza.Script
{

    public class PauseMenu : MonoBehaviour
    {
        ControlMap _action;

        public static bool paused;

        public GameObject menu;

        private void Awake()
        {
            _action = new ControlMap();
        }

        private void OnEnable()
        {
            _action.Enable();
        }

        private void OnDisable()
        {
            _action.Disable();
        }

        private void Start()
        {
            _action.InteractionMap.EscapeButton.performed += _ => DeterminePause();

        }

        private void DeterminePause()
        {
            if (paused)
                Resume();
            else
                Pause();
        }


        // Quando chamado, abre o menu e pausa o jogo

        public void Pause()
        {
            Time.timeScale = 0;
            paused = true;
            menu.SetActive(true);
        }

        //Quando chamado, fecha o menu e despausa o jogo.

        public void Resume()
        {
            Time.timeScale = 1;
            paused = false;
            menu.SetActive(false);
        }
        
    }

}
