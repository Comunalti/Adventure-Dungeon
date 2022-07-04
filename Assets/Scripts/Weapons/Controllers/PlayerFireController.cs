using System;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Weapons.Controllers
{
    public class PlayerFireController : MonoBehaviour
    {
        private bool isPressing;
        private bool isPointerOverGameObject;

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
            if (!isPointerOverGameObject)
            {
                isPressing = true;
                gameObject.BroadcastMessage("Shoot",SendMessageOptions.DontRequireReceiver);
            }
        }

        private void Update()
        {
            isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();

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