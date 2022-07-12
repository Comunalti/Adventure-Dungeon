using Managers;
using UnityEngine;

namespace Ui
{
    public class ProximityInfoPromptHandler : MonoBehaviour
    {
        public ProximityObserver proximityObserver;
        public GameObject collectPrompt;
        public GameObject infoPrompt;
        private void OnSelectingEvent()
        {
            InputManager.Instance.AltChangedEvent += RefreshPrompt;
            
            RefreshPrompt(InputManager.Instance.controlMap.KeyboardMap.AltPressAction.IsPressed());
        }

        private void OnUnSelectingEvent()
        {
            InputManager.Instance.AltChangedEvent -= RefreshPrompt;
            
            collectPrompt.SetActive(false);
            infoPrompt.SetActive(false);
        }

        
        private void RefreshPrompt(bool altPressed)
        {
            if (altPressed)
            {
                collectPrompt.SetActive(false);
                infoPrompt.SetActive(true);
            }
            else
            {
                collectPrompt.SetActive(true);
                infoPrompt.SetActive(false);
            }
        }


       
        private void OnEnable()
        {
            proximityObserver.ProximityControllerSelectedEvent += OnSelectingEvent;
            proximityObserver.ProximityControllerUnSelectedEvent += OnUnSelectingEvent;
        }

        private void OnDisable()
        {
            proximityObserver.ProximityControllerSelectedEvent -= OnSelectingEvent;
            proximityObserver.ProximityControllerUnSelectedEvent -= OnUnSelectingEvent;
        }
    }
}