namespace States
{
    public class StandState : MoveStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerModelRotationSync.MoveSync(false);
            GameContext.playerAnimationController.Stand();
        }
    }
}