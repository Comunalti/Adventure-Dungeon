using System;
using UnityEngine;

namespace Weapons.UI
{
    public class WeaponCollectableUiRefresh : MonoBehaviour
    {
        public WeaponCollectable weaponCollectable;
        public SpriteRenderer spriteRenderer;
        private void OnEnable()
        {
            weaponCollectable.WeaponPrefabChangedEvent += OnWeaponChanged;
            
        }

        private void OnDisable()
        {
            weaponCollectable.WeaponPrefabChangedEvent -= OnWeaponChanged;
        }

        private void OnWeaponChanged(GameObject obj)
        {
            //print("opa");
            var renderer = obj.GetComponentInChildren<SpriteRenderer>();
            
            spriteRenderer.sprite = renderer.sprite;
            spriteRenderer.color = renderer.color;
        }

        private void Start()
        {
            OnWeaponChanged(weaponCollectable.weaponPrefab);
        }
    }
}