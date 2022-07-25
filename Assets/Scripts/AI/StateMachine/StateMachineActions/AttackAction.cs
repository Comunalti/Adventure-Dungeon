using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.StateMachineActions
{
    [CreateAssetMenu(menuName = "State Machine/Action/Create AttackAction", fileName = "AttackAction", order = 0)]
    public class AttackAction : StateMachineAction
    {
        public override void Execute(BaseStateMachine machine)
        {
            machine.gameObject.BroadcastMessage("Shoot",SendMessageOptions.RequireReceiver);
        }
    }
}