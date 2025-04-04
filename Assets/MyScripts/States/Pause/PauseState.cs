using UnityEngine;

namespace States
{
    public class PauseState : State
    {
        private float _time;
        public override void Enter()
        {
            GameContext.IsPause = true;
            _time = Time.timeScale;
            Time.timeScale = 0;
            Cursor.visible = true;
        }

        public override void Exit()
        {
            GameContext.IsPause = false;
            Time.timeScale = _time;
            Cursor.visible = false;
        }
    }


    public class MenuState : PauseState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.UIManager.OpenMenu();
        }

        public override void Exit()
        {
            base.Exit();
            GameContext.UIManager.CloseMenu();
        }

        public override State ConsolePerformed()
        {
            SM.ReturnToLayer();
            return null;
        }
    }
}