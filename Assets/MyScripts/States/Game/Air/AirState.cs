using UnityEngine;

namespace States
{
    public class AirState : BaseAirState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.Air();
        }

        public override State Update()
        {
            base.Update();
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Get();
            return null;
        }

        public override State SpacePerformed()
        {
            // Player.PlayerController playerController = GameContext.playerController;
            // if (playerController.JumpCount < 2 && Time.time - playerController.LastJumpTime > 0.1f && playerController.DoubleJumpOn)
            // {
            //     GoToState<DoubleJumpState>();
            // }
            return null;
        }
    }
}