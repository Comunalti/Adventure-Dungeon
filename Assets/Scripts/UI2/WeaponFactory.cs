using UnityEngine;

namespace DefaultNamespace.UI2
{
    public class WeaponFactory : MonoBehaviour
    {
        [SerializeField] private Energy energy;
        public GameObject Create(Weapon weapon)
        {
            if (weapon == null) return null;
            var instance = Instantiate(weapon.prefab, transform);
            instance.GetComponent<SimpleWeaponController>().energy = energy;
            return instance;
        }
    }
}