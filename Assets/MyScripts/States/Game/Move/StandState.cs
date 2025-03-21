namespace States
{
    public class StandState : MoveStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Stand();
        }
    }
}