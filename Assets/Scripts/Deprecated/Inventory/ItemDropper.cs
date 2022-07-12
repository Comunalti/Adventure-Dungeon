// using Unity.Mathematics;
// using UnityEngine;
//
// namespace DefaultNamespace.Inventory
// {
//     public class ItemDropper : MonoBehaviour
//     { 
//         [SerializeField] private GameObject collectorPrefab;
//         public void Drop(Item currentItem)
//         {
//             var o = Instantiate(collectorPrefab, Vector3.zero, quaternion.identity);
//             o.SendMessage("SetItem",currentItem);
//         }
//     }
// }