using UnityEngine;

namespace States
{
    public abstract class BaseLegs : State
    {
        public override SM SM => SMController.LegsSM;

        public override State OnLegsRopeChanged()
        {
            return SM.GetLegsState();
        }

        public override State F2_performed()
        {
            Flags.Inverse(FlagName.LegsRope);
            return null;
        }
    }
}