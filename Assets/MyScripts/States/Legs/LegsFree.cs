namespace States
{
    public class LegsFree : BaseLegs
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.LegsNone();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override State Mouse1Performed()
        {
            return new Hit();
        }
    }
}