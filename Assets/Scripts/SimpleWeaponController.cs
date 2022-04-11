using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace DefaultNamespace
{
    public class SimpleWeaponController : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform spawnPivot;

        public bool canFire;
        public float delayTime = 1;
        private void Fire()
        {
            if (!canFire)
            {
                return;
            }

            canFire = false;
            var bullet = Instantiate(bulletPrefab, spawnPivot.position,transform.rotation);
            //bullet.BroadcastMessage("FireInDirection",,SendMessageOptions.RequireReceiver);
            StartCoroutine(ResetFire());
        }

        private IEnumerator ResetFire()
        {
            yield return new WaitForSeconds(delayTime);
            canFire = true;
        }

        private void OnEnable()
        {
            InputManager.Instance.MouseRightClickEvent += Fire;   
        }

        private void OnDisable()
        {
            InputManager.Instance.MouseRightClickEvent -= Fire;
        }
    }
}