using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create Opponent Near", fileName = "OpponentNear", order = 0)]
    public class OpponentNear : Decision
    {
        public float distanceLimit;
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var opponent = stateMachine.targetHandler.GetClosestOpponent();
            if (opponent != null)
            {
                float distance = stateMachine.targetHandler.GetDistance(opponent);
                return distance <= distanceLimit;
            }
            else
            {
                return false;
            }
        }
    }
}