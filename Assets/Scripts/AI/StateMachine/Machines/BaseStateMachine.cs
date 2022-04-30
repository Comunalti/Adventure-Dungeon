using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.AI.StateMachine
{
    [RequireComponent(typeof(CharacterHandler),typeof(NavMeshAgent),typeof(PatrolHandler)),
     RequireComponent(typeof(TargetHandler))]
    public class BaseStateMachine : MonoBehaviour
    {
        public TargetHandler targetHandler;
        public CharacterHandler characterHandler;
        public NavMeshAgent agent;
        public PatrolHandler patrolHandler;
        
        
        [SerializeField]private BaseState _baseState;
        [SerializeField]private BaseState initialState;
        

        public event Action<BaseState> StateChangedEvent;
        private void Start()
        {
            targetHandler = GetComponent<TargetHandler>();
            characterHandler = GetComponent<CharacterHandler>();
            agent = GetComponent<NavMeshAgent>();
            patrolHandler = GetComponent<PatrolHandler>();
            
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