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

        public override State ConsolePerformed()
        {
            return SM.GetGameState();
        }

        public override State KeyI_performed()
        {
            Debug.Log("Диалог уже открыт");
            return null;
        }
    }
}