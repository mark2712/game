using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class TakeWeapon : BaseHands
    {
        public override List<ConflictRule> Conflicts => new()
        {
            new ConflictAll<Inventory>(),
        };

        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.SwordRightHand();
        }

        public override State Mouse1Performed()
        {
            return new Hit();
        }

        public override State Mouse2Performed()
        {
            return new NoneWeapon();
        }
    }
}