using System;
using Managers;
using Player;
using Ui;
using UnityEngine;
using Weapons.Factories;

namespace Weapons
{
    public class WeaponCollector : MonoBehaviour
    {
        public InventoryController inventoryController;
        public WeaponCollectableFactory weaponCollectableFactory;
        private ProximityObserver proximityObserver;
        
        public event Action<GameObject> WeaponCollectedEvent;

        private void OnEPressed()
        {
            if (proximityObserver != null)
            {
                
                var collectable = proximityObserver.GetComponent<WeaponCollectable>();
                if (collectable)
                { 
                    weaponCollectableFactory.DropActiveWeapons();
                    var instance = collectable.GetClone();
                    inventoryController.Add(instance);
                    Destroy(proximityObserver.gameObject);
                    WeaponCollectedEvent?.Invoke(instance);
                }
            }
        }

        private void OnEnable()
        {
            InputManager.Instance.EPressEvent += OnEPressed;
            ProximityObserver.ProximityControllerChangedEvent += OnProximityControllerChanged;
        }

        private void OnDisable()
        {
            InputManager.Instance.EPressEvent -= OnEPressed;
            ProximityObserver.ProximityControllerChangedEvent -= OnProximityControllerChanged;
        }

        private void OnProximityControllerChanged(ProximityObserver obj)
        {
            proximityObserver = obj;
        }
    }
}