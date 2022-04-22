using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.AI.StateMachine
{
    public class CharacterHandler : MonoBehaviour
    {
        private void Start()
        {
            var navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
            
            
        }

        private void Update()
        {
            //GetComponent<NavMeshAgent>().SetDestination(GetComponent<TargetHandler>().target.transform.position);
        }
    }
}