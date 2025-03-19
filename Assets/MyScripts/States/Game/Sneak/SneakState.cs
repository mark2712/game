namespace States
{
    public class SneakState : SneakStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Sneak();
        }
    }
}