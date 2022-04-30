using System;
using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.StateMachineActions
{
    
    [CreateAssetMenu(menuName = "State Machine/Action/Create PatrolAction", fileName = "PatrolAction", order = 0)]
    public class PatrolAction : StateMachineAction 
    {
        [SerializeField] private float limit;

        public override void Execute(BaseStateMachine machine)
        {
            if (machine.agent.remainingDistance < limit)
            {
                var nextPosition = machine.patrolHandler.GetNextPosition();
                machine.agent.SetDestination(nextPosition);
            }
        }
    }
}