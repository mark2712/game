namespace States
{
    public class SneakStandState : BaseSneakState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Stand();
        }
    }
}