using System;
using System.Collections;
using Energy;
using Health;
using Managers;
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
        private bool dashActive = false;
        private Vector2 inputDirection;
        private bool canCancelAnimation = false;

        private float currentAnimationTime = 0;
        public float dashSpeedScale = 1;
        public float dashTime;
        private Vector2 storedDirection;

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
            canCancelAnimation = true;
        }
        
        
        
        private void OnDashInput()
        {
            
            dashInput = true;
            canCancelAnimation = false;
            if (!dashActive && energy.Have(energyCost))
            {
                energy.RemoveCurrentEnergy(energyCost);
                storedDirection = inputDirection;
                dashActive = true;
                currentAnimationTime = 0;
                StartCoroutine(DoDash());
                StartCoroutine(Temporary());
            }
        }

        private IEnumerator Temporary()
        {
            yield return new WaitForSeconds(dashTime);
            SetCancelAnimation();
        }

        private IEnumerator DoDash()
        {
            while (dashActive)
            {
                rigidbody2D.velocity = storedDirection * playerSpeedProfile.Evaluate(currentAnimationTime) * dashSpeedScale;
                currentAnimationTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
        }

        private void OnStopDashInput()
        {
            dashInput = false;

            StartCoroutine(CancelAnimation());
        }

        private IEnumerator CancelAnimation()
        {
            yield return new WaitUntil(() => canCancelAnimation);
            dashActive = false;
            //animator.SetTrigger("CancelDash");
        }


        private void OnDirectionChanged(Vector2 obj)
        {
            inputDirection = obj;
        }
        
        private void OnEnable()
        {
            InputManager.Instance.DashEvent += OnDashInput;
            InputManager.Instance.DashStopEvent += OnStopDashInput;
            InputManager.Instance.DirectionChangedEvent += OnDirectionChanged;
        }
        

        private void OnDisable()
        {
            InputManager.Instance.DashEvent -= OnDashInput;
            InputManager.Instance.DashStopEvent -= OnStopDashInput;
            InputManager.Instance.DirectionChangedEvent -= OnDirectionChanged;


        }
    }
}