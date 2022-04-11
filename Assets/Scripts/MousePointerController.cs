using System;
using Managers;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class MousePointerController : MonoBehaviour
    {
        public event Action<Vector3> MousePointerWorldPositionChangedEvent;
        private void OnEnable()
        {
            InputManager.Instance.MouseMovedEvent += MovePointer;
        }

        private void MovePointer(Vector2 newPosition)
        {
            Vector3 position = (Vector2)Camera.main.ScreenToWorldPoint(newPosition);
            MousePointerWorldPositionChangedEvent?.Invoke(position);
            transform.position = position;
        }
        
        private void OnDisable()
        {
            InputManager.Instance.MouseMovedEvent -= MovePointer;
        }
        

        private void OnBecameVisible()
        {
            Cursor.visible = false;
        }

        private void OnBecameInvisible()
        {
            Cursor.visible = true;
        }
    }
}