using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject EnemyPrefab;
    public float time;
    [SerializeField] private Transform spawnTransform;

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(time);
        while (true)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            yield return wait;
        }
    }
}
