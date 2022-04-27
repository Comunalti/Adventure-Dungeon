using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
   [SerializeField] private float currentHp = 0;
   [SerializeField] private float maxHp = 10;
   public bool isInvincible;
   public bool isDead;
   
   public event Action<float> TookDamageEvent;
   public event Action DiedEvent;

   
   private void Start()
   {
       currentHp = maxHp;
   }

   public void RemoveHp(float quantity)
    {
        if (isDead||isInvincible)
        {
            return;
        }
        
        currentHp -= quantity;
        TookDamageEvent?.Invoke(quantity);

        if (currentHp <= 0)
        {
            DiedEvent?.Invoke();
            isDead = true;
        }
    }
    
    public float GetPercentage()
    {
        return currentHp / maxHp;
    }
}
