using UnityEngine;

namespace States
{
    public class Air : BaseAir
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.Air();
        }

        public override void Update()
        {
            base.Update();
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Get();
        }

        public override State SpacePerformed()
        {
            // Player.PlayerController playerController = GameContext.playerController;
            // if (playerController.JumpCount < 2 && Time.time - playerController.LastJumpTime > 0.1f && playerController.DoubleJumpOn)
            // {
            //     GoToState<DoubleJump>();
            // }
            return null;
        }
    }
}