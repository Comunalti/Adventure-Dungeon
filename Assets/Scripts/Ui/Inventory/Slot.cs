using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Inventory
{
    public class Slot : MonoBehaviour
    {
        public Toggle toggle;

        public GameObject weaponConnected;
        public event Action<GameObject> WeaponConnectedChangedEvent;

        private void OnToggleChanged(bool arg0)
        {
            if (weaponConnected != null)
            {
                weaponConnected.SetActive(arg0);
            }
        }
        private void OnEnable()
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
        }
        private void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(OnToggleChanged);
        }
        
        public void SetPattern(GameObject instance)
        {
            weaponConnected = instance;
            WeaponConnectedChangedEvent?.Invoke(instance);
        }
    }
}