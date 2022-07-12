using UnityEngine;
using UnityEngine.UI;

namespace Ui.Inventory
{
    [RequireComponent(typeof(Slot))]
    public class SlotUI : MonoBehaviour
    {
        private Slot slot;
        public Image image;
        public Sprite defaultSprite;
        private void Awake()
        {
            slot = GetComponent<Slot>();
            OnWeaponConnectedChanged(slot.weaponConnected);
        }

        private void OnEnable()
        {
            slot.WeaponConnectedChangedEvent += OnWeaponConnectedChanged;
        }
        
        private void OnDisable()
        {
            slot.WeaponConnectedChangedEvent -= OnWeaponConnectedChanged;

        }

        private void OnWeaponConnectedChanged(GameObject obj)
        {
            if (obj != null)
            {
                image.sprite = obj.GetComponentInChildren<SpriteRenderer>().sprite;
            }
            else
            {
                image.sprite = defaultSprite;
            }
        }

        
    }
}