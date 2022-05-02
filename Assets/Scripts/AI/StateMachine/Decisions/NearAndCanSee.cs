using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create NearAndCanSee", fileName = "NearAndCanSee", order = 0)]
    public class NearAndCanSee : Decision
    {
        public float distanceLimit;

        public override bool Decide(BaseStateMachine stateMachine)
        {
            var canSeeFirstOpponent = stateMachine.targetHandler.CanSeeFirstOpponent();
            
            var opponent = stateMachine.targetHandler.GetClosestOpponent();
            if (opponent != null)
            {
                float distance = stateMachine.targetHandler.GetDistance(opponent);
                return distance <= distanceLimit && canSeeFirstOpponent;
            }
            else
            {
                return false;
            }
            
        }
    }
}