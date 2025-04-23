using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class BaseGame : MainBase
    {
        public override bool Reentry => false;
        // public override IEnumerable<Type> AllowedStates => new[]
        // {
        //     typeof(HandsState),
        //     typeof(ModalState)
        // };


        public override void Enter()
        {
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Get();
        }

        public override void Update()
        {
            GameContext.CameraPlayerController.Update(GameContext.InputController.LookInput);
            GameContext.PlayerController.SetMoveInput(GameContext.InputController.MoveInput);
        }

        // Flags
        public override State OnMoveChanged()
        {
            return SM.GetGameState();
        }

        public override State OnGroundChanged()
        {
            return SM.GetGameState();
        }

        public override State OnShiftChanged()
        {
            return SM.GetGameState();
        }

        public override State OnSneakChanged()
        {
            return SM.GetGameState();
        }

        //Inputs
        public override State ScrollPerformed(InputAction.CallbackContext ctx)
        {
            GameContext.CameraPlayerController.OnScrollInputPerformed(ctx);
            return null;
        }

        public override State SpacePerformed()
        {
            return new Jump();
        }
        public override State ConsolePerformed()
        {
            SM.GoToLayer(new Console());
            return null;
        }

        public override State KeyT_performed()
        {
            CounterFPS.Inc();
            return null;
        }

        public override State TabPerformed()
        {
            return SMController.HandsSM.State.TabPerformed();
        }

        public override State KeyZ_performed()
        {
            GameContext.CamerasController.ChangeActiveCameraThirdFirstPerson();
            return null;
        }

        public override State KeyI_performed()
        {
            return new Dialog();
        }


        public override State Mouse1Performed()
        {
            return SMController.HandsSM.State.Mouse1Performed();
        }
        public override State Mouse2Performed()
        {
            return SMController.HandsSM.State.Mouse2Performed();
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