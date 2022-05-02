using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "FireDelegate", menuName = "FireDelegate")]
    public class FireDelegate : ScriptableObject
    {
        public virtual void Fire(SimpleWeaponController weaponController)
        {
            if (!weaponController.canFire)
            {
                return;
            }

            weaponController.canFire = false;
            var bullet = Object.Instantiate(weaponController.bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation);
            bullet.BroadcastMessage("Inject",weaponController,SendMessageOptions.RequireReceiver);
            weaponController.StartCoroutine(weaponController.ResetFire());
        }
    }
}