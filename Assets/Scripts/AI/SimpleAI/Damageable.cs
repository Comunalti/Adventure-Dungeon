using System;
using Player;
using UnityEngine;

namespace Weapons.AI.SimpleAI
{
    public class Damageable : MonoBehaviour
    {
        public float damage = 1; 
        public float delayTime = 0.5f;
        public float currentTime = 0;

        private void OnCollisionStay2D(Collision2D collision)
        {
            
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = delayTime;
                print(collision.collider.gameObject.name);
                if (collision.collider.gameObject.CompareTag("Player"))
                {
                    collision.collider.GetComponent<Health>().RemoveHp(damage);
                }    
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            currentTime = 0;
        }
    }
}