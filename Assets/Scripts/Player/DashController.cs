using System;
using System.Collections;
using Energy;
using Health;
using Managers;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class DashController : MonoBehaviour
    {
        public HealthController healthController;
        public Rigidbody2D rigidbody2D;
        public Animator animator;
        
        public AnimationCurve playerSpeedProfile;

        public EnergyController energy;
        public float energyCost;
        
        private bool dashInput = false;
        public bool dashActive = false;
        private Vector2 inputDirection;

        private float currentAnimationTime = 0;
        public float dashSpeedScale = 1;
        public float dashTime;
        private Vector2 storedDirection;

        public GameObject playerShadowPrefab;
        public Transform playerShadowSpawnTransform;

        public void EnterInvincibleFrame()
        {
            healthController.isInvincible = true;
        }

        public void LeaveInvincibleFrame()
        {
            healthController.isInvincible = false;

        }
        

        public void SetCancelAnimation()
        {
            dashActive = false;
        }
        
        
        
        private void OnDashInput()
        {
            
            dashInput = true;
            if (!dashActive && energy.Have(energyCost))
            {
                energy.RemoveCurrentEnergy(energyCost);
                storedDirection = inputDirection;
                dashActive = true;
                currentAnimationTime = 0;
                DoDash();
                //StartCoroutine(Temporary());
            }
        }

        private void Update()
        {
            
            if (dashActive)
            {
                rigidbody2D.velocity = storedDirection * playerSpeedProfile.Evaluate(currentAnimationTime) * dashSpeedScale;
                currentAnimationTime += Time.deltaTime;
            } 
        }

        private void DoDash()
        {
            animator.Play("Dash");
            
        }
        
        [ContextMenu("Spawn Shadow")]
        public void SpawnShadow()
        {
            var instance = Instantiate(playerShadowPrefab, playerShadowSpawnTransform.position, quaternion.identity);
            instance.GetComponent<SpriteRenderer>().sprite = playerShadowPrefab.GetComponent<SpriteRenderer>().sprite;
        }
        // private void OnStopDashInput()
        // {
        //     dashInput = false;
        //
        //     StartCoroutine(CancelAnimation());
        // }

        // private IEnumerator CancelAnimation()
        // {
        //     yield return new WaitUntil(() => canCancelAnimation);
        //     dashActive = false;
        //     //animator.SetTrigger("CancelDash");
        // }


        private void OnDirectionChanged(Vector2 obj)
        {
            inputDirection = obj;
        }
        
        private void OnEnable()
        {
            InputManager.Instance.DashEvent += OnDashInput;
            //InputManager.Instance.DashStopEvent += OnStopDashInput;
            InputManager.Instance.DirectionChangedEvent += OnDirectionChanged;
        }
        

        private void OnDisable()
        {
            InputManager.Instance.DashEvent -= OnDashInput;
            //InputManager.Instance.DashStopEvent -= OnStopDashInput;
            InputManager.Instance.DirectionChangedEvent -= OnDirectionChanged;


        }
    }
}