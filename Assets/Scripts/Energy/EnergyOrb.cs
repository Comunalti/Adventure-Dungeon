using System;
using UnityEngine;

namespace Energy
{
    public class EnergyOrb : MonoBehaviour
    {
        public float quantity = 1;
        public event Action OrbCollectedEvent;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.CompareTag("Player")) return;
        
            var energy = col.gameObject.GetComponent<EnergyController>();

            if (energy == null) return;
        
            energy.AddCurrentEnergy(quantity);
            OrbCollectedEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
