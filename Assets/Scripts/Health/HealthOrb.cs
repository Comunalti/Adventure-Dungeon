using System;
using UnityEngine;

namespace Health
{
    public class HealthOrb : MonoBehaviour
    {
        public float quantity = 1;

        public event Action OrbCollectedEvent;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player")) return;

            var health = col.GetComponentInChildren<HealthController>();

            if (health == null) return;
        
            health.AddCurrentHealth(quantity);
            OrbCollectedEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
