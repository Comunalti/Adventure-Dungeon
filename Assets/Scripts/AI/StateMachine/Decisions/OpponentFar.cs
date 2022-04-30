using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create Opponent Far", fileName = "OpponentFar", order = 0)]
    public class OpponentFar : Decision
    {
        public float distanceLimit;
        public override bool Decide(BaseStateMachine stateMachine)
        {
            if (stateMachine.targetHandler.HasFirstValue())
            {
                float distance = stateMachine.targetHandler.GetFirstOpponentDistance();
                return distance >= distanceLimit;
            }
            else
            {
                return true;
            }
            
        }
    }
}