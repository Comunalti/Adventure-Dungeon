using UnityEngine;

namespace DefaultNamespace.UI2
{
    public class WeaponFactory : MonoBehaviour
    {
        public GameObject Create(Weapon weapon)
        {
            return Instantiate(weapon.prefab, transform);
        }
    }
}