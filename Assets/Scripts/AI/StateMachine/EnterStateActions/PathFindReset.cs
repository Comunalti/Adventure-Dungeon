using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.EnterStateActions
{
    [CreateAssetMenu(menuName = "State Machine/Enter State Actions/Create PathFindReset", fileName = "PathFindReset", order = 0)]
    public class PathFindReset : EnterStateAction
    {
        public override void Execute(BaseStateMachine baseStateMachine)
        {
            baseStateMachine.agent.ResetPath();
        }
    }
}