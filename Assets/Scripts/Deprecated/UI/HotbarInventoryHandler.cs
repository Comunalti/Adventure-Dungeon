// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace UI
// {
//     public class HotbarInventoryHandler : MonoBehaviour
//     {
//         [SerializeField] private HotbarQuantityHandler hotbarQuantityHandler;
//
//         [SerializeField] private GameObject itemFramePrefab;
//         [SerializeField] private GameObject pivot;
//
//         private int _currentCapacity;
//     
//     
//         [SerializeField] private List<HotbarSlot> _frames = new List<HotbarSlot>();
//         [SerializeField] private List<HotbarItem> _hotbarItems = new List<HotbarItem>();
//         private event Action<int> QuantityChangedEvent;
//
//
//         private void Start()
//         {
//         
//         
//         
//         }
//
//         public void CleanHotBarInventory()
//         {
//             foreach (Transform child in transform)
//             {
//                 Destroy(child.gameObject);
//             }
//         }
//     
//     
//         private void OnEnable()
//         {
//             hotbarQuantityHandler.QuantityChangedEvent += OnHotbarCapacityChanged;
//         }
//
//         private void OnDisable()
//         {
//             hotbarQuantityHandler.QuantityChangedEvent -= OnHotbarCapacityChanged;
//         }
//
//         private void OnHotbarCapacityChanged(int newQuantity)
//         {
//             _frames.Clear();
//             CleanHotBarInventory();
//             _currentCapacity = newQuantity;
//         
//             for (int i = 0; i < newQuantity; i++)
//             {
//                 GameObject o = Instantiate(itemFramePrefab, transform);
//                 var hotbarSlot = o.GetComponent<HotbarSlot>();
//                 hotbarSlot.Inject(pivot);
//                 _frames.Add(hotbarSlot);
//             }
//
//             // if (newQuantity == _hotbarItems.Count)
//             // {
//             //     
//             // }
//             //
//             // if (newQuantity > _hotbarItems.Count)
//             // {
//             //     
//             // }
//
//             if (newQuantity < _hotbarItems.Count)
//             {
//                 var rangeSize = _hotbarItems.Count - newQuantity;
//                 var index = newQuantity;
//
//                 var range = _hotbarItems.GetRange(index, rangeSize);
//                 Drop(range);
//                 _hotbarItems.RemoveRange(index,rangeSize);
//             
//             }
//         
//             for (int i = 0; i < _hotbarItems.Count; i++)
//             {
//                 _frames[i].SetItem(_hotbarItems[i]);
//             }
//         }
//
//         public bool AddItem(HotbarItem hotbarItem)
//         {
//             if (_currentCapacity <= _hotbarItems.Count)
//             {
//                 return false;
//             }
//             _frames[_hotbarItems.Count].SetItem(hotbarItem);
//             _hotbarItems.Add(hotbarItem);
//             
//             QuantityChangedEvent?.Invoke(_hotbarItems.Count);
//             return true;
//         }
//         
//         private void Drop(List<HotbarItem> range)
//         {
//             foreach (var hotbarItem in range)
//             {
//                 print($"drop: {hotbarItem.name}");
//             }
//         }
//     }
// }