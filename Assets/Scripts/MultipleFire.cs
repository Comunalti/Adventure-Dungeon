using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "MultipleFire", menuName = "MultipleFire")]
    public class MultipleFire : FireDelegate
    {
        public GameObject bulletPrefab;
        public int bullets = 3;
        public float maxAngle = 1;
        public float minAngle = -1;
        public float scale = 10;
        public override void Fire(SimpleWeaponController weaponController)
        {
            if (!weaponController.canFire)
            {
                return;
            }

            weaponController.canFire = false;
            if (bullets > 1)
            {
                for (int i = 0; i < bullets; i++)
                {
                    var bullet = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation*quaternion.Euler(0,0,
                        ((maxAngle + scale / bullets) - ((maxAngle + scale / bullets) - (minAngle - scale / bullets)) / (bullets - 1) * i)* Mathf.Deg2Rad));
                }
            }
            else
            {
                var bullet = Object.Instantiate(weaponController.bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation);
            }
            //bullet.BroadcastMessage("FireInDirection",,SendMessageOptions.RequireReceiver);
            weaponController.StartCoroutine(weaponController.ResetFire());
        }
    }
}