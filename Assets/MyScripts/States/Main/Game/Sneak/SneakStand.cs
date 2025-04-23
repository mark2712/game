namespace States
{
    public class SneakStand : BaseSneak
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.Stand();
        }
    }
}