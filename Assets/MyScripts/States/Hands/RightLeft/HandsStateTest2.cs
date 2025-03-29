using UnityEngine;

namespace States
{
    public class HandsStateTest2 : HandsState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.SwordRightHand();
        }

        public override void Mouse1Performed()
        {
            GoToState(new HandsStateTest1());
        }
    }
}