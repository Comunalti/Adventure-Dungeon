using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace Damage
{
    public class SimpleBullet : MonoBehaviour
    {
        //public Vector3 _direction;
        public float speed = 1;
        public float bulletLifeTime = 10;
        public float damageQuantity = 1;
        public ElementalDamage elementalDamage;
        [SerializeField] private GameObject owner;
        // public void FireInDirection(Vector3 direction)
        // {
        //     print(direction);
        //     _direction = direction;
        // }
        private void Update()
        {
            transform.position = transform.position + transform.right* (Time.deltaTime * speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject == owner)
            {
                return;
            }

            col.gameObject.BroadcastMessage("RemoveHp",damageQuantity,SendMessageOptions.DontRequireReceiver);
            col.gameObject.BroadcastMessage("DealElementalDamage",elementalDamage,SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }

        public void Inject(SimpleWeaponController simpleWeaponController)
        {
            owner = simpleWeaponController.gameObject;
        }
        public IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(bulletLifeTime);
            if (bulletLifeTime != 0)
            {
                Destroy(gameObject);
            }
        }
        private void Awake()
        {
            StartCoroutine(DestroyBullet());
        }
    }
}