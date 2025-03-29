using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace States
{
    public abstract class StateManager : IStateMonoBehaviour, IStateFlagsEvents, IStateInputEvents
    {
        public virtual State State { get; set; }

        // Events
        public void OnMoveChanged() { State?.OnMoveChanged(); }
        public void OnGroundChanged() { State?.OnGroundChanged(); }
        public void OnShiftChanged() { State?.OnShiftChanged(); }
        public void OnSneakChanged() { State?.OnSneakChanged(); }
        // public void OnGameOverChanged() { State?.OnGameOverChanged(); }

        public void FixedUpdate() { State?.FixedUpdate(); }
        public void Update() { State?.Update(); }
        public void LateUpdate() { State?.LateUpdate(); }

        public void EscPerformed() { State?.EscPerformed(); }
        public void ConsolePerformed() { State?.ConsolePerformed(); }
        public void MoveInput(Vector2 moveInput) { State?.MoveInput(moveInput); }
        public void LookInput(Vector2 lookInput) { State?.LookInput(lookInput); }
        public void ScrollPerformed(InputAction.CallbackContext ctx) { State?.ScrollPerformed(ctx); }

        public void Mouse1Performed() { State?.Mouse1Performed(); }
        public void Mouse2Performed() { State?.Mouse2Performed(); }
        public void Mouse3Performed() { State?.Mouse3Performed(); }

        public void TabPerformed() { State?.TabPerformed(); }
        public void ShiftPerformed() { State?.ShiftPerformed(); }
        public void ShiftCanceled() { State?.ShiftCanceled(); }
        public void CtrlPerformed() { State?.CtrlPerformed(); }
        public void CtrlCanceled() { State?.CtrlCanceled(); }
        public void AltPerformed() { State?.AltPerformed(); }
        public void AltCanceled() { State?.AltCanceled(); }
        public void SpacePerformed() { State?.SpacePerformed(); }

        public void KeyQ_performed() { State?.KeyQ_performed(); }
        public void KeyE_performed() { State?.KeyE_performed(); }
        public void KeyR_performed() { State?.KeyR_performed(); }
        public void KeyT_performed() { State?.KeyT_performed(); }
        public void KeyI_performed() { State?.KeyI_performed(); }
        public void KeyF_performed() { State?.KeyF_performed(); }
        public void KeyZ_performed() { State?.KeyZ_performed(); }
        public void KeyX_performed() { State?.KeyX_performed(); }
        public void KeyC_performed() { State?.KeyC_performed(); }
    }

}