using System;
using UnityEngine;
using UnityEngine.Events;

namespace Ui
{
    [RequireComponent(typeof(Collider2D))]
    public class ProximityObserver : MonoBehaviour
    {
        private static ProximityObserver _currentActive;
        public static event Action<ProximityObserver> ProximityControllerChangedEvent;
        
        public event Action ProximityControllerSelectedEvent;
        public event Action ProximityControllerUnSelectedEvent;

        private void Set(ProximityObserver proximityObserver)
        {
            if (_currentActive == proximityObserver)
                return;

            if (_currentActive != null) 
                _currentActive.ProximityControllerUnSelectedEvent?.Invoke();

            _currentActive = proximityObserver;
            
            if (_currentActive != null) 
                _currentActive.ProximityControllerSelectedEvent?.Invoke();

            ProximityControllerChangedEvent?.Invoke(_currentActive);
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Set(this);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_currentActive == null)
            {
                Set(this);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (_currentActive == this)
                {
                    Set(null);
                }
            }
        }
    }
}