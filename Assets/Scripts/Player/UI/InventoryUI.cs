using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons;

namespace Player.UI
{
    public class InventoryUI : MonoBehaviour
    {
        public InventoryController inventoryController;

        public List<Slot> slots;
        private void OnWeaponAdded(GameObject obj)
        {
            var emptySlot = GetEmptySlot();
            print(emptySlot);
            emptySlot.SetPattern(obj);
        }

        private Slot GetEmptySlot()
        {
            return slots.Find((slot => slot.weaponConnected == null));  
        }

        private void OnEnable()
        {
            inventoryController.WeaponAddedEvent += OnWeaponAdded;

        }
        private void OnDisable()
        {
            inventoryController.WeaponAddedEvent -= OnWeaponAdded;
        }


        
    }
}