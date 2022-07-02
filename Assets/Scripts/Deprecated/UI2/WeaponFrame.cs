using System;
using UnityEngine;

namespace DefaultNamespace.UI2
{
    public class WeaponFrame: MonoBehaviour
    {
        [SerializeField] private WeaponFactory weaponFactory;
        [SerializeField] private WeaponCollectableFactory weaponCollectableFactory;
        
        
        public event Action<Weapon,GameObject> WeaponChangedEvent;

        private Weapon _currentWeapon;
        private GameObject _weaponInstance;


        private void Awake()
        {
            weaponFactory = FindObjectOfType<WeaponFactory>();
        }

        public void SetWeapon(Weapon weapon)
        {
            if (_weaponInstance)
            {
                    weaponCollectableFactory.Create(_currentWeapon);
                Destroy(_weaponInstance);
            }
            _currentWeapon = weapon;
            _weaponInstance = weaponFactory.Create(_currentWeapon);
            WeaponChangedEvent?.Invoke(weapon,_weaponInstance);
        }

        public void RemoveWeapon()
        {
            // if (_weaponInstance)
            // {
            //     Destroy(_weaponInstance);
            // }
            // _currentWeapon = null;
            // WeaponChangedEvent?.Invoke(null,null);
            SetWeapon(null);
        }

        private void OnDestroy()
        {
            RemoveWeapon();
        }

        public bool IsEmpty()
        {
            return _currentWeapon is null;
        }
    }
}