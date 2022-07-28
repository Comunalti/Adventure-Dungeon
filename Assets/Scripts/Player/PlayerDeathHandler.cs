using System;
using Health;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerDeathHandler : MonoBehaviour
    {
        public HealthController healthController;

        private void OnEnable()
        {

            healthController.DeathEvent += OnDeathEvent;
        }

        private void OnDisable()
        {
            healthController.DeathEvent -= OnDeathEvent;
        }

        private void OnDeathEvent()
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}