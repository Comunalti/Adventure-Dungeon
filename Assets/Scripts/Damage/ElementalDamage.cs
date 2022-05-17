using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;


namespace Damage
{
    [CreateAssetMenu(menuName = "Create ElementalDamage", fileName = "ElementalDamage", order = 0)]
    public class ElementalDamage : ScriptableObject

    {
         public string nome;
         
    //     public float fireDamageQuantity = 1;
    //     [SerializeField] private float fireBulletDelay = 1;
    //     [SerializeField] private bool canBullet;
    //     public float fireBulletSpeed = 1;
    //     public float bulletLifeTime = 10;
    //     [SerializeField] private GameObject owner;
    //     public bool isInvincible;
    //     public event Action BulletFireEvent;
    //     
    //     private void Update()
    //     {
    //         transform.position = transform.position + transform.right* (Time.deltaTime * fireBulletSpeed);
    //     }
    //     private IEnumerator ResetFireBullet()
    //     {
    //         yield return new WaitForSeconds(fireBulletDelay);
    //         canBullet = true;
    //     }
    //     public struct FireDamageParameter
    //     {
    //         public float damageQuantity;
    //         public ElementalDamage elementalDamage;
    //     }
    //
    //     private void OnTriggerEnter2D(Collider2D col)
    //     {
    //         if (col.gameObject == owner)
    //         {
    //             return;
    //         }
    //
    //         FireDamageParameter parameter = new FireDamageParameter();
    //         parameter.damageQuantity = fireDamageQuantity;
    //         col.gameObject.BroadcastMessage("RemoveHp", parameter, SendMessageOptions.DontRequireReceiver);
    //         Destroy(gameObject);
    //     }
    //     
    //     private void OnFire()
    //     {
    //         if (canBullet)
    //         {
    //             canBullet = false;
    //             StartCoroutine(ResetFireBullet());
    //
    //             BulletFireEvent?.Invoke();
    //         }
    //     }
    //     
    //     public void Inject(SimpleWeaponController simpleWeaponController)
    //     {
    //         owner = simpleWeaponController.gameObject;
    //     }
    //     public IEnumerator DestroyBullet()
    //     {
    //         yield return new WaitForSeconds(bulletLifeTime);
    //         if (bulletLifeTime != 0)
    //         {
    //             Destroy(gameObject);
    //         }
    //     }
    //     
    //     private void Awake()
    //     {
    //         StartCoroutine(DestroyBullet());
    //     }
     }
}