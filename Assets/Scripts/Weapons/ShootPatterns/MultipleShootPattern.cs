using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Weapons.Controllers;

namespace Weapons.ShootPatterns
{
    [CreateAssetMenu(menuName = "ShootPattern/Create MultipleShootPattern", fileName = "MultipleShootPattern", order = 0)]
    public class MultipleShootPattern : ShootPattern
    {
        public float angleInterval = 0;
        public float bulletsFired = 1;

        public override IEnumerator Fire(WeaponController weaponController, GameObject bulletPrefab)
        {
            var totalAngle = angleInterval * bulletsFired;

            var currentAngle = -totalAngle / 2f;

            for (int i = 0; i < bulletsFired; i++)
            {
                var bullet = SpawnBullet(weaponController, bulletPrefab);

                var rotation = bullet.transform.rotation * Quaternion.Euler(0, 0, currentAngle);
                bullet.transform.rotation = rotation;
                currentAngle += angleInterval;
                
            }
            
            
            yield break;

        }
    }
}