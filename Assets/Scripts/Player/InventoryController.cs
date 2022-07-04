using System;
using Entities;
using UnityEngine;
using Weapons.Controllers;

namespace Player
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private EntitySO owner;
        [SerializeField] private Energy energy;
        public event Action<GameObject> WeaponAddedEvent;
        
        public GameObject Add(GameObject prefab)
        {
            var clone = Instantiate(prefab, transform);
            clone.SetActive(false);
            var weaponController = clone.GetComponentInChildren<WeaponController>();
            weaponController.Initialize(energy,owner);
            WeaponAddedEvent?.Invoke(clone);
            return clone;
        }
        
    }
}