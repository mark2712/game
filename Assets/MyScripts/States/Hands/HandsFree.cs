using UnityEngine;

namespace States
{
    public class HandsFree : BaseHands
    {
        public override void Enter()
        {
            base.Enter();
            // GameContext.playerAnimationController.SwordHandLeft();
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