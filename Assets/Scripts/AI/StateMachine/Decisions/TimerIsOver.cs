using UnityEngine;

namespace DefaultNamespace.AI.StateMachine.Decisions
{
    [CreateAssetMenu(menuName = "State Machine/Decision/Create TimerIsOver", fileName = "TimerIsOver", order = 0)]
    public class TimerIsOver : Decision
    {
        public string timerTag;
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var remainTimer = stateMachine.timerHandler.GetRemainTimer(timerTag);

            return remainTimer <= 0;
        }
    }
}