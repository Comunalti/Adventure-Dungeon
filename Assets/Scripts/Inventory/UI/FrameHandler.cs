using System;
using UnityEngine;

namespace DefaultNamespace.Inventory.UI
{
    [RequireComponent(typeof(ItemDropper))]
    public class FrameHandler : MonoBehaviour
    {
        public GameObject framePrefab;
        private ItemDropper _itemDropper;

        private void Awake()
        {
            _itemDropper = GetComponent<ItemDropper>();
        }

        public ItemFrame CreateFrame()
        {
            var o = Instantiate(framePrefab, transform);
            o.SendMessage("SetItemDropper",_itemDropper);
            return o.GetComponent<ItemFrame>();
        }
    }
}