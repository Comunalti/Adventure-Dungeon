using System;
using System.Collections.Generic;
using Core;
using Health;
using Unity.Mathematics;
using UnityEngine;

namespace Entities
{
    public class EntityLootDropper : MonoBehaviour
    {
        public HealthController healthController;
        public List<GameObject> prefab;

        private void OnEnable()
        {
            healthController.DeathEvent += OnDeathEvent;
        }

        private void OnDisable()
        {
            healthController.DeathEvent -= OnDeathEvent;

        }

        private void OnDeathEvent()
        {
            Instantiate(prefab.GetRandom(), transform.position, Quaternion.identity);
        }
    }
}