namespace States
{
    public class FlagsEvents
    {
        public FlagsEvents(SM mainSM)
        {
            Flags.OnMoveChanged += _ => mainSM.OnMoveChanged();
            Flags.OnGroundChanged += _ => mainSM.OnGroundChanged();
            Flags.OnShiftChanged += _ => mainSM.OnShiftChanged();
            Flags.OnSneakChanged += _ => mainSM.OnSneakChanged();
        }
    }
}