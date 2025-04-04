// namespace States
// {
//     public class DoubleJumpState : JumpState
//     {
//         public override void Enter()
//         {
//             base.Enter();
//             Jump();
//         }

//         protected override void Jump()
//         {
//             StartTimer(200);
//             GameContext.playerController.Jump();
//             if (GameContext.playerController.JumpCount < 2)
//             {
//                 GameContext.playerController.JumpCount = 1;
//             }
//         }
//     }
// }