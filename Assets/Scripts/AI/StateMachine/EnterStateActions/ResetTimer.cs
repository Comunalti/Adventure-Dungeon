using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.EnterStateActions
{
    [CreateAssetMenu(menuName = "State Machine/Enter State Actions/Create ResetTimer", fileName = "ResetTimer", order = 0)]
    public class ResetTimer : EnterStateAction
    {
        public string timerName;
        public override void Execute(BaseStateMachine baseStateMachine)
        {
            baseStateMachine.timerHandler.ResetTimer(timerName);
        }
    }
}