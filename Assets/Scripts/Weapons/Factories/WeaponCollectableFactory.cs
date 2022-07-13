using Managers;
using Ui;
using Ui.Inventory;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Weapons.Factories
{
    public class WeaponCollectableFactory : MonoBehaviour
    {
        public GameObject weaponCollectablePrefab;
        public GameObject hotBar;
        public void DropActiveWeapons()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                if (child.gameObject.activeSelf)
                {
                    var weaponPrefab = child.gameObject;
                    
                    var clone = Instantiate(weaponCollectablePrefab, transform.position, Quaternion.identity);
                    clone.GetComponent<WeaponCollectable>().SetWeaponPrefab(weaponPrefab);

                    //if (weaponPrefab.scene.name == null) continue;
                    
                    weaponPrefab.transform.parent = null;
                    weaponPrefab.SetActive(false);

                    foreach (Transform child1 in hotBar.transform)
                    {
                        var slot = child1.GetComponent<Slot>();
                        if (slot.weaponConnected == weaponPrefab)
                        {
                            slot.SetPattern(null);
                        }
                    }
                }
            }
            
            
        }
    }
}