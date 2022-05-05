using System;
using System.Collections;
using System.Collections.Generic;
using MovementCommands;
using UnityEngine;

namespace Damage
{
    public class IceDamageController : MonoBehaviour
    {
        [SerializeField] private NormalMovementCommand _normalMovementCommand;
        [SerializeField] private Health health;
        public string damageString;
        public float bulletIceDamage;
        [SerializeField]public bool isOnIce;
        [SerializeField] private float iceDelay = 0.1f;
        public float slow;
        

        private IEnumerator ResetIce()
        {
            yield return new WaitForSeconds(iceDelay);
            isOnIce = true;
        }

        //private void Update()
        //{
            //if (isOnIce)
            //{
               // health.RemoveHp(damage);
            //}
            
        //}
        private void Update()
        {
            if (isOnIce)
            {
                NormalMovementCommand.speed = 0.5f; 
                isOnIce = false;
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
                isOnIce = true;
                StartCoroutine(ResetIce());
            }
            
        }
        
    }
}