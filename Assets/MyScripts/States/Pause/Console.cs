namespace States
{
    public class Console : PauseBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.UIManager.ToggleConsole(true);
        }

        public override void Exit()
        {
            base.Exit();
            GameContext.UIManager.ToggleConsole(false);
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