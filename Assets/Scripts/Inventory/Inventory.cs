using System;
using System.Collections.Generic;
using Core;
using DefaultNamespace.Inventory.UI;
using UnityEngine;

namespace DefaultNamespace.Inventory
{
    [RequireComponent(typeof(FrameHandler))]
    public class Inventory : LazySingleton<Inventory>
    {
        public event Action InventorySizeChanged;

        [SerializeField] private List<ItemFrame> _itemFrames = new List<ItemFrame>();
        private FrameHandler _frameHandler;


        private void Awake()
        {
            _frameHandler = GetComponent<FrameHandler>();
            
        }

        private void Start()
        {
            SetQuantity(2);
        }

        void SetQuantity(int newSize)
        {
            var itemCount = _itemFrames.Count;
            if (newSize < itemCount)
            {
                var itemFrames = _itemFrames.GetRange(newSize-1, itemCount - 1);
                foreach (var itemFrame in itemFrames)
                {
                    itemFrame.SetItem(null);
                }
                _itemFrames.RemoveRange(newSize- 1,itemCount - 1);
            }

            if (newSize > itemCount)
            {
                for (int i = 0; i < newSize - itemCount; i++)
                {
                    var frame = _frameHandler.CreateFrame();
                    _itemFrames.Add(frame);
                }
            }
            
        }

        public ItemFrame GetFirstOrEmptyItemFrame()
        {
            var itemFrame = _itemFrames[0];

            foreach (var item in _itemFrames)
            {
                if (item.GetItem() is null)
                {
                    itemFrame = item;
                    break;
                }
            }

            return itemFrame;
        }
        
    }
}