using System;
using Health;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Energy
{
    [RequireComponent(typeof(EnergyController),typeof(HealthController))]
    public class EnergyRegenerationController : MonoBehaviour
    {
        [Tooltip("energy regeneration per second")]
        [SerializeField][Min(0)]
        private float quantity;

        public event Action<float> RegenerationQuantityChangedEvent; 

        private EnergyController energyController;
        private void Awake()
        {
            energyController = GetComponent<EnergyController>();
        }

        private void Update()
        {
            energyController.AddCurrentEnergy(quantity* Time.deltaTime); 
        }

        public void SetQuantity(float value)
        {
            quantity = value;
            
            RegenerationQuantityChangedEvent?.Invoke(value);
        }

        public float GetQuantity()
        {
            return quantity;
        }
    }
}