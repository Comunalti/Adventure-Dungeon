using System;
using DefaultNamespace.AI.StateMachine;
using UnityEngine;

namespace AI.Helpers
{
    public class EnemyDisabler : MonoBehaviour
    {
        public BaseStateMachine baseStateMachine;
        public TargetHandler targetHandler;
        public float distance;
        private void Update()
        {
            var opponentDistance = targetHandler.GetFirstOpponentDistance();

            if (opponentDistance>distance)
            {
                baseStateMachine.enabled = false;
            }
            else
            {
                baseStateMachine.enabled = true;
            }
        }
    }
}