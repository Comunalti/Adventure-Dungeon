using Core;
using DefaultNamespace.Inventory.UI;
using UnityEngine;

namespace DefaultNamespace.Inventory
{
    public class SelectionHandler : LazySingleton<SelectionHandler>
    {
        [SerializeField] private Transform pivot;

        [SerializeField] private ItemFrame firstSelected; 
        [SerializeField] private ItemFrame currentItemFrameSelected;
        [SerializeField] private ItemSelector currentItemSelector;


        public ItemSelector GetCurrentItemSelector()
        {
            return currentItemSelector;
        }
        
        public void Select(ItemFrame itemFrame,ItemSelector itemSelector)
        {
            if (currentItemSelector)
            {
                Deselect(currentItemFrameSelected,currentItemSelector);
            }
            
            currentItemSelector = itemSelector;
            currentItemFrameSelected = itemFrame;
            var item = itemFrame.GetItem();
            if (item is null)
            { 
                return;   
            }
            Instantiate(item.weaponPrefab, pivot);
            itemSelector.ItemSelectedEvent?.Invoke();
        }

        public void Deselect(ItemFrame itemFrame, ItemSelector itemSelector)
        {
            currentItemSelector = null;
            currentItemFrameSelected = null;
            
            if (pivot.childCount == 0)
                return;
            Destroy(pivot.GetChild(0).gameObject);
            
            itemSelector.ItemDeselectedEvent?.Invoke();
        }

        public ItemFrame GetItemFrame()
        {
            return currentItemFrameSelected;
        }
    }
}