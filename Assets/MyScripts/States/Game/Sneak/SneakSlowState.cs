namespace States
{
    public class SneakSlowState : BaseSneakState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.SneakSlow();
        }
    }
}