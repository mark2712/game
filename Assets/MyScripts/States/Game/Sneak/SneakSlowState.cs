namespace States
{
    public class SneakSlowState : MoveStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.SneakSlow();
        }
    }
}