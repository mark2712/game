using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public class MoveRunState : MoveStateBase
    {
        public override void Enter()
        {
            GameContext.playerController.nowMoveSpeed = GameContext.playerController.BaseMoveSpeed * 1.8f;
            GameContext.playerModelRotationSync.MoveSync(true);
            GameContext.playerAnimationController.Run();
        }
    }
}