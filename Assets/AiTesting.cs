using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AiTesting : MonoBehaviour
{
    [SerializeField] private float radius = 1;
    // [SerializeField] private Vector2[] directions;
    // [SerializeField] private Vector2 mainDirection;
    [SerializeField] private Collider2D collider;
    
    [SerializeField] Stateless followStateless;
    [SerializeField] Stateless avoidStateless;
    [SerializeField] Stateless finalStateless;

    public bool showFollowStateless;
    public bool showAvoidStateless;
    public bool showFinalStateless;

    
    // Start is called before the first frame update
    void Start()
    {
        //directions = new Vector2[followStateless.size];
        
    }

    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i < directions.Length; i++)
        // {
        //     directions[i] = followStateless.GetValueAsVector(i);
        // }
        //
        // mainDirection = followStateless.GetMaxInterpolatedVector();
    }

    private void OnDrawGizmosSelected()
    {
        // Handles.DrawWireDisc(transform.position,Vector3.forward, minRadius);
        Handles.DrawWireDisc(transform.position,Vector3.forward, radius);
        if (showFollowStateless && followStateless)
        {
            DrawStateless(followStateless);
        }
        if (showAvoidStateless && avoidStateless)
        {
            DrawStateless(avoidStateless);
        }
        if (showFinalStateless && finalStateless)
        {
            DrawStateless(finalStateless);
        }
    }

    public void DrawStateless(Stateless stateless)
    {
        if (stateless.values != null && stateless.values.Length != 0)
        {
            for (int i = 0; i < stateless.values.Length; i++)
            {
                print(i);
                Gizmos.DrawRay(transform.position,stateless.GetValueAsVector(i)*radius);
            }   
            print("BBB");
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, stateless.GetMaxInterpolatedVector() * radius);
            Gizmos.color = Color.white;
            print("ccccc");

        }
        
        //stateless.ResetValues();
    }

    [ContextMenu("raycast")]
    public void Raycast()
    {
        for (int i = 0; i < followStateless.size; i++)
        {
            var direction = followStateless.GetDirection(i);
            var result = Physics2D.RaycastAll(transform.position, direction);
            foreach (var hit2D in result)
            {
                print(hit2D.distance);
            }
            var first = result.FirstOrDefault(hit2D => hit2D.collider != collider );
            print($"min distance is: {first.distance}");
        }
    }
    
    
}