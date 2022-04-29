using System;
using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    public abstract class StateMachineAction : ScriptableObject
    {
        public abstract void Execute(BaseStateMachine machine);
    }
}