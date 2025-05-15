using UnityEngine;

namespace States
{
    public class Jump : BaseAir
    {
        public override bool Reentry => true;
        public override void Enter()
        {
            base.Enter();
            DoJump();
            RegisterEvent(StateEventType.JumpFinished, _ => JumpFinished());
        }

        protected virtual void DoJump()
        {
            StartTimer(200);
            GameContext.PlayerController.Jump();
            GameContext.PlayerAnimationController.Jump();
        }

        public override void Update()
        {
            base.Update();

            if (IsTimerFinished())
            {
                SM.TriggerEvent(StateEventType.JumpFinished);
                // JumpFinished();
            }
        }

        public State JumpFinished() { return SM.GetGameState(); }

        public override State SpacePerformed() { return null; }

        public override State OnMoveChanged() { return null; }
        public override State OnGroundChanged() { return null; }
        public override State OnShiftChanged() { return null; }
        public override State OnSneakChanged() { return null; }
    }
}