using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DefaultNamespace.Inventory.UI
{
    public class ItemSelector : MonoBehaviour
    {
        private ItemFrame _itemFrame;
        [SerializeField] private Item _item;

        public Action ItemSelectedEvent;
        public Action ItemDeselectedEvent;
        

        private void Awake()
        {
            _itemFrame = GetComponent<ItemFrame>();
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Interact);
        }


        private void OnEnable()
        {
            _itemFrame.ItemChangedEvent += OnItemChanged;
        }
        private void OnDisable()
        {
            _itemFrame.ItemChangedEvent -= OnItemChanged;
        }

        private void OnItemChanged(Item item)
        {
            _item = item;
        }


        [ContextMenu("interact")]
        private void Interact()
        {
            var selector = SelectionHandler.Instance.GetCurrentItemSelector();
            if (selector == this)
            {
                SelectionHandler.Instance.Deselect(_itemFrame,this);  
            }
            else
            {
                SelectionHandler.Instance.Select(_itemFrame,this);
            }
        }
    }
}
