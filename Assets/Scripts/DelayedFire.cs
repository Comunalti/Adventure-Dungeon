using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "DelayedFire", menuName = "DelayedFire")]
    public class DelayedFire : FireDelegate
    {
        public float delayTime = 1;
        public GameObject bulletPrefab;
        public int bullets = 2;
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
            for (int i = 0; i < bullets; i++)
            {
                var bullet = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation);
                if (i != bullets-1)
                    yield return new WaitForSeconds(delayTime);
            }
        }
    }
}