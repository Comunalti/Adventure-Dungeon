// using UnityEngine;
// using UnityEngine.UI;
//
// namespace DefaultNamespace.UI2
// {
//     [RequireComponent(typeof(Toggle),typeof(WeaponFrame))]
//     public class WeaponSelector : MonoBehaviour
//     {
//         private Toggle _toggle;
//         private WeaponFrame _weaponFrame;
//         private GameObject _weaponInstance;
//
//         private void Awake()
//         {
//             _toggle = GetComponent<Toggle>();
//             _weaponFrame = GetComponent<WeaponFrame>();
//         }
//
//         private void OnEnable()
//         {
//             _weaponFrame.WeaponChangedEvent += OnWeaponChanged;
//         }
//
//         private void OnDisable()
//         {
//             _weaponFrame.WeaponChangedEvent -= OnWeaponChanged;
//         }
//
//         private void OnWeaponChanged(Weapon weapon, GameObject weaponInstance)
//         {
//             _weaponInstance = weaponInstance;
//             if (weaponInstance == null)
//             {
//                 OnToggleChanged(false);
//             }
//         }
//
//
//         private void Start()
//         {
//             _toggle.onValueChanged.AddListener(OnToggleChanged);
//         }
//
//         public void OnToggleChanged(bool value)
//         {
//             if (_weaponInstance)
//             {
//                 _weaponInstance.SetActive(value);
//             }
//             else
//             {
//                 _toggle.isOn = false;
//             }
//         }
//     }
// }