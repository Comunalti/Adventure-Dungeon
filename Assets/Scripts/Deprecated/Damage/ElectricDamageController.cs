using System;
using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;
using MovementCommands;

namespace Damage
{
    public class ElectricDamageController : MonoBehaviour
    {
        
        [SerializeField] private HealthController healthController;
        public string damageString;
        public float bulletElectricDamage;
        [SerializeField]public bool isOnElectric;
        [SerializeField] private float electricDelay = 0.1f;
        public float electricDamage;
        [SerializeField] private float electricSpeed;
        public List<HealthController> healthList = new List<HealthController>();
        [SerializeField] private float damage = 0.5f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            var health = col.GetComponent<HealthController>();
            if (health)
            {
                healthList.Add(health); 
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var health = other.GetComponent<HealthController>();
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
            //healthController.TookElementalDamageEvent += OnElementalDamage;
        }
        private void OnDisable()
        {
            //healthController.TookElementalDamageEvent -= OnElementalDamage;
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
                health.RemoveCurrentHealth(damage);
            }
        }
    }
}