using System;
using Energy;
using Entities;
using UnityEngine;
using Weapons.Controllers;

namespace AI.Helpers
{
    public class EnemyWeaponInfoLoader : MonoBehaviour
    {

        public EntitySO entitySo;
        public EnergyController energyController;


        private void Start()
        {
            var componentsInChildren = GetComponentsInChildren<WeaponController>();

            foreach (var weaponController in componentsInChildren)
            {
                weaponController.Initialize(energyController,entitySo); 
            }
        }
    }
}