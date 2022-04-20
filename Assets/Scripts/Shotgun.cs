using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Shotgun", menuName = "Shotgun")]
    public class Shotgun : FireDelegate
    {
        public GameObject bulletPrefab;
        public int bullets = 5;
        public float maxAngle = 30;
        public float minAngle = -30;
        public float maxSpeed = 0.3f;
        public float minSpeed = 0.15f;
        public override void Fire(SimpleWeaponController weaponController)
        {
            if (!weaponController.canFire)
            {
                return;
            }

            weaponController.canFire = false;
            for (int i = 0; i < bullets; i++)
            {
                var bullet = Object.Instantiate(bulletPrefab, weaponController.spawnPivot.position,weaponController.transform.rotation*quaternion.Euler(0,0,UnityEngine.Random.Range(minAngle,maxAngle)*Mathf.Deg2Rad));
                bullet.GetComponent<SimpleBullet>().speed = UnityEngine.Random.Range(minSpeed,maxSpeed);
            }
            
            //bullet.BroadcastMessage("FireInDirection",,SendMessageOptions.RequireReceiver);
            weaponController.StartCoroutine(weaponController.ResetFire());
        }
    }
}