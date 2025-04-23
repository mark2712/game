using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class TakeWeapon : HandsBase
    {
        public override List<ConflictRule> Conflicts => new()
        {
            new ConflictAll<InventoryState>(),
        };

        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.SwordRightHand();
        }

        public override State Mouse1Performed()
        {
            return new HitState();
        }

        public override State Mouse2Performed()
        {
            return new NoneWeapon();
        }
    }
}