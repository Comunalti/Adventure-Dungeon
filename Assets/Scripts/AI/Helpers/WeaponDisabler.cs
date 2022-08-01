using Health;
using UnityEngine;

namespace AI.Helpers
{
    public class WeaponDisabler : MonoBehaviour
    {
        public HealthController healthController;
        public GameObject pivot;
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
            Destroy(pivot);
        }
    }
}