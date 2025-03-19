namespace States
{
    public class MoveState : MoveStateBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Move();
        }
    }
}