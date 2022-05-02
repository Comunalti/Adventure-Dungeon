using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    public abstract class BaseState : ScriptableObject
    {
        public abstract void Execute(BaseStateMachine machine);

        public abstract void LeaveState(BaseStateMachine machine);
        public abstract void EnterState(BaseStateMachine machine);
    }
}