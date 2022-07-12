// using DefaultNamespace.UI2.Collection;
// using Unity.Mathematics;
// using UnityEngine;
//
// namespace DefaultNamespace.UI2
// {
//     public class WeaponCollectableFactory : MonoBehaviour
//     {
//         [SerializeField] private Transform playerRoot;
//         [SerializeField] private GameObject weaponCollectablePrefab;
//         [SerializeField] private GameObject mainFrame;
//
//         public void Create(Weapon currentWeapon)
//         {
//             var weaponCollectableInstance = Instantiate(weaponCollectablePrefab, playerRoot.position,quaternion.identity);
//             var weaponCollectable = weaponCollectableInstance.GetComponent<WeaponCollectable>();
//             if (weaponCollectable)
//             {
//                 weaponCollectable.SetWeapon(currentWeapon);
//                 weaponCollectable.mainFrame = mainFrame;
//             }
//         }
//     }
// }