using System;
using Damage;
using UnityEngine;

namespace Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private float currentHealth = 0;
        [SerializeField] private float maxHealth = 10;
        
        public bool isInvincible;
        public bool isDead;


        #region Events

        /// <summary>
        /// new quantity parameter
        /// </summary>
        public event Action<float> MaxHpChangedEvent;
        /// <summary>
        /// new quantity parameter
        /// </summary>
        public event Action<float> HpChangedEvent;
        /// <summary>
        /// hp removed parameter
        /// </summary>
        public event Action<float> RemoveHpEvent;
        /// <summary>
        /// hp added parameter
        /// </summary>
        public event Action<float> AddHpEvent;
        
        public event Action DeathEvent;

        #endregion

        #region Setters

        public void SetMaxHealth(float value)
        {
            maxHealth = value;

            MaxHpChangedEvent?.Invoke(maxHealth);
            
            SetCurrentHealth(currentHealth);
        }

        public void SetCurrentHealth(float value)
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);

            HpChangedEvent?.Invoke(currentHealth);
            
            if (currentHealth <= 0)
            {
                isDead = true;
                DeathEvent?.Invoke();
            }
        }
        public void RemoveCurrentHealth(float quantity , bool ignoreInvincibility = false)
        {
            if (isDead)
            {
                return;
            }

            if (isInvincible)
                if (ignoreInvincibility == false)
                    return;
            
            currentHealth = Mathf.Clamp(currentHealth - quantity, 0, maxHealth);
            RemoveHpEvent?.Invoke(quantity);
            HpChangedEvent?.Invoke(currentHealth);
            
            if (currentHealth <= 0)
            {
                isDead = true;
                DeathEvent?.Invoke();
            }
        }
   
        public void AddCurrentHealth(float quantity)
        {
            if (isDead) return;
            
            currentHealth = Mathf.Clamp(currentHealth + quantity, 0, maxHealth);
            
            AddHpEvent?.Invoke(quantity);
            HpChangedEvent?.Invoke(currentHealth);
            if (currentHealth <= 0)
            {
                isDead = true;
                DeathEvent?.Invoke();
            }
        }

        #endregion

        #region Getters
        public float GetPercentage()
        {
            return currentHealth / maxHealth;
        }
        #endregion
        
    }
}
