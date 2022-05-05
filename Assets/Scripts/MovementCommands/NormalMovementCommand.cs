using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MovementCommands
{
    [CreateAssetMenu(menuName = "Create NormalMovementCommand", fileName = "NormalMovementCommand", order = 0)]
    public class NormalMovementCommand : MovementCommand 
    {
        public static float speed;
        public override void Move(Rigidbody2D character, Vector2 direction)
        {
            character.transform.Translate(direction*speed*Time.deltaTime);
        }
    }
    public class IceMovementCommand : MovementCommand
    {
        public override void Move(Rigidbody2D rigidbody2D, Vector2 direction)
        {
            NormalMovementCommand.speed = 0.5f;
        }
    }
}