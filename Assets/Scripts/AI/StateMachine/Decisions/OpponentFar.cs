using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create Opponent Far", fileName = "OpponentFar", order = 0)]
    public class OpponentFar : Decision
    {
        public float distanceLimit;
        public override bool Decide(BaseStateMachine stateMachine)
        {
            float distance = stateMachine.targetHandler.ClosestOpponentDistance();
            return distance >= distanceLimit;
        }
    }
}