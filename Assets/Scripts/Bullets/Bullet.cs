﻿using System;
using Damage;
using Entities;
using Health;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bullets
{
    [RequireComponent(typeof(Entity))]
    public class Bullet : MonoBehaviour
    {
        public event Action BulletHitEvent;
        public event Action BulletDestroyedEvent;
        public event Action BulletLifeTimeExpireEvent;

        public float damage;
        public ElementalDamage elementalDamage;

        public float lifeTime;
        public Vector2 lifeTimeRange;
        public AnimationCurve lifeTimeDistribution;
        public float LifeTimeValue => Mathf.Lerp(lifeTimeRange.x,lifeTimeRange.y,speedRangeDistribution.Evaluate(Random.value));

        
        private float speed;
        public Vector2 speedRange;
        public AnimationCurve speedRangeDistribution;
        public float SpeedValue => Mathf.Lerp(speedRange.x,speedRange.y,speedRangeDistribution.Evaluate(Random.value));


        private Entity entityOwner;
        

        private void Awake()
        {
            entityOwner = GetComponent<Entity>();
            
            speed = SpeedValue;

            lifeTime = LifeTimeValue;
        }

        private void Update()
        {
            transform.position += transform.right*(Time.deltaTime*speed);
            
            lifeTime -= Time.deltaTime;
            if (lifeTime<=0)
            {
                LifeTimeExpired();
            }
        }

        private void LifeTimeExpired()
        {
            enabled = false;
            BulletLifeTimeExpireEvent?.Invoke();
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Bullet")) return;

            var entity = col.GetComponentInChildren<Entity>();
            
            if (col.isTrigger)
            {
                return;
            }

            if (entity!=null)
            {
                if ( entity.entitySO == entityOwner.entitySO || entityOwner.entitySO.DoesNotAttack(entity.entitySO) )
                {
                    return;
                }
            }
            
            var healthComponent = col.GetComponentInChildren<HealthController>();

            if (healthComponent != null)
            {
                healthComponent.RemoveCurrentHealth(damage);
                enabled = false;
                BulletHitEvent?.Invoke();
            }
            else
            {
                enabled = false;
                BulletDestroyedEvent?.Invoke();
            }
        }
    }
}