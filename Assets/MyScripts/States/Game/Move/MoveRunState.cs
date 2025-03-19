namespace States
{
    public class MoveRunState : MoveStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Run();
        }
    }
}