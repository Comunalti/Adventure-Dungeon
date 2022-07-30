using System;
using Unity.Mathematics;
using UnityEngine;

namespace AI.Helpers
{
    public class RotationReSetter : MonoBehaviour
    {
        private void Start()
        {
            transform.rotation = quaternion.identity;
            
        }
    }
}