using UnityEngine;

namespace States
{
    public class PauseState : State
    {
        private float _time;
        public override void Enter()
        {
            // Debug.Log("Пауза Enter");
            _time = Time.timeScale;
            Time.timeScale = 0;
            Cursor.visible = true;
        }

        public override void Exit()
        {
            // Debug.Log("Пауза Exit");
            Time.timeScale = _time;
            Cursor.visible = false;
        }
    }


    public class MenuState : PauseState
    {
        public override void Enter()
        {
            base.Enter();
            // Debug.Log("Меню открыто");
            GameContext.uiManager.OpenMenu();
        }

        public override void Exit()
        {
            base.Exit();
            // Debug.Log("Меню закрыто");
            GameContext.uiManager.CloseMenu();
        }

        public override void ConsolePerformed()
        {
            mainStateManager.ReturnToLayer();
        }
    }
}