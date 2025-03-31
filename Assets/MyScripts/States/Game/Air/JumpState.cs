using UnityEngine;

namespace States
{
    public class JumpState : BaseAirState
    {
        public override void Enter()
        {
            base.Enter();
            Jump();
        }

        protected virtual void Jump()
        {
            StartTimer(200);
            GameContext.playerController.Jump();
            GameContext.playerAnimationController.Jump();
        }

        public override void Update()
        {
            base.Update();
            GameContext.playerController.NowMoveSpeed = PlayerSpeed.Get();

            if (IsTimerFinished())
            {
                GoToGameState();
            }
        }

        public override void SpacePerformed() { }

        public override void OnMoveChanged() { }
        public override void OnGroundChanged() { }
        public override void OnShiftChanged() { }
        public override void OnSneakChanged() { }
    }
}