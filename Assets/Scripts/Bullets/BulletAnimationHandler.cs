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
            //animator.SetTrigger("Destroy");
            animator.enabled = true;
            animator.Play("destroy_bullet");
        }

        private void OnBulletHit()
        {
            //animator.SetTrigger("Destroy");
            animator.enabled = true;
            animator.Play("destroy_bullet");
        }

        private void OnBulletDestroyed()
        {
            //animator.SetTrigger("Explode");
            animator.enabled = true;
            animator.Play("explode_bullet");
        }

        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}