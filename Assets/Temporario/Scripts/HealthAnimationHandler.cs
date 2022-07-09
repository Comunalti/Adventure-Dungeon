using System;
using UnityEngine;

namespace Temporario.Scripts
{
    public class HealthAnimationHandler : MonoBehaviour
    {
        public Animator animator;
        public Health health;

        private void OnEnable()
        {
            health.DiedEvent += OnDeath;
        }

        private void OnDisable()
        {
            health.DiedEvent -= OnDeath;

        }

        private void OnDeath()
        {
            print("died");
            animator.SetTrigger("Died");
        }
    }
}