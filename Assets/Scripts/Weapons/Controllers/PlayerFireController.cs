using System;
using Managers;
using UnityEngine;

namespace Weapons.Controllers
{
    public class PlayerFireController : MonoBehaviour
    {
        private bool isPressing;
        
        private void OnEnable()
        {
            InputManager.Instance.MouseLeftClickEvent += OnFireEvent;
            InputManager.Instance.MouseLeftClickEndedEvent += OnEndFireEvent;
        }
        
        private void OnDisable()
        {
            InputManager.Instance.MouseLeftClickEvent -= OnFireEvent;
            InputManager.Instance.MouseLeftClickEndedEvent -= OnEndFireEvent;
            
            
        }

        private void OnFireEvent()
        {
            isPressing = true;
            gameObject.BroadcastMessage("Shoot",SendMessageOptions.DontRequireReceiver);
        }

        private void Update()
        {
            if (isPressing)
            {
                //print("is pressing");
                //gameObject.BroadcastMessage("ContinuousShoot",SendMessageOptions.DontRequireReceiver);
            }
        }

        private void OnEndFireEvent()
        {
            isPressing = false;
        }
    }
}