using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class HitState : State
    {
        public override bool Reentry => true;

        public override void Enter()
        {
            GameContext.HandsSM.IsNowHit = true;
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Hit;
            GameContext.PlayerAnimationController.Kick();
            StartTimer(1200);
        }

        public override void Exit()
        {
            GameContext.HandsSM.IsNowHit = false;
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Get();
        }

        public override State Update()
        {
            GameContext.CameraPlayerController.Update(GameContext.InputController.LookInput);
            GameContext.PlayerController.SetMoveInput(GameContext.InputController.MoveInput); // можно немного сместиться в выбранном направлении

            if (IsTimerFinished())
            {
                if (GameContext.InputActions.Player.Mouse1.IsPressed())
                {
                    return new HitState();
                }
                return SM.GetGameState();
            }
            return null;
        }

        //Inputs
        public override State ScrollPerformed(InputAction.CallbackContext ctx)
        {
            GameContext.CameraPlayerController.OnScrollInputPerformed(ctx);
            return null;
        }

        // Inputs Keys
        public override State SpacePerformed()
        {
            return null;
        }
        public override State ConsolePerformed()
        {
            SM.GoToLayer(new MenuState());
            return null;
        }

        public override State Mouse1Performed()
        {
            // тут можно сделать комбо
            return null;
        }


        // Shift - Sneak
        public override State ShiftPerformed() { Flags.Shift = true; return null; }
        public override State ShiftCanceled() { Flags.Shift = false; return null; }
        public override State KeyX_performed() { Flags.Shift = !Flags.Shift; return null; }

        public override State CtrlPerformed() { Flags.Sneak = true; return null; }
        public override State CtrlCanceled() { Flags.Sneak = false; return null; }
        public override State AltPerformed() { Flags.Sneak = true; return null; }
        public override State AltCanceled() { Flags.Sneak = false; return null; }
        public override State KeyC_performed() { Flags.Sneak = !Flags.Sneak; return null; }
    }
}