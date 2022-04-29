using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    [CreateAssetMenu(menuName = "State Machine/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public Decision decision;
        public BaseState trueState;
        public BaseState falseState;

        public void Execute(BaseStateMachine stateMachine)
        {
            var decided = decision.Decide(stateMachine);

            if (decided)
            {
                if (!(trueState is RemainInState))
                {
                    stateMachine.Set(trueState);
                }
            }
            else
            {
                if (!(falseState is RemainInState)) 
                {
                    stateMachine.Set(falseState);
                }                
            }
        }
    }
}