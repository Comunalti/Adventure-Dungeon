using UnityEngine;

namespace DefaultNamespace.UI2
{
    public class WeaponFactory : MonoBehaviour
    {
        public GameObject Create(Weapon weapon)
        {
            if (weapon == null) return null;
            return Instantiate(weapon.prefab, transform);
        }
    }
}