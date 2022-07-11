using System;
using System.Collections;
using Health;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

namespace Damage
{
    public class FireDamageController : MonoBehaviour
    {
        [SerializeField] private HealthController healthController;
        public string damageString;
        public float bulletFireDamage;
        [SerializeField]public bool isOnFire;
        [SerializeField] private float fireDelay = 0.1f;
        public float damage;
        
        public event Action FireEffectStartEvent;
        
        public event Action FireEffectEndEvent;

        private IEnumerator ResetFire()
        {
            yield return new WaitForSeconds(fireDelay);
            isOnFire = false;
            FireEffectEndEvent?.Invoke();
        }

        private void Update()
        {
            if (isOnFire)
            {
                healthController.RemoveCurrentHealth(damage*Time.deltaTime);
            }
            
            

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
                isOnFire = true;
                StartCoroutine(ResetFire());
                FireEffectStartEvent?.Invoke();
            }
            
        }
        
    }
}