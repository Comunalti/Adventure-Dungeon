using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create Opponent Near", fileName = "OpponentNear", order = 0)]
    public class OpponentNear : Decision
    {
        public float distanceLimit;
        public override bool Decide(BaseStateMachine stateMachine)
        {
            if (stateMachine.targetHandler.HasFirstValue())
            {
                float distance = stateMachine.targetHandler.GetFirstOpponentDistance();
                return distance <= distanceLimit;
            }
            else
            {
                return false;
            }
        }
    }
}