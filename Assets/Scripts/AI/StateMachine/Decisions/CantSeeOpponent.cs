using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create CantSeeOpponent", fileName = "CantSeeOpponent", order = 0)]
    public class CantSeeOpponent : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var decide = !stateMachine.targetHandler.CanSeeFirstOpponent();
            Debug.Log($"cant see player: {decide}");
            return decide;
        }
    }
}