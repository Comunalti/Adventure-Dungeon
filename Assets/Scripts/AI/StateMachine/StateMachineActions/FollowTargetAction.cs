using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.AI.StateMachine.StateMachineActions
{
    [CreateAssetMenu(menuName = "State Machine/Action/Create FollowTargetAction", fileName = "FollowTargetAction", order = 0)]
    public class FollowTargetAction : StateMachineAction
    {
        public override void Execute(BaseStateMachine machine)
        {
            machine.agent.SetDestination(machine.targetHandler.GetFirstOpponentPosition());
        }
    }
}