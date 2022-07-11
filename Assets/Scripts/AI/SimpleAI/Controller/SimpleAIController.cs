using System;
using System.Collections;
using System.Collections.Generic;
using Health;
using Player;
using UnityEditor;
using UnityEngine;

public class SimpleAIController : MonoBehaviour
{
    private PlayerController player;
    public float walkSpeed;
    public HealthController healthController;
    
    private void Awake()
    {
        player = PlayerManager.Instance.GetPlayer();
    }

    private void OnEnable()
    {
        healthController.DeathEvent += OnEnemyDeath;
    }

    private void OnDisable()
    {
        healthController.DeathEvent -= OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        enabled = false;
    }

    private void Update()
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position,player.transform.position,walkSpeed*Time.deltaTime);
    }
    
    
}
