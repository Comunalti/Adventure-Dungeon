using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.AI.StateMachine.StateMachineActions
{
    [CreateAssetMenu(menuName = "State Machine/Action/Create MoveUpAction", fileName = "MoveUpAction", order = 0)]
    public class FollowTargetAction : StateMachineAction
    {
        public override void Execute(BaseStateMachine machine)
        {
            machine.GetComponent<NavMeshAgent>().SetDestination(machine.targetHandler.target.transform.position);
        }
    }
}