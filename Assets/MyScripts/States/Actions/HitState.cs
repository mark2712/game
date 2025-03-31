using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class HitState : State
    {
        public override bool Reentry => true;

        public override void Enter()
        {
            StateManager.handsStateManager.isNowHit = true;
            GameContext.playerController.SetMoveInput(Vector2.zero);
            GameContext.playerAnimationController.Kick();
            StartTimer(1300);
        }

        public override void Exit()
        {
            StateManager.handsStateManager.isNowHit = false;
        }

        public override void Update()
        {
            GameContext.cameraPlayerController.Update();

            if (IsTimerFinished())
            {
                GoToGameState();
            }
        }

        // Flags
        // none

        //Inputs
        public override void LookInput(Vector2 lookInput)
        {
            GameContext.cameraPlayerController.SetLookInput(lookInput);
        }

        // public override void MoveInput(Vector2 moveInput)
        // {
        //     if (moveInput.magnitude == 0)
        //     {
        //         GameContext.playerController.SetMoveInput(Vector2.zero);
        //     }
        // }

        public override void ScrollPerformed(InputAction.CallbackContext ctx)
        {
            GameContext.cameraPlayerController.OnScrollInputPerformed(ctx);
        }

        // Inputs Keys
        public override void SpacePerformed()
        {
            // GoToState<JumpState>();
        }
        public override void ConsolePerformed()
        {
            StateManager.GoToLayer(new MenuState());
        }

        public override void KeyT_performed()
        {
            CounterFPS.Inc();
        }

        public override void KeyZ_performed()
        {
            GameContext.camerasController.ChangeActiveCameraThirdFirstPerson();
        }

        public override void Mouse1Performed()
        {
            // GameContext.handsStateManager.State.Mouse1Performed();
        }


        // Shift - Sneak
        public override void ShiftPerformed()
        {
            Flags.Shift = true;
        }
        public override void ShiftCanceled()
        {
            Flags.Shift = false;
        }
        public override void KeyX_performed()
        {
            Flags.Shift = !Flags.Shift;
        }

        public override void CtrlPerformed()
        {
            Flags.Sneak = true;
        }
        public override void CtrlCanceled()
        {
            Flags.Sneak = false;
        }
        public override void AltPerformed()
        {
            Flags.Sneak = true;
        }
        public override void AltCanceled()
        {
            Flags.Sneak = false;
        }
        public override void KeyC_performed()
        {
            Flags.Sneak = !Flags.Sneak;
        }
    }
}