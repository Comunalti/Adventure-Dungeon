// using System;
// using Managers;
// using UnityEngine;
// using UnityEngine.UI;
// using Quaternion = UnityEngine.Quaternion;
// using Vector3 = UnityEngine.Vector3;
//
//
// public class GunDropped : MonoBehaviour
// {
//     public GameObject gunPrefab;
//     public GameObject pivo;
//     public Collider2D playerCollider;
//     public HotbarGrid hotbarGrid;
//
//     private void Start()
//     {
//         if (!pivo)
//         {
//             pivo = GameObject.Find("Pivo");
//         }
//
//         if (!hotbarGrid)
//         {
//             hotbarGrid = GameObject.Find("HotbarFrame").GetComponent<HotbarGrid>();
//         }
//
//         playerCollider = pivo.transform.parent.GetComponent<Collider2D>();
//     }
//
//     private void AddGunToSlot()
//     {
//         if(hotbarGrid.has3Slots)
//         {
//             if (pivo.transform.childCount >= 3) return;
//         }
//         else
//         {
//             if (pivo.transform.childCount >= 4) return;
//         }
//         var gun = Instantiate(gunPrefab, pivo.transform);
//         gun.transform.localPosition = new Vector3(0.1f, 0.025f, -1);
//         gun.transform.rotation = Quaternion.identity;
//         gun.GetComponent<GunFunctions>().SelectThisGun();
//         gun.GetComponent<GunFunctions>().SelectSlotImage(GetComponent<SpriteRenderer>().sprite);
//         Destroy(gameObject);
//     }
//
//     private void OnTriggerEnter2D(Collider2D col)
//     {
//         if (col == playerCollider)
//             InputManager.Instance.EPressEvent += AddGunToSlot;
//         //print("entrou");
//     }
//
//     private void OnTriggerExit2D(Collider2D col)
//     {
//         if (col == playerCollider)
//             InputManager.Instance.EPressEvent -= AddGunToSlot;
//         //print("saiu");
//     }
// }
