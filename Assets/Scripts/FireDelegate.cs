using Damage;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "FireDelegate", menuName = "FireDelegate")]
    public class FireDelegate : ScriptableObject
    {
        public virtual void Fire(SimpleWeaponController weaponController)
        {
            weaponController.canFire = false;
            Shoot(weaponController.bulletPrefab,weaponController);
            
            weaponController.StartCoroutine(weaponController.ResetFire());
        }

        protected void Shoot(GameObject bulletPrefab,SimpleWeaponController weaponController)
        {
            var bullet = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation);
            bullet.GetComponent<SimpleBullet>().Inject(weaponController);
        }
    }
}