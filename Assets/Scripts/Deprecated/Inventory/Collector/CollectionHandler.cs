// using System;
// using UnityEngine;
//
// namespace DefaultNamespace.Inventory.Collector
// {
//     public class CollectionHandler : MonoBehaviour
//     {
//         public Item item;
//         private void OnTriggerEnter2D(Collider2D other)
//         {
//             var selectionHandler = other.GetComponentInChildren<SelectionHandler>();
//             if (selectionHandler is null)
//                 return;
//
//             var itemFrame = selectionHandler.GetItemFrame();
//             if (itemFrame is null)
//             {
//                 itemFrame = Inventory.Instance.GetFirstOrEmptyItemFrame();
//             }
//             itemFrame.SetItem(item);
//         }
//     }
// }