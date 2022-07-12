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
            print("E");
            if (proximityObserver != null)
            {
                
                var collectable = proximityObserver.GetComponent<WeaponCollectable>();
                print(collectable);
                print("collectable foi");
                if (collectable)
                { 
                    print("BBBBBB");
                    print(weaponCollectableFactory);
                    weaponCollectableFactory.DropActiveWeapons();
                    print("CCCCC");
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