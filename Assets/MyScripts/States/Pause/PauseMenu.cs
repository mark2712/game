namespace States
{
    public class PauseMenu : PauseBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.UIManager.TogglePauseMenu(true);
        }

        public override void Exit()
        {
            base.Exit();
            GameContext.UIManager.TogglePauseMenu(false);
        }

        public override State ConsolePerformed()
        {
            SM.ReturnToLayer();
            return null;
        }

        public override State EscPerformed()
        {
            SM.ReturnToLayer();
            return null;
        }
    }
}