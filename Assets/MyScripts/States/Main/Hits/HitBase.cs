using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class HitBase : State
    {
        public override SM SM => SMController.MainSM;

        public override bool Reentry => true;

        public override void Enter()
        {
            Flags.Set(FlagName.Hit, true);
        }

        public override void Update()
        {
            GameContext.CameraPlayerController.Update(GameContext.InputController.LookInput);
            GameContext.PlayerController.SetMoveInput(GameContext.InputController.MoveInput);
        }

        public override void Exit()
        {
            Flags.Set(FlagName.Hit, false);
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
            SM.GoToLayer(new Console());
            return null;
        }

        public override State Mouse1Performed()
        {
            // тут можно сделать комбо
            return null;
        }


        // Shift - Sneak
        public override State ShiftPerformed() { Flags.Set(FlagName.Shift, true); return null; }
        public override State ShiftCanceled() { Flags.Set(FlagName.Shift, false); return null; }
        public override State KeyX_performed() { Flags.Inverse(FlagName.Shift); return null; }

        public override State CtrlPerformed() { Flags.Set(FlagName.Sneak, true); return null; }
        public override State CtrlCanceled() { Flags.Set(FlagName.Sneak, false); return null; }
        public override State AltPerformed() { Flags.Set(FlagName.Sneak, true); return null; }
        public override State AltCanceled() { Flags.Set(FlagName.Sneak, false); return null; }
        public override State KeyC_performed() { Flags.Inverse(FlagName.Sneak); return null; }
    }
}