using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

namespace Damage
{
    public class FireDamageController : MonoBehaviour
    {
        [SerializeField] private Health health;
        public string damageString;
        public float bulletFireDamage;
        [SerializeField]public bool isOnFire;
        [SerializeField] private float fireDelay = 0.1f;
        public float damage;
        

        private IEnumerator ResetFire()
        {
            yield return new WaitForSeconds(fireDelay);
            isOnFire = true;
        }

        private void Update()
        {
            if (isOnFire)
            {
                health.RemoveHp(damage*Time.deltaTime);
            }
            
            

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
                isOnFire = true;
                StartCoroutine(ResetFire());
            }
            
        }
        
    }
}