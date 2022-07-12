using System;
using Managers;
using UnityEngine;
using Weapons.Factories;

namespace Ui.Inventory
{
    public class InventoryWeaponDropperController : MonoBehaviour
    {
        public WeaponCollectableFactory weaponCollectableFactory;
        
        private void OnEnable()
        {
            InputManager.Instance.XPressEvent += OnXPress;

        }

        private void OnDisable()
        {
            InputManager.Instance.XPressEvent -= OnXPress;
        }

        [ContextMenu("drop weapon")]
        private void OnXPress()
        {
            weaponCollectableFactory.DropActiveWeapons();
        }

    }
}