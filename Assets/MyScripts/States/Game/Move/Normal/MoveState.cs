using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class MoveState : MoveStateBase
    {
        public override void ShiftPerformed()
        {
            Flags.Shift = true;
        }
        public override void KeyX_performed()
        {
            Flags.Shift = true;
        }
    }
}