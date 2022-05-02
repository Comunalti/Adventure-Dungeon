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
        public static List<TargetHandler> targetHandlers = new List<TargetHandler>();
        private void OnEnable()
        {
            targetHandlers.Add(this);
        }

        public void OnDisable()
        {
            targetHandlers.Remove(this);
        }

        
        public TargetHandler GetClosestOpponent(bool getOwnTeam = false)
        {
            TargetHandler nearTarget = null;
            float nearDistance = float.PositiveInfinity;
            foreach (var targetHandler in targetHandlers)
            {
                if (targetHandler == this || (!getOwnTeam && targetHandler.targetType == targetType))
                {
                    continue;
                }

                var newDistance = GetDistance(targetHandler);
                if (newDistance<nearDistance)
                {
                    nearTarget = targetHandler;
                    nearDistance = newDistance;
                }
            }
            return nearTarget;
        }
        public float GetDistance(TargetHandler handler) { 
           return Vector3.Distance(transform.position,handler.transform.position);
        }
        public float GetFirstOpponentDistance()
        {
            var opponentTargetHandler = GetClosestOpponent();
            if (opponentTargetHandler is null)
            {
                Debug.LogError("opponent target is null");
            }
            return Vector3.Distance(transform.position,opponentTargetHandler.transform.position);
        }

        public Vector3 GetFirstOpponentPosition()
        {
            var opponentTargetHandler = GetClosestOpponent();
            if (opponentTargetHandler is null)
            {
                return transform.position;
            }
            return opponentTargetHandler.transform.position;
        }

        public bool CanSeeFirstOpponent()
        {
            var opponentTargetHandler = GetClosestOpponent();

            if (opponentTargetHandler is null)
            {
                return false;
            }
            Debug.DrawLine(transform.position,opponentTargetHandler.transform.position);
            var raycastResult = Physics2D.RaycastAll(transform.position,opponentTargetHandler.transform.position-transform.position);
            // foreach (var raycastHit2D in raycastResult)
            // {
            //     print(raycastHit2D.transform.gameObject.name);
            // }
            
            //print(raycastResult.Length);
            var raycastHits = raycastResult.Where(hit =>
            {
                var col = GetComponent<Collider2D>();
                var opponentCollider = opponentTargetHandler.GetComponent<Collider2D>();
                return !(hit.collider == col ||
                         hit.collider == opponentCollider) &&
                       !opponentCollider.isTrigger;
            });
            //print($"real colliders in the line is: {raycastHits.Count()}");
            return !raycastHits.Any();
        }
    }
    
    public enum TargetType
    {
        enemy,
        player,
    }
}