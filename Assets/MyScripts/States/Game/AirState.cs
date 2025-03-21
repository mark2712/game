namespace States
{
    public class AirState : MoveStateBase
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

        public override void SpacePerformed() { }
    }
}