using UnityEngine;

namespace States
{
    public class JumpState : BaseAirState
    {
        public override bool Reentry => true;
        public override void Enter()
        {
            base.Enter();
            Jump();
        }

        protected virtual void Jump()
        {
            StartTimer(200);
            GameContext.PlayerController.Jump();
            GameContext.PlayerAnimationController.Jump();
        }

        public override State Update()
        {
            base.Update();
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Get();

            if (IsTimerFinished())
            {
                return SM.GetGameState();
            }
            return null;
        }

        public override State SpacePerformed() { return null; }

        public override State OnMoveChanged() { return null; }
        public override State OnGroundChanged() { return null; }
        public override State OnShiftChanged() { return null; }
        public override State OnSneakChanged() { return null; }
    }
}