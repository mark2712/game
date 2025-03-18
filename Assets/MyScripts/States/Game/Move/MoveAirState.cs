using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class MoveAirState : MoveStateBase
    {
        public override void Enter()
        {
            GameContext.playerController.nowMoveSpeed = GameContext.playerController.BaseMoveSpeed;
            GameContext.playerModelRotationSync.MoveSync(true);
            GameContext.playerAnimationController.Air();
        }
    }
}