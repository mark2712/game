namespace States
{
    public class JumpState : GameStateBase
    {
        public override void Enter()
        {
            base.Enter();

            GameContext.playerController.Jump();

            GameContext.playerController.nowMoveSpeed = GameContext.playerController.BaseMoveSpeed;
            GameContext.playerModelRotationSync.MoveSync(true);
            GameContext.playerAnimationController.Jump();

            StartTimer(200);
        }

        public override void Update()
        {
            base.Update();
            GameContext.playerController.nowMoveSpeed = PlayerSpeed.Get();

            if (IsTimerFinished())
            {
                GoToState(new GameState());
            }
        }

        public override void SpacePerformed() { }

        public override void OnMoveChanged() { }
        public override void OnGroundChanged() { }
        public override void OnShiftChanged() { }
        public override void OnSneakChanged() { }
    }
}