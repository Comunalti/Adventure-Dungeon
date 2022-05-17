using UnityEngine;

namespace DefaultNamespace.Inventory
{
    [CreateAssetMenu(fileName = "new Hotbar Item", menuName = "Create Hotbar Item", order = 0)]
    public class Item : ScriptableObject
    {
        public GameObject weaponPrefab;
    }
}