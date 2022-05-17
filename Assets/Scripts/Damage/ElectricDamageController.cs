using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementCommands;

namespace Damage
{
    public class ElectricDamageController : MonoBehaviour
    {
        
        [SerializeField] private Health health;
        public string damageString;
        public float bulletElectricDamage;
        [SerializeField]public bool isOnElectric;
        [SerializeField] private float electricDelay = 0.1f;
        public float electricDamage;
        [SerializeField] private float electricSpeed;
        public List<Health> healthList = new List<Health>();
        [SerializeField] private float damage = 0.5f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            var health = col.GetComponent<Health>();
            if (health)
            {
                healthList.Add(health); 
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var health = other.GetComponent<Health>();
            if (health)
            {
                healthList.Remove(health);
            }
        }

        public event Action ElectricEffectStartEvent;

        public event Action ElectricEffectEndEvent;

        private IEnumerator ResetElectric()
        {
            yield return new WaitForSeconds(electricDelay);
            isOnElectric= false;
            ElectricEffectEndEvent?.Invoke();
            //normalMovementCommand.speed = normalMovementCommand.normalSpeed;
        }

        private void OnEnable()
        {
            health.TookElementalDamageEvent += OnElementalDamage;
        }
        private void OnDisable()
        {
            health.TookElementalDamageEvent -= OnElementalDamage;
        }
        
        private void OnElementalDamage(ElementalDamage elementalDamage)
        {
            if (elementalDamage.nome == damageString)
            {
                isOnElectric = true;
                //normalMovementCommand.speed = freezeSpeed;
                DamageCloseEnemy();
                StartCoroutine(ResetElectric());
                
                ElectricEffectStartEvent?.Invoke();
            }
        }

        private void DamageCloseEnemy()
        {
            foreach (var health in healthList)
            {
                health.RemoveHp(damage);
            }
        }
    }
}