using UnityEngine;
using Weapons.Controllers;

namespace DefaultNamespace.UI2
{
    public class WeaponFactory : MonoBehaviour
    {
        [SerializeField] private Energy energy;
        public GameObject Create(Weapon weapon)
        {
            if (weapon == null) return null;
            var instance = Instantiate(weapon.prefab, transform);
            instance.GetComponent<WeaponController>().energy = energy;
            return instance;
        }
    }
}