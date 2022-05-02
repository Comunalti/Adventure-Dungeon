using System;
using AI.StateMachine.Machines;
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
        public TimerHandler timerHandler;

        
        [SerializeField]private BaseState _baseState;
        [SerializeField]private BaseState initialState;


        public event Action<BaseState> StateChangedEvent;
        private void Start()
        {
            targetHandler = GetComponent<TargetHandler>();
            characterHandler = GetComponent<CharacterHandler>();
            agent = GetComponent<NavMeshAgent>();
            patrolHandler = GetComponent<PatrolHandler>();
            timerHandler = GetComponent<TimerHandler>();
            
            Set(initialState);
        }

        public void Set(BaseState newState)
        {
            if (newState == _baseState)
                return;

            if (_baseState != null)
                _baseState.LeaveState(this);
            
            _baseState = newState;
            
            if (newState != null)
                newState.EnterState(this);
            
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