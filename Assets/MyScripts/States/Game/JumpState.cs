namespace States
{
    public class JumpState : GameStateBase
    {
        public override void Enter()
        {
            base.Enter();

            GameContext.playerController.Jump();

            GameContext.playerController.NowMoveSpeed = PlayerSpeed.Get();
            GameContext.playerAnimationController.Jump();

            StartTimer(200);
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