using System;
using Managers;
using Ui;
using UnityEngine;

namespace Player.Animation
{
    public class FootSpawnerParticles : MonoBehaviour
    {
        public PlayerMovementController playerMovementController;
        
        public bool isWalking = false;
        public GameObject smokePrefab;
        public Transform footPivot;
        public float timeDelay;
        private float currentTime;
        
        public void SpawnSmoke()
        {
            Instantiate(smokePrefab, footPivot.position,Quaternion.identity);
        }

        private void Update()
        {
            if (isWalking)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                currentTime = timeDelay;
            }
            if (currentTime <= 0)
            {
                currentTime = timeDelay;
                SpawnSmoke();
            }
        }

        private void OnWalkingChanged(bool isWalking)
        {
            this.isWalking = isWalking;
        }
        
        private void OnEnable()
        {
            playerMovementController.WalkingChangedEvent += OnWalkingChanged;
        }
        
        private void OnDisable()
        {
            playerMovementController.WalkingChangedEvent -= OnWalkingChanged;
        }
    }
}