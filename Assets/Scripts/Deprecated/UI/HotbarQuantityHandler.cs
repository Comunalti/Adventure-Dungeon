// using System;
// using System.Collections;
// using System.Linq;
// using UnityEngine;
//
// namespace UI
// {
//     public class HotbarQuantityHandler : MonoBehaviour
//     {
//     
//         [SerializeField] private int startingQuantity;
//         [SerializeField] private int currentQuantity;
//         [SerializeField] private int maxInventoryQuantity;
//     
//         public event Action<int> QuantityChangedEvent;
//     
//         private void Start()
//         {
//         
//         
//             SetQuantity(startingQuantity);
//         }
//
//         void SetQuantity(int newQuantity)
//         {
//             currentQuantity = newQuantity;
//             QuantityChangedEvent?.Invoke(currentQuantity);
//         }
//
//         void AddQuantity(int i)
//         {
//             var newQuantity = Mathf.Clamp(currentQuantity + i, 0, maxInventoryQuantity);
//             SetQuantity(newQuantity);
//         }
//
//         void RemoveQuantity(int i)
//         {
//             var newQuantity = Mathf.Clamp(currentQuantity - i, 0, maxInventoryQuantity);
//             SetQuantity(newQuantity);
//         }
//         [ContextMenu("Remove")]
//         void Remove()
//         {
//             RemoveQuantity(1);
//         }
//         [ContextMenu("Add")]
//         void Add()
//         {
//             AddQuantity(1);
//         }
//     }
// }