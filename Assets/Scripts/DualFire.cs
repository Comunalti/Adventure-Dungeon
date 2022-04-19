using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "DualFire", menuName = "DualFire")]
    public class DualFire : FireDelegate
    {
        public float angle = 1;
        public float scale;
        public GameObject bulletPrefab;
        public override void Fire(SimpleWeaponController weaponController)
        {
            if (!weaponController.canFire)
            {
                return;
            }

            weaponController.canFire = false;
            var bullet1 = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation*quaternion.Euler(0,0,angle*Mathf.Deg2Rad));
            var bullet2 = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position+weaponController.spawnPivot.up*scale,weaponController.transform.rotation*quaternion.Euler(0,0,-angle*Mathf.Deg2Rad));
            //bullet.BroadcastMessage("FireInDirection",,SendMessageOptions.RequireReceiver);
            bullet1.GetComponent<SimpleBullet>().speed = 0.6f;
            weaponController.StartCoroutine(weaponController.ResetFire());
        }
    }
}