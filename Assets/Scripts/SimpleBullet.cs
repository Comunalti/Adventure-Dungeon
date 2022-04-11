using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SimpleBullet : MonoBehaviour
    {
        //public Vector3 _direction;
        public float speed = 1;
        // public void FireInDirection(Vector3 direction)
        // {
        //     print(direction);
        //     _direction = direction;
        // }

        private void Update()
        {
            transform.position = transform.position + transform.right* (Time.deltaTime * speed);
        }
    }
}