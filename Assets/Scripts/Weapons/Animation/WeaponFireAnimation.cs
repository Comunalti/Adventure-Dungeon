using System;
using UnityEngine;
using Weapons.Controllers;

namespace Weapons.Animation
{
    public class WeaponFireAnimation : MonoBehaviour
    {
        public WeaponController weaponController;
        public Animator animator;
        private void OnEnable()
        {
            weaponController.WeaponFiredEvent += OnWeaponFired;
        }

        private void OnDisable()
        {
            weaponController.WeaponFiredEvent -= OnWeaponFired;
        }

        private void OnWeaponFired()
        {
            animator.SetTrigger("Fire");
        }
    }
}