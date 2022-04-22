using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    [CreateAssetMenu(menuName = "State Machine/State/Create State", fileName = "State", order = 0)]
    public class State : BaseState
    {
        public List<StateMachineAction> actions = new List<StateMachineAction>();
        public List<Transition> transitions = new List<Transition>();
        
        public override void Execute(BaseStateMachine machine)
        {
            foreach (var action in actions)
            {
                action.Execute(machine);
            }

            foreach (var transition in transitions)
            {
                transition.Execute(machine);
            }
        }
    }
}