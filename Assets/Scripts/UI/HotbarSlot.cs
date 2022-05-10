using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class HotbarSlot : MonoBehaviour, IPointerClickHandler
    {
        private Image _image;
        private Button _button;
        private HotbarItem _hotbarItem;
        private GameObject _pivot;
        [SerializeField] private GameObject weapon;

        public event Action<HotbarItem> HotbarItemChangedEvent;
        private void Start()
        {
            _image = GetComponentInChildren<Image>();
            _button = GetComponentInChildren<Button>();
        }
        
        
        public void Inject(GameObject pivot)
        {
            _pivot = pivot;
        }

        public void SetItem(HotbarItem hotbarItem,bool sendMessage = true)
        {
            print("socorro");
            _hotbarItem = hotbarItem;
            if (sendMessage)
            {
                HotbarItemChangedEvent?.Invoke(hotbarItem); 
            }

            if (weapon != null)
            {
                Destroy(weapon); 
            }

            if (hotbarItem != null)
            {
                weapon = hotbarItem.Create(_pivot);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            foreach (Transform pivotChild in _pivot.transform)
            {
                pivotChild.gameObject.SetActive(false);
            }

            if (weapon)
                weapon.SetActive(true);
        }
    }
}