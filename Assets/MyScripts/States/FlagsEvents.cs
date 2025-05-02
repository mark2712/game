namespace States
{
    public class FlagsEvents
    {
        public FlagsEvents(SM mainSM)
        {
            Flags.Subscribe(FlagName.Move, _ => mainSM.OnMoveChanged());
            Flags.Subscribe(FlagName.Shift, _ => mainSM.OnShiftChanged());
            Flags.Subscribe(FlagName.Sneak, _ => mainSM.OnSneakChanged());
            Flags.Subscribe(FlagName.Ground, _ => mainSM.OnGroundChanged());
        }
    }
}