using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Weapons
{
    public class WeaponCollectable : MonoBehaviour
    {
        public GameObject weaponPrefab;
        public event Action<GameObject> WeaponPrefabChangedEvent;
        public void SetWeaponPrefab(GameObject prefab)
        {
            weaponPrefab = prefab;
            WeaponPrefabChangedEvent?.Invoke(prefab);
        }

        public GameObject GetClone()
        {
            if (weaponPrefab.scene.name is null)
                return Instantiate(weaponPrefab);
            else
                return weaponPrefab;
        }
    }
}