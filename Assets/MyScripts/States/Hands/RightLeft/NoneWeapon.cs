using UnityEngine;

namespace States
{
    public class NoneWeapon : HandsState
    {
        public override void Enter()
        {
            base.Enter();
            // GameContext.playerAnimationController.SwordLeftHand();
            GameContext.PlayerAnimationController.HandNone();
        }

        public override State Mouse2Performed()
        {
            return new TakeWeapon();
        }
    }
}