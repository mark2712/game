using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class BaseGameState : State
    {
        public override bool Reentry => false;
        public virtual bool GroundState => true; // это состояние подразумевает что персонаж стоит на земле

        public override void Enter()
        {
            GameContext.playerController.NowMoveSpeed = PlayerSpeed.Get();
            if (GroundState)
            {
                GameContext.playerController.JumpCount = 0;
            }
        }

        public override void Update()
        {
            GameContext.cameraPlayerController.Update();
            GameContext.playerController.SetMoveInput(GameContext.inputController.MoveInput);
        }

        // Flags
        public override void OnMoveChanged()
        {
            GoToGameState();
        }

        public override void OnGroundChanged()
        {
            GoToGameState();
        }

        public override void OnShiftChanged()
        {
            GoToGameState();
        }

        public override void OnSneakChanged()
        {
            GoToGameState();
        }

        //Inputs
        public override void LookInput(Vector2 lookInput)
        {
            GameContext.cameraPlayerController.SetLookInput(lookInput);
        }

        public override void ScrollPerformed(InputAction.CallbackContext ctx)
        {
            GameContext.cameraPlayerController.OnScrollInputPerformed(ctx);
        }

        public override void SpacePerformed()
        {
            if (GameContext.playerController.JumpCount < 2 && Time.time - GameContext.playerController.LastJumpTime > 0.1f)
            {
                GoToState<JumpState>();
            }
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

        public override void KeyI_performed()
        {
            GoToState(new DialogState());
        }


        public override void Mouse1Performed()
        {
            GameContext.handsStateManager.State.Mouse1Performed();
        }
        public override void Mouse2Performed()
        {
            GameContext.handsStateManager.State.Mouse2Performed();
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