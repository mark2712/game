using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class SneakSlowState : State
    {
        // public HandsState handsState;

        public override void Update()
        {
            GameContext.cameraPlayerController.Update();
        }

        public override void LookInput(Vector2 lookInput)
        {
            GameContext.cameraPlayerController.SetLookInput(lookInput);
        }

        public override void MoveInput(Vector2 moveInput)
        {
            GameContext.playerController.SetMoveInput(moveInput);
        }

        public override void ScrollPerformed(InputAction.CallbackContext ctx)
        {
            GameContext.cameraPlayerController.OnScrollInputPerformed(ctx);
        }

        public override void SpacePerformed()
        {
            // GoToState<JumpState>();
            GameContext.playerController.Jump();
        }

        public override void ConsolePerformed()
        {
            mainStateManager.GoToLayer(new MenuState());
        }

        public override void KeyT_performed()
        {
            CounterFPS.Inc();
        }

        public override void KeyZ_performed()
        {
            GameContext.camerasController.ChangeActiveCameraThirdFirstPerson();
        }

        public override void KeyI_performed()
        {
            mainStateManager.GoToState(new DialogState());
        }
    }
}