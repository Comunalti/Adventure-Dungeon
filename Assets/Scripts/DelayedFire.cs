using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "DelayedFire", menuName = "DelayedFire")]
    public class DelayedFire : FireDelegate
    {
        public float delayTime = 1;
        public GameObject bulletPrefab;
        public override void Fire(SimpleWeaponController weaponController)
        {
            if (!weaponController.canFire)
            {
                return;
            }

            weaponController.canFire = false;
            weaponController.StartCoroutine(SpawnBullet(weaponController));
            
            
            //bullet.BroadcastMessage("FireInDirection",,SendMessageOptions.RequireReceiver);
            weaponController.StartCoroutine(weaponController.ResetFire());
        }

        public IEnumerator SpawnBullet(SimpleWeaponController weaponController)
        {
            var bullet1 = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation);
            yield return new WaitForSeconds(delayTime);
            var bullet2 = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation);
        }
    }
}