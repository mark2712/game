using UnityEngine;

namespace States
{
    public class DialogState : State
    {
        public override void Enter()
        {
            // Debug.Log("Диалог открыт");
        }
        public override void Exit()
        {
            // Debug.Log("Диалог закрыт");
        }

        public override void ConsolePerformed()
        {
            GoToGameState();
        }

        public override void KeyI_performed()
        {
            Debug.Log("Диалог уже открыт");
        }
    }
}