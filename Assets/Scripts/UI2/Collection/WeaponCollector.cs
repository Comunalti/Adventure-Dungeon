using System;
using UnityEngine;

namespace DefaultNamespace.UI2.Collection
{
    public class WeaponCollector : MonoBehaviour
    {
        public GameObject mainFrame;
        public bool Collect(WeaponCollectable weaponCollectable)
        {
            foreach (Transform child in mainFrame.transform)
            {
                var weaponFrame = child.GetComponent<WeaponFrame>();
                if (weaponFrame.IsEmpty())
                {
                    weaponFrame.SetWeapon(weaponCollectable.weapon);
                    return true;
                }
            }

            return false;
        }
    }
}