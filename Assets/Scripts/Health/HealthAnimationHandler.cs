using UnityEngine;

namespace Health
{
    public class HealthAnimationHandler : MonoBehaviour
    {
        public Animator animator;
        public HealthController healthController;

        private void OnEnable()
        {
            healthController.DeathEvent += OnDeath;
        }

        private void OnDisable()
        {
            healthController.DeathEvent -= OnDeath;

        }

        private void OnDeath()
        {
            animator.SetTrigger("Died");
        }
    }
}