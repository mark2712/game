namespace States
{
    public class SneakStandState : MoveStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Stand();
        }
    }
}