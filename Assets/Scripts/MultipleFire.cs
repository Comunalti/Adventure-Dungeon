using System;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "MultipleFire", menuName = "MultipleFire")]
    public class MultipleFire : FireDelegate
    {
        public GameObject bulletPrefab;
        public int bullets = 3;
        public float maxAngle = 90;
        public float scale = 45;
        public override void Fire(SimpleWeaponController weaponController)
        {
            throw new NotImplementedException("manutenção, terminar isso aqui");
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
                        ((- scale / (bullets - 1) + maxAngle) / 2 - (- scale / (bullets - 1) + maxAngle) / (bullets - 1) * i)* Mathf.Deg2Rad));
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