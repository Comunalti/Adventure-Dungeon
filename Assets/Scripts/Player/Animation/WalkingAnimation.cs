using System;
using UnityEngine;

namespace Player.Animation
{
    public class WalkingAnimation : MonoBehaviour
    {
        public Animator animator;
        public PlayerMovementController playerMovementController;

        private void OnEnable()
        {
            playerMovementController.WalkingChangedEvent += OnWalkingChanged;

        }
        private void OnDisable()
        {
            playerMovementController.WalkingChangedEvent -= OnWalkingChanged;
        }
        private void OnWalkingChanged(bool obj)
        {
            if (obj)
            {
                animator.speed = 1;
                //animator.Play("Walking"); 
            }
            else
            {          
                animator.speed = 0;
                //animator.Play("idle");
            }
            
        }

        
        
        
    }
}