// using UnityEngine;
// using UnityEngine.InputSystem;

// public class JumpState : GameStateFSM
// {
//     public JumpState(GameStateManager stateManager) : base(stateManager){}

//     public override void Enter()
//     {
//         Debug.Log("Прыжок");
//         GameContext.playerController.SetMoveSpeed();
//     }

//     public override void Update()
//     {
//         GameContext.playerController.Move();
//         GameContext.cameraPlayerController.Update(true);
//         if (!GameContext.playerController.isMove)
//         {
//             GoToState<StandState>();
//         }
//     }

//     public override void MoveInput(Vector2 moveInput)
//     {
//         GameContext.playerController.SetMoveInput(moveInput);
//     }

//     public override void LookInput(Vector2 lookInput)
//     {
//         GameContext.cameraPlayerController.SetLookInput(lookInput);
//     }

//     public override void KeyScroll_performed(InputAction.CallbackContext ctx)
//     {
//         GameContext.cameraPlayerController.OnScrollInputPerformed(ctx);
//     }

//     public override void KeyShift_performed()
//     {
//         GoToState<RunState>();
//     }
// }