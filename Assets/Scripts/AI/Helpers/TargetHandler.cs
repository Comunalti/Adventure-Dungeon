using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.AI.StateMachine
{
    public class TargetHandler : MonoBehaviour
    {
        public TargetType targetType = TargetType.enemy;
        public LinkedList<TargetHandler> closeTargets = new LinkedList<TargetHandler>();
        
        public event Action TargetsChangedEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var targetHandler = other.GetComponentInChildren<TargetHandler>();
            if (targetHandler != null)
            {
                if (targetHandler.targetType != TargetType.enemy)
                {
                    closeTargets.AddLast(targetHandler);
                    TargetsChangedEvent?.Invoke();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var targetHandler = other.GetComponentInChildren<TargetHandler>();
            if (targetHandler != null)
            {
                if (closeTargets.Remove(targetHandler)) TargetsChangedEvent?.Invoke();
            }
        }

        public void SetFirstTarget(TargetHandler targetHandler)
        {
            closeTargets.AddFirst(targetHandler);
            TargetsChangedEvent?.Invoke();
        }

        public bool HasFirstValue()
        {
            return !(closeTargets.First is null);
        }
        public TargetHandler GetFirstAimOpponent()
        {
            return closeTargets.First.Value;
        }

        public float GetFirstOpponentDistance()
        {
            var opponentTargetHandler = GetFirstAimOpponent();
            return Vector3.Distance(transform.position,opponentTargetHandler.transform.position);
        }

        public Vector3 GetFirstOpponentPosition()
        {
            var opponentTargetHandler = GetFirstAimOpponent();
            return opponentTargetHandler.transform.position;
        }
    }
    
    public enum TargetType
    {
        enemy,
        player,
    }
}