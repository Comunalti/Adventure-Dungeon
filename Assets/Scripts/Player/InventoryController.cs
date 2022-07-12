using System;
using Energy;
using Entities;
using UnityEngine;
using Weapons.Controllers;

namespace Player
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private EntitySO owner;
        [SerializeField] private EnergyController energy;
        public event Action<GameObject> WeaponAddedEvent;
        
        public GameObject Add(GameObject clone)
        {
            clone.transform.parent = transform;
            clone.transform.localPosition = Vector3.zero;
            clone.transform.localRotation = Quaternion.identity;
            clone.SetActive(true);
            var weaponController = clone.GetComponentInChildren<WeaponController>();
            weaponController.Initialize(energy,owner);
            WeaponAddedEvent?.Invoke(clone);
            return clone;
        }
        
    }
}