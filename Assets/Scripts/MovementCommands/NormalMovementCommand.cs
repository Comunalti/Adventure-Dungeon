using UnityEngine;

namespace MovementCommands
{
    [CreateAssetMenu(menuName = "Create NormalMovementCommand", fileName = "NormalMovementCommand", order = 0)]
    public class NormalMovementCommand : MovementCommand
    {
        public float speed;
        public override void Move(Rigidbody2D character, Vector2 direction)
        {
            character.MovePosition( character.position + direction * (speed * Time.deltaTime));
        }
    }
}