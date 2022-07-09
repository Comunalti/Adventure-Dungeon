using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public Health health;
        private void Awake()
        {
            PlayerManager.Instance.AddPlayer(this);
        }

        private void OnEnable()
        {
            health.DiedEvent += OnPlayerDied;
        }

        public void OnDisable()
        {
            health.DiedEvent -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            Destroy(gameObject);

            GameManager.Instance.GameEndEvent.Invoke();
        }
    }
}