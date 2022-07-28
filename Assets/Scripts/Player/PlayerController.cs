using System;
using Health;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public HealthController healthController;
        private void Awake()
        {
            PlayerManager.Instance.AddPlayer(this);
        }

        private void OnEnable()
        {
            healthController.DeathEvent += OnPlayerDeath;
        }

        public void OnDisable()
        {
            healthController.DeathEvent -= OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            //Destroy(gameObject);

            //GameManager.Instance.GameEndEvent.Invoke();
        }
    }
}