using System;
using UnityEngine;

namespace Managers
{
    public class PauseManager : MonoBehaviour
    {
        public event Action GamePausedEvent;
        public event Action GameUnPausedEvent;
        private bool paused;
        
        public void Pause()
        {
            Time.timeScale = 0;
            paused = true;
            GamePausedEvent?.Invoke();
        }

        public void UnPause()
        {
            Time.timeScale = 1;
            paused = false;
            GameUnPausedEvent?.Invoke();
        }

        private void Awake()
        {
            InputManager.Instance.EscPressEvent += OnEscPressed;
            Time.timeScale = 1;
        }

        private void OnDestroy()
        {
            Time.timeScale = 1;
        }

        private void OnEscPressed()
        {
            if (paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }
}