using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.AI.StateMachine.StateMachineActions
{
    [CreateAssetMenu(menuName = "State Machine/Action/Create NotMoveAction", fileName = "NotMoveAction", order = 0)]
    public class NotMoveAction : StateMachineAction
    {
        public override void Execute(BaseStateMachine machine)
        {
            machine.GetComponent<NavMeshAgent>().ResetPath();
        }
    }
}