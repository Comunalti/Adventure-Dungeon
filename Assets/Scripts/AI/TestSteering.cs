using System;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.AI
{
    public class TestSteering : MonoBehaviour
    {
        public int resolution = 8;
        public SteeringBehavior _negatingSteeringBehavior;
        private float _distanceFactor = 1;
        [SerializeField] private bool aaaaa;

        private void Start()
        {
            _negatingSteeringBehavior = new SteeringBehavior(resolution);
        }

        private void Update()
        {
            RecalculateSteering();
        }

        void RecalculateSteering()
        {
            for (int i = 0; i < resolution; i++)
            {
                var direction = _negatingSteeringBehavior.LineSpaceToVector(i);
                var ray = new Ray2D(transform.position, direction);
                var raycastHit2D = Physics2D.Raycast(transform.position, direction);

                if (raycastHit2D.collider is null)
                {
                    continue;
                }
                
                print(i);
                var dist = raycastHit2D.distance;
                _negatingSteeringBehavior = _negatingSteeringBehavior + direction / (dist * _distanceFactor);
                
            }
        }


        private void OnDrawGizmosSelected()
        {
            if (!aaaaa)
            {
                return;
            }
            var scalars = _negatingSteeringBehavior.GetScalars;
            for (int i = 0; i < resolution; i++)
            {
                var direction = _negatingSteeringBehavior.LineSpaceToVector(i);

                Gizmos.DrawRay(transform.position,direction/scalars[i]);//
            }
        }
    }
}