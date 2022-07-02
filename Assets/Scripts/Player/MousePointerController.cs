using System;
using Managers;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class MousePointerController : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Vector2 _currentPosition;
        public event Action<Vector3> MousePointerWorldPositionChangedEvent;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            
        }

        private void OnEnable()
        {
            InputManager.Instance.MouseMovedEvent += MovePointer;
        }

        private void MovePointer(Vector2 newPosition)
        {
            _currentPosition = newPosition;
            _rectTransform.position = newPosition;
            Vector3 position = (Vector2)Camera.main.ScreenToWorldPoint(newPosition);
            MousePointerWorldPositionChangedEvent?.Invoke(position);
            transform.position = position;
        }

        private void Update()
        {
            MovePointer(_currentPosition);
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