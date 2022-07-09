using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEditor;
using UnityEngine;

public class SimpleAIController : MonoBehaviour
{
    private PlayerController player;
    public float walkSpeed;
    public Health health;
    
    private void Awake()
    {
        player = PlayerManager.Instance.GetPlayer();
    }

    private void OnEnable()
    {
        health.DiedEvent += OnEnemyDied;
    }

    private void OnDisable()
    {
        health.DiedEvent -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        enabled = false;
    }

    private void Update()
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position,player.transform.position,walkSpeed*Time.deltaTime);
    }
    
    
}
