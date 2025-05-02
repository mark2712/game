using UnityEngine;

namespace States
{
    public class NoneWeapon : BaseHands
    {
        public override void Enter()
        {
            base.Enter();
            // GameContext.playerAnimationController.SwordLeftHand();
            GameContext.PlayerAnimationController.HandsNone();
        }

        public override State Mouse2Performed()
        {
            return new TakeWeapon();
        }

        public override State TabPerformed()
        {
            return SMController.ModalSM.State.TabPerformed();
        }
    }
}