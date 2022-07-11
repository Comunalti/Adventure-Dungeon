using System;
using UnityEngine;

namespace Energy
{
    public class EnergyController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float maxEnergy = 10.0f;
        [SerializeField] private float currentEnergy;

        #endregion
        
        #region Events
        /// <summary>
        /// quantity added parameter
        /// </summary>
        public event Action<float> CurrentEnergyAddedEvent;
        /// <summary>
        /// quantity removed parameter
        /// </summary>
        public event Action<float> CurrentEnergyRemovedEvent;
        /// <summary>
        /// new current energy parameter
        /// </summary>
        public event Action<float> CurrentEnergyChangeEvent;
        /// <summary>
        /// new max energy parameter
        /// </summary>
        public event Action<float> MaxEnergyChangeEvent;
        /// <summary>
        /// fired when anything changed
        /// </summary>
        public event Action EnergyChangedEvent;
        
        #endregion

        #region Setters

        public void SetMaxEnergy(float value)
        {
            maxEnergy = value;
            
            MaxEnergyChangeEvent?.Invoke(maxEnergy);
            EnergyChangedEvent?.Invoke();
        }
        public void SetCurrentEnergy(float value)
        {
            currentEnergy = Mathf.Clamp(value, 0, maxEnergy);
            
            CurrentEnergyChangeEvent?.Invoke(currentEnergy);
            EnergyChangedEvent?.Invoke();
        }
        
        public void AddCurrentEnergy(float quantity)
        {
            currentEnergy = Mathf.Clamp(currentEnergy + quantity, 0, maxEnergy);
            
            CurrentEnergyAddedEvent?.Invoke(quantity);
            CurrentEnergyChangeEvent?.Invoke(currentEnergy);
            EnergyChangedEvent?.Invoke();
        }
    
        public void RemoveCurrentEnergy(float quantity)
        {
            currentEnergy = Mathf.Clamp(currentEnergy - quantity, 0, maxEnergy);
            
            CurrentEnergyRemovedEvent?.Invoke(quantity);
            CurrentEnergyChangeEvent?.Invoke(currentEnergy);
            EnergyChangedEvent?.Invoke();
        }
        #endregion
        
        #region Getters

        public float GetEnergy()
        {
            return currentEnergy;
        }

        public bool Have(float energyCost)
        {
            return currentEnergy > energyCost;
        }

        public float GetPercentage()
        {
            return currentEnergy / maxEnergy;
        }

        #endregion
    }
}
