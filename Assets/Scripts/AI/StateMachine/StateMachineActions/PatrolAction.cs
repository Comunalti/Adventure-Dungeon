// using System;
//
// namespace DefaultNamespace.AI.StateMachine.StateMachineActions
// {
//     public class PatrolAction : StateMachineAction 
//     {
//         public override void Execute(BaseStateMachine machine)
//         {
//             if (machine.PathFinderHandler.HasReachedTarget())
//             {
//                 machine.PathFinderHandler.ChooseNewTarget();
//             }
//         }
//     }
//
//     public class FollowAction : StateMachineAction
//     {
//         public override void Execute(BaseStateMachine machine)
//         {
//             machine.PathFinderHandler.FollowLockEnemy();
//         }
//     }
//
//     public class AttackSimpleWeaponAction : StateMachineAction
//     {
//         public override void Execute(BaseStateMachine machine)
//         {
//             if ()
//             {
//                 throw new NotImplementedException();
//             }
//         }
//     }
// }