using System;
using System.Collections;
using System.Collections.Generic;
using Damage;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
   [SerializeField] public float currentHp = 0;
   [SerializeField] private float maxHp = 10;
   public bool isInvincible;
   public bool isDead;
   
   
   
   public event Action<float> TookDamageEvent;
   
   public event Action<ElementalDamage> TookElementalDamageEvent;
   
   public event Action<float> HealDamageEvent;
   public event Action DiedEvent;

   private void Start()
   {
       currentHp = maxHp;
   }

   public void DealElementalDamage(ElementalDamage elementalDamage)
   {
       if (elementalDamage != null)
       { 
           TookElementalDamageEvent?.Invoke(elementalDamage);
       }
       
   }
   public void RemoveHp(float damage , bool ignoreInvincibility = false)
    {
        if (isDead)
        {
            return;
        }

        if (!(ignoreInvincibility))
        {
            if (isInvincible)
            {
                return;
            }
        }

        currentHp -= damage;
        TookDamageEvent?.Invoke(damage);

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

    [ContextMenu("SendEvent")]
    public void SendEvent()
    {
        TookDamageEvent?.Invoke(0);
    }
}
