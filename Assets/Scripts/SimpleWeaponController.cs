using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class SimpleWeaponController : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform spawnPivot;

        public bool canFire;
        public float delayTime = 1;
        public FireDelegate fireDelegate;

        public Energy energy;
        public float energyCost;
        
        public event Action FireEvent;
        public event Action FireFailEvent;

        private void CallFire() 
        {
            if (canFire && energy.GetEnergy() >= energyCost)
            {
                fireDelegate.Fire(this);
                FireEvent?.Invoke();
                energy.AddToCurrentEnergy(-energyCost);
            }
            else
            {
                FireFailEvent?.Invoke();
            }
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