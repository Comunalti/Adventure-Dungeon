using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoverTest : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject target;
    void Start()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.SetDestination(target.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.transform.position);

        if (navMeshAgent.isStopped)
        {
            print("aaa");
        }
    }
}
