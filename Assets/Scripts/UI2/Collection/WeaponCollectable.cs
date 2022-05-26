using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI2.Collection
{
    [RequireComponent(typeof(Collider2D))]
    public class WeaponCollectable : MonoBehaviour
    {
        public Weapon weapon;
        public GameObject mainFrame;

        private WeaponCollector _cacheCollector;
        private NumberSlotChanger _numberSlotChanger;
        public event Action<Weapon> WeaponChangedEvent;

        public void SetWeapon(Weapon weapon)
        {
            this.weapon = weapon;
            WeaponChangedEvent?.Invoke(weapon);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            _cacheCollector = other.GetComponentInChildren<WeaponCollector>();
            _numberSlotChanger = mainFrame.GetComponent<NumberSlotChanger>();
            if (_cacheCollector)
            {
                var collected = _cacheCollector.Collect(this);
                _numberSlotChanger.SetSlotNumber(mainFrame.transform.childCount + 1);
                if (collected)
                {
                    Destroy(gameObject);
                }
                else
                {
                    InputManager.Instance.EPressEvent += Collect;
                }
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            var collector = other.GetComponentInChildren<WeaponCollector>();
            if (collector)
            {
                InputManager.Instance.EPressEvent -= Collect;
            }
        }

        private void Collect()
        {
            print("era pra trocar com a arma q ta segurando");
            GameObject selected = null;
            foreach (Transform child in mainFrame.transform)
            {
                var toggle = child.GetComponent<Toggle>();
                if (toggle)
                {
                    if (toggle.isOn)
                    {
                        selected = child.gameObject;
                    }
                }
            }
            if (selected != null)
            {
                selected.GetComponent<WeaponFrame>().SetWeapon(weapon);
                selected.GetComponent<WeaponSelector>().OnToggleChanged(true);
                Destroy(gameObject);
            }
            else
            {
                print("no weapon selected to change");
            }
        }
    }
}