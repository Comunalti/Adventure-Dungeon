using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Inventory
{
    public class InventoryNumberHotKeyController : MonoBehaviour
    {
        public ToggleGroup toggleGroup;

        private void OnEnable()
        {
            InputManager.Instance.NumberPressEvent += OnNumberPressedEvent;

        }

        private void OnNumberPressedEvent(int obj)
        {
            var index = (obj + 9) % 10;
            if (index>=0 && index<=2)
            {
                var child = transform.GetChild(index);
                //print(child.gameObject);
                var toggle = child.GetComponent<Toggle>();
                toggle.isOn = !toggle.isOn;
            }
        }

        private void OnDisable()
        {
            InputManager.Instance.NumberPressEvent -= OnNumberPressedEvent;
        }
    }
}