using System;
using UnityEngine;

namespace Bullets
{
    public class BulletAnimationHandler : MonoBehaviour
    {

        public Bullet bullet;
        public Animator animator;

        private void OnEnable()
        {
            bullet.BulletDestroyedEvent += OnBulletDestroyed;
            bullet.BulletHitEvent += OnBulletHit;
            bullet.BulletLifeTimeExpireEvent += OnBulletLifeTimeExpire;
        }

        private void OnDisable()
        {
            bullet.BulletDestroyedEvent -= OnBulletDestroyed;
            bullet.BulletHitEvent -= OnBulletHit;
            bullet.BulletLifeTimeExpireEvent -= OnBulletLifeTimeExpire;
        }

        private void OnBulletLifeTimeExpire()
        {
            animator.SetTrigger("Explode");
            
        }

        private void OnBulletHit()
        {
            animator.SetTrigger("Explode");
        }

        private void OnBulletDestroyed()
        {
            animator.SetTrigger("Explode");
        }

        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}