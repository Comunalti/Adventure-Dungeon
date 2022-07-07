using System;
using Damage;
using Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons.Bullets
{
    [RequireComponent(typeof(Entity))]
    public class Bullet : MonoBehaviour
    {
        public GameObject spawnEffectPrefab;
        
       


        public event Action BulletHitEvent;
        public event Action BulletDestroyedEvent;
        public event Action BulletLifeTimeExpireEvent;

        public float damage;
        public float speed;
        public float lifeTime;
        public ElementalDamage elementalDamage;


        private Entity entityOwner;

        
        
        private void OnEnable()
        {
            
        }

        
        private void OnDisable()
        {
            
        }

        private void Awake()
        {
            entityOwner = GetComponent<Entity>();
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
            if (col.CompareTag("Bullet"))
            {
                return;
            }
            
            var entity = col.GetComponentInChildren<Entity>();
            
            if ( entity != null &&(entity.entitySO == entityOwner.entitySO || entityOwner.entitySO.DoesNotAttack(entity.entitySO)) )
            {
                return;
            }
            
            var healthComponent = col.GetComponentInChildren<Health>();

            if (healthComponent != null)
            {
                healthComponent.RemoveHp(damage);
                enabled = false;
                BulletHitEvent?.Invoke();
                Destroy(gameObject);
            }
            else
            {
                enabled = false;
                BulletDestroyedEvent?.Invoke();
                Destroy(gameObject);

            }
        }
    }
}