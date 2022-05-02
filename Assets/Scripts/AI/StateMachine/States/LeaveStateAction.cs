using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    public abstract class LeaveStateAction : ScriptableObject
    {
        public abstract void Execute(BaseStateMachine baseStateMachine);
    }
}