using System;
using DefaultNamespace.UI2;
using DefaultNamespace.UI2.Collection;
using UnityEngine;

namespace UI2.Collection
{
    [RequireComponent(typeof(WeaponCollectable))]
    public class WeaponCollectableImageUpdate : MonoBehaviour
    {
        private WeaponCollectable _weaponCollectable;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _weaponCollectable = GetComponent<WeaponCollectable>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _weaponCollectable.WeaponChangedEvent += OnWeaponChanged;
        }
        
        
        private void OnDisable()
        {
            _weaponCollectable.WeaponChangedEvent -= OnWeaponChanged;
        }

        private void Start()
        {
            OnWeaponChanged(_weaponCollectable.weapon);
        }

        private void OnWeaponChanged( Weapon weapon)
        {
            if (weapon is null)
            {
                _spriteRenderer.sprite = null;
                return;
            }
            _spriteRenderer.sprite = weapon.sprite;
        }
    }
}