// using System;
// using UnityEngine;
//
// namespace DefaultNamespace.Inventory.UI
// {
//     public class ItemFrame : MonoBehaviour
//     {
//         public event Action<Item> ItemChangedEvent;
//         private ItemDropper _itemDropper;
//         
//         [SerializeField] private Item currentItem;
//
//         public void SetItemDropper(ItemDropper itemDropper)
//         {
//             _itemDropper = itemDropper;
//         }
//         public void SetItem(Item item)
//         {
//             if (currentItem != null)
//             {
//                 _itemDropper.Drop(currentItem);
//             }
//
//             currentItem = item;
//             
//             ItemChangedEvent?.Invoke(item);
//         }
//
//
//         public Item GetItem()
//         {
//             return currentItem;
//         }
//     }
// }