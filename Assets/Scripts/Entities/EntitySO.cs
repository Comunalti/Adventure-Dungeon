using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once InconsistentNaming

namespace Entities
{
    [CreateAssetMenu(menuName = "Create Entity", fileName = "New Entity", order = 0)]
    public class EntitySO: ScriptableObject
    {
        public string entityType;
        public List<EntitySO> notAttackList;

        public bool DoesNotAttack(EntitySO entitySo)
        {
            return notAttackList.Contains(entitySo);
        }
    }
}