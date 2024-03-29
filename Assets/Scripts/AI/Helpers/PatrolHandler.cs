using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.AI.StateMachine
{
    public class PatrolHandler : MonoBehaviour
    {
        public float radius;
        public int pointCount;

        public Vector3[] points;


        private void Awake()
        {
            points = new Vector3[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                points[i] = (Vector2)transform.position + new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f))*radius;
                
            }
        }

        private int _current = 0;
        public Vector3 GetNextPosition()
        {
            _current++;
            _current %= pointCount;
            return points[_current];
        }


        private void OnDrawGizmosSelected()
        {
            if (points.Length != pointCount )
            {
                return;
            }
            for (int i = 0; i < pointCount; i++)
            {
                //points[i] = Handles.DoPositionHandle(points[i],quaternion.identity);
            }
            
            //Handles.DrawPolyLine(points);
        }
    }
}