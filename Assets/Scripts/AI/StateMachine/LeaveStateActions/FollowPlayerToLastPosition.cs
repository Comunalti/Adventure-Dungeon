using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.LeaveStateActions
{
    [CreateAssetMenu(menuName = "State Machine/Enter State Action/Create FollowPlayerToLastPosition", fileName = "FollowPlayerToLastPosition", order = 0)]
    public class FollowPlayerToLastPosition : EnterStateAction
    {
        public override void Execute(BaseStateMachine baseStateMachine)
        {
            
            baseStateMachine.agent.SetDestination(baseStateMachine.targetHandler.GetFirstOpponentPosition());
        }
    }
}