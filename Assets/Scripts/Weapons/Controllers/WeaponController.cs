using System.Collections;
using Damage;
using Entities;



using UnityEngine;
using Weapons.ShootPatterns;
using Random = UnityEngine.Random;

namespace Weapons.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        
        [Min(0)]public float attackDelay = 0;
        [Min(0)]public float energyCost = 0;

        public Vector2 precisionRange;
        public AnimationCurve distribution;
        public Transform spawnPivot;

        public ShootPattern shootPattern;
        public RarityPattern rarityPattern;
        public GameObject bulletPrefab;

        [Header("dynamic variables")]
        public Energy energy;
        public EntitySO owner;

        public void Initialize(Energy energy, EntitySO owner)
        {
            this.energy = energy;
            this.owner = owner;
        }
        
        private bool canShoot = true;
        
        public float Precision => Mathf.Lerp(precisionRange.x,precisionRange.y,distribution.Evaluate(Random.value));
        
        private IEnumerator ResetCanShoot(float time)
        {
            yield return new WaitForSeconds(time);
            canShoot = true;
        }

        private void OnEnable()
        {
            canShoot = false;
            StartCoroutine(ResetCanShoot(attackDelay));
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        [ContextMenu("shoot")]
        public bool Shoot()
        {

            if (isActiveAndEnabled && canShoot && energy.Have(energyCost))
            {
                canShoot = false;
                energy.Remove(energyCost);
                StartCoroutine(shootPattern.Fire(this, bulletPrefab));
                StartCoroutine(ResetCanShoot(attackDelay));
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /*
         * attack speed ok
         * elemento ok
         * consumo de energia ok         * alcance(life time) ok
         * precisão ok
         * padrão de ataque ok
         * padrão de raridade ok
         * tipo de bala ok
         */
    }
}