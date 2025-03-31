using UnityEngine;

namespace States
{
    public class AirState : BaseAirState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Air();
        }

        public override void Update()
        {
            base.Update();
            GameContext.playerController.NowMoveSpeed = PlayerSpeed.Get();
        }

        public override void SpacePerformed()
        {
            Player.PlayerController playerController = GameContext.playerController;
            if (playerController.JumpCount < 2 && Time.time - playerController.LastJumpTime > 0.1f && playerController.DoubleJumpOn)
            {
                GoToState<DoubleJumpState>();
            }
        }
    }
}