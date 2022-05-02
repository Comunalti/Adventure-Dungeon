using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create CanSeeOpponent", fileName = "CanSeeOpponent", order = 0)]
    public class CanSeeOpponent : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            
            return stateMachine.targetHandler.CanSeeFirstOpponent();
        }
    }
}