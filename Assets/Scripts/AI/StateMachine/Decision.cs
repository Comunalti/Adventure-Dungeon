using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(BaseStateMachine stateMachine);
    }
}