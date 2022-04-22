using System;
using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    public class BaseStateMachine : MonoBehaviour
    {
        public TargetHandler targetHandler;
        
        [SerializeField]private BaseState _baseState;
        [SerializeField] private BaseState initialState;
        public CharacterHandler characterHandler;

        public event Action<BaseState> StateChangedEvent;
        private void Start()
        {
            Set(initialState);
        }

        public void Set(BaseState newState)
        {
            if (newState == _baseState)
                return;
            
            _baseState = newState;
            
            StateChangedEvent?.Invoke(newState);
        }

        private BaseState Get()
        {
            return _baseState;
        }
        
        private void Update()
        {
            if (_baseState != null)
            {
                _baseState.Execute(this);
            }
        }
    }
}