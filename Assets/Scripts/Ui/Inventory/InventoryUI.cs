using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Ui.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public InventoryController inventoryController;

        public List<Slot> slots;
        private void OnWeaponAdded(GameObject obj)
        {
            var slotSelected = GetSlotSelected();

            if (slotSelected)
            {
                slotSelected.SetPattern(obj);
            }
            else
            {
                Debug.LogWarning("No slot selected");
            }
        }

        private Slot GetSlotSelected()
        {
            return slots.Find((slot => slot.toggle.isOn == true));  
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