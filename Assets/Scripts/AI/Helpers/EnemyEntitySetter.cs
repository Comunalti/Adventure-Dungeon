using Entities;
using UnityEngine;

namespace AI.Helpers
{
    public class EnemyEntitySetter : MonoBehaviour
    {
        public EntitySO entitySo;
        private void Start()
        {
            GetComponent<Entity>().entitySO = entitySo;
        }
    }
}