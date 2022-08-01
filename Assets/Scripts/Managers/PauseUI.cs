using UnityEngine;

namespace Managers
{
    public class PauseUI : MonoBehaviour
    {
        public PauseManager pauseManager;
        public GameObject canvas;

        private void OnGameUnPaused()
        {
            canvas.SetActive(false);
        }

        private void OnGamePaused()
        {
            canvas.SetActive(true);
        }

        private void Awake()
        {
            pauseManager.GamePausedEvent += OnGamePaused;
            pauseManager.GameUnPausedEvent += OnGameUnPaused;
        }

        private void OnDestroy()
        {
            pauseManager.GamePausedEvent -= OnGamePaused;
            pauseManager.GameUnPausedEvent -= OnGameUnPaused;
        }
    }
}