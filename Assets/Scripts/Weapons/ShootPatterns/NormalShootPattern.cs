using System.Collections;
using UnityEngine;
using Weapons.Controllers;

namespace Weapons.ShootPatterns
{
    [CreateAssetMenu(menuName = "ShootPattern/Create NormalShootPattern", fileName = "NormalShootPattern", order = 0)]
    public class NormalShootPattern : ShootPattern
    {
        public override IEnumerator Fire(WeaponController weaponController, GameObject bulletPrefab)
        {
            SpawnBullet(weaponController, bulletPrefab);
            
            yield break;
        }
    }
}