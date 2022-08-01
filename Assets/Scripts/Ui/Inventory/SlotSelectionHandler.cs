using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Inventory
{
    public class SlotSelectionHandler : MonoBehaviour
    {
        public Toggle toggle;
        public Image image;
        public Sprite selectedSprite;
        public Sprite unSelectedSprite;

        private void Start()
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
            OnToggleChanged(toggle.isOn);
        }
        

        private void OnToggleChanged(bool arg0)
        {
            if (arg0)
            {
                image.sprite = selectedSprite;
            }else
            {
                image.sprite = unSelectedSprite;
            }
        }
    }
}