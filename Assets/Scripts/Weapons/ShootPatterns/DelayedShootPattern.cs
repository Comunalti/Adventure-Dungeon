using System.Collections;
using UnityEngine;
using Weapons.Controllers;

namespace Weapons.ShootPatterns
{
    [CreateAssetMenu(menuName = "ShootPattern/Create DelayedShootPattern", fileName = "DelayedShootPattern", order = 0)]
    public class DelayedShootPattern : ShootPattern
    {
        public float timeInterval;
        public float bulletsFired;
        public override IEnumerator Fire(WeaponController weaponController, GameObject bulletPrefab)
        {
            var timeDelay = new WaitForSeconds(timeInterval);
            
            for (int i = 0; i < bulletsFired; i++)
            {
                SpawnBullet(weaponController, bulletPrefab);
                yield return timeDelay;
            }
            
            yield break;
        }
    }
}