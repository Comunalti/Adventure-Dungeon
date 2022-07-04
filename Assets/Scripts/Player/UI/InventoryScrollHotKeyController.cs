using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    public class InventoryScrollHotKeyController : MonoBehaviour
    {

        public ToggleGroup toggleGroup;
        
        private void OnEnable()
        {
            InputManager.Instance.WheelScrolledEvent += OnWheelScrolled;
        }

        private void OnWheelScrolled(bool obj)
        {
            var firstActiveToggle = toggleGroup.GetFirstActiveToggle();

            if (firstActiveToggle != null)
            {
                var siblingIndex = firstActiveToggle.transform.GetSiblingIndex();
                var childCount = transform.childCount;
                var nextIndex = (siblingIndex + (obj ? 1 : -1) + childCount) % childCount;
                //print(nextIndex);
                transform.GetChild(nextIndex).GetComponent<Toggle>().isOn = true;
            }
            else
            {
                Debug.LogWarning("hotabr no toggle selected, expected toggle always selected");
            }
        }

        private void OnDisable()
        {
            InputManager.Instance.WheelScrolledEvent += OnWheelScrolled;

        }
    }
}