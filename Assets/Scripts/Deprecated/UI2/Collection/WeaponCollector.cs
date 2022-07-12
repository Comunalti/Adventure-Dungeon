// using System;
// using UnityEngine;
//
// namespace DefaultNamespace.UI2.Collection
// {
//     [Obsolete("use the other weapon controller",true)]
//     public class WeaponCollector : MonoBehaviour
//     {
//         public GameObject mainFrame;
//         public bool Collect(WeaaponCollectable weaponCollectable)
//         {
//             foreach (Transform child in mainFrame.transform)
//             {
//                 var weaponFrame = child.GetComponent<WeaponFrame>();
//                 if (weaponFrame.IsEmpty())
//                 {
//                     weaponFrame.SetWeapon(weaponCollectable.weapon);
//                     return true;
//                 }
//             }
//
//             return false;
//         }
//     }
// }