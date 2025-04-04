namespace States
{
    public class MoveRunState : BaseMoveState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.Run();
        }
    }
}