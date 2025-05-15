using UnityEngine;

namespace States
{
    public class HandsRope : BaseHands
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.HandsRope();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override State Mouse1Performed()
        {
            State legsNewState = SMController.LegsSM.State.Mouse1Performed();
            if (legsNewState == null)
            {
                Debug.Log("Атака невозможна, руки и ноги неактивны");
                return null; // у рук и ног нет возможности атаковать, 
            }
            else
            {
                return legsNewState; // ноги сами решат как им атаковать
            }
        }
    }
}