using UnityEngine;

namespace States
{
    public class HandsStateTest1 : HandsState
    {
        public override void Enter()
        {
            base.Enter();
            // GameContext.playerAnimationController.SwordLeftHand();
            GameContext.playerAnimationController.HandNone();
        }

        public override void Mouse2Performed()
        {
            GoToState(new HandsStateTest2());
        }
    }
}