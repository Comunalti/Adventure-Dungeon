using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.AI
{
    [Serializable]
    public struct SteeringBehavior
    {
        [SerializeField]private int _size;
        [SerializeField]private float _angle;
        [SerializeField]private float[] _scalars;

        public float[] GetScalars => _scalars;
        
        public void Clamp(float min,float max)
        {
            for (int i = 0; i < _size; i++)
            {
                _scalars[i] = Mathf.Clamp(_scalars[i], min, max);
            }
        }
        
        public Vector2 MaxGridVector()
        {
            int maxI = 0;
            float maxValue = _scalars[0];
            
            for (int i = 1; i < _size; i++)
            {
                var newValue = _scalars[i];
                if (maxValue<maxValue)
                {
                    maxValue = newValue;
                    maxI = i;
                }
            }

            return LineSpaceToVector(maxI)*maxValue;
        }

        public static SteeringBehavior operator +(SteeringBehavior a, SteeringBehavior b)
        {
            if (a._size != b._size)
            {
                Debug.LogError("not the same size");
            }

            var newSteering = new SteeringBehavior(a._size);
            for (int i = 0; i < newSteering._size; i++)
            {
                newSteering._scalars[i] = a._scalars[i] + b._scalars[i];
            }

            return newSteering;
        }
        
        public static SteeringBehavior operator -(SteeringBehavior a, SteeringBehavior b)
        {
            if (a._size != b._size)
            {
                Debug.LogError("not the same size");
            }

            var newSteering = new SteeringBehavior(a._size);
            for (int i = 0; i < newSteering._size; i++)
            {
                newSteering._scalars[i] = a._scalars[i] - b._scalars[i];
            }

            return newSteering;
        }

        public static SteeringBehavior operator +(SteeringBehavior a, Vector2 b)
        {
            for (int i = 0; i < a._size; i++)
            {
                a._scalars[i] += a.VectorToLineSpace(i,b);
            }

            return a;
        }

        public static SteeringBehavior operator -(SteeringBehavior a, Vector2 b)
        {
            for (int i = 0; i < a._size; i++)
            {
                a._scalars[i] -= a.VectorToLineSpace(i,b);
            }

            return a;
        }
        public SteeringBehavior(int size)
        {
            if (size<=0)
            {
                Debug.LogError("size not valid");
            }

            this._size = size;
            _scalars = new float[size];

            _angle = Mathf.PI * (2f / size);
        }

        

        public float VectorToLineSpace(int index,Vector2 vector)
        {
            var angle2 = this._angle * index;
            var lenght = vector.magnitude;
            var direction = new Vector2(Mathf.Cos(angle2), Mathf.Sin(angle2)).normalized;
            
            return UnityEngine.Vector2.Dot(vector,direction)*lenght;
        }
        public Vector2 LineSpaceToVector(int index)
        {
            // Debug.Log($"size: { _size}");
            // Debug.Log(index);
            if (index<0f || index>=_size)
            {
                Debug.LogError("out of limit");
            }
            
            //var power = _scalars[index];
            var angle2 = this._angle * index;
            var direction = new Vector2(Mathf.Cos(angle2), Mathf.Sin(angle2));

            return direction;
        }
    }
}