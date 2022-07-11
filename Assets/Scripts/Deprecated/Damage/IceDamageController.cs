using System;
using System.Collections;
using System.Collections.Generic;
using Health;
using MovementCommands;
using UnityEngine;
using static MovementCommands.NormalMovementCommand;

namespace Damage
{
    public class IceDamageController : MonoBehaviour
    {
        [SerializeField] private NormalMovementCommand normalMovementCommand;
        [SerializeField] private HealthController healthController;
        public string damageString;
        public float bulletIceDamage;
        [SerializeField]public bool isOnIce;
        [SerializeField] private float iceDelay = 0.1f;
        public float slow;
        public float iceDamage;
        [SerializeField] private float freezeSpeed;

        public event Action IceEffectStartEvent;

        public event Action IceEffectEndEvent;

        private IEnumerator ResetIce()
        {
            yield return new WaitForSeconds(iceDelay);
            isOnIce = false;
            IceEffectEndEvent?.Invoke();
            normalMovementCommand.speed = normalMovementCommand.normalSpeed;
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
                isOnIce = true;
                normalMovementCommand.speed = freezeSpeed;
                StartCoroutine(ResetIce());
                
                IceEffectStartEvent?.Invoke();
            }
        }

    }
}