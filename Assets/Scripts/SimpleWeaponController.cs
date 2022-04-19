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
        public FireDelegate fireDelegate;

        public void CallFire() 
        {
            fireDelegate.Fire(this);
        }

        public IEnumerator ResetFire()
        {
            yield return new WaitForSeconds(delayTime);
            canFire = true;
        }

        private void OnEnable()
        {
            InputManager.Instance.MouseRightClickEvent += CallFire;   
        }

        private void OnDisable()
        {
            InputManager.Instance.MouseRightClickEvent -= CallFire;
        }
    }
}