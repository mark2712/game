using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class MoveRunState : MoveStateBase
    {
        public override void ShiftCanceled()
        {
            Flags.Shift = false;
        }
        public override void KeyX_performed()
        {
            Flags.Shift = false;
        }
    }
}