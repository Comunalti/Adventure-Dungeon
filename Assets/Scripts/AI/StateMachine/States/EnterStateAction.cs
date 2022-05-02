using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    public abstract class EnterStateAction : ScriptableObject
    {
        public abstract void Execute(BaseStateMachine baseStateMachine);
    }
}