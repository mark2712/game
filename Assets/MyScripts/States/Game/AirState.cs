namespace States
{
    public class AirState : MoveStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerModelRotationSync.MoveSync(true);
            GameContext.playerAnimationController.Air();
        }

        public override void Update()
        {
            base.Update();
            GameContext.playerController.nowMoveSpeed = PlayerSpeed.Get();
        }

        public override void SpacePerformed() { }
    }
}