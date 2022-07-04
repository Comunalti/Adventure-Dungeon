using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    [RequireComponent(typeof(Slot))]
    public class SlotUI : MonoBehaviour
    {
        private Slot slot;
        private Image image;
        private void Awake()
        {
            slot = GetComponent<Slot>();
            image = GetComponent<Image>();
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
                image.sprite = obj.GetComponent<Image>().sprite;
            }
            else
            {
                image.sprite = null;
            }
        }

        
    }
}