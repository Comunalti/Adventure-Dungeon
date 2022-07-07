using System.Collections;
using Entities;
using UnityEngine;
using Weapons.Controllers;

namespace Weapons.ShootPatterns
{
    public abstract class ShootPattern : ScriptableObject
    {
        public abstract IEnumerator Fire(WeaponController weaponController, GameObject bulletPrefab);


        protected GameObject SpawnBullet(WeaponController weaponController, GameObject bulletPrefab)
        {
            var spawnBullet = Instantiate(bulletPrefab, weaponController.spawnPivot.position,
                weaponController.spawnPivot.rotation * Quaternion.Euler(0, 0, weaponController.Precision));
            
            var entity = spawnBullet.GetComponent<Entity>();
            entity.entitySO = weaponController.owner;
            
            return spawnBullet;
        }
    }
}