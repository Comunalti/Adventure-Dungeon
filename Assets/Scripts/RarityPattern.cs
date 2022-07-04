using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Create RarityPattern", fileName = "RarityPattern", order = 0)]
    public class RarityPattern: ScriptableObject
    {
        public Sprite slotSprite;
    }
}