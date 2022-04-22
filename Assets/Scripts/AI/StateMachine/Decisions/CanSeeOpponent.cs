// namespace DefaultNamespace.AI.StateMachine.Decisions
// {
//     public class CanSeeOpponent : Decision
//     {
//         public override bool Decide(BaseStateMachine stateMachine)
//         {
//             var opponent = stateMachine.targetHandler.LockOpponent();
//
//             var position = stateMachine.characterHandler.GetPosition();
//
//             var opponentPosition = opponent.characterHandler.GetPosition();
//
//             var a = opponentPosition - position;
//
//             var distance = a.magnitude;
//             var direction = a.normalize;
//             
//             
//
//         }
//     }
// }