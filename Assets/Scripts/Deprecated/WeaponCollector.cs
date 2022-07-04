using System;
using UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Weapons
{
    
    public class WeaponCollector : MonoBehaviour
    {
        public HotbarInventoryHandler hotbarInventoryHandler;
        public HotbarItem hotbarItem;
        [SerializeField] private DropController dropController;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var added = hotbarInventoryHandler.AddItem(hotbarItem);
            if (added == false)
            {
                var selection = EventSystem.current.currentSelectedGameObject;
                if (selection)
                {
                    var hotbarSlot = selection.GetComponent<HotbarSlot>();
                    if (hotbarSlot)
                    {
                        var oldItem = hotbarSlot.SetItem(hotbarItem);
                        if (oldItem)
                        {
                            dropController.Drop(oldItem);
                        }
                    }
                }
            }
        }
    }

    public class DropController : MonoBehaviour
    {
        public GameObject itemDropPrefab;
        public Transform player;
        public void Drop(HotbarItem item)
        {
            var gameObj = Instantiate(itemDropPrefab,player.position,quaternion.identity);
            gameObj.SendMessage("SetItem",item);
            
        }
    }
}