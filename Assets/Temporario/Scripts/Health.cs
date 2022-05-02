using System;
using System.Collections;
using System.Collections.Generic;
using Damage;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
   [SerializeField] private float currentHp = 0;
   [SerializeField] private float maxHp = 10;
   public bool isInvincible;
   public bool isDead;
   
   
   public event Action<float> TookDamageEvent;
   public event Action<DamageParameter> TookElementalDamageEvent; 
   public event Action<float> HealDamageEvent;
   public event Action DiedEvent;

   private void Start()
   {
       currentHp = maxHp;
   }

   public void RemoveHp(DamageParameter damageParameter)
    {
        if (isDead||isInvincible)
        {
            return;
        }
        
        currentHp -= damageParameter.damageQuantity;
        TookDamageEvent?.Invoke(damageParameter.damageQuantity);
        TookElementalDamageEvent?.Invoke(damageParameter);

        if (currentHp <= 0)
        {
            DiedEvent?.Invoke();
            isDead = true;
        }
    }

    public void HealHp(float quantity)
    {
        if (isDead)
        {
            return;
        }

        currentHp = Mathf.Clamp(currentHp+quantity, 0, maxHp);
        HealDamageEvent?.Invoke(quantity);
    }
    
    public float GetPercentage()
    {
        return currentHp / maxHp;
    }
}
