using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class WeaponCollector : MonoBehaviour
    {
        public InventoryController inventoryController;
        public event Action<GameObject> WeaponCollectedEvent;
        private void OnTriggerEnter2D(Collider2D col)
        {
            var collector = col.GetComponentInChildren<WeaponCollectable>();
            if (collector != null)
            {
                var weaponCollected = inventoryController.Add(collector.weaponPrefab);
                Destroy(collector.gameObject);
                WeaponCollectedEvent?.Invoke(weaponCollected);
            }
        }
    }
}