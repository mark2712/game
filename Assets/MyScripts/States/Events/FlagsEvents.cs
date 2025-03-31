namespace States
{
    public class FlagsEvents
    {
        public FlagsEvents(StateManager mainStateManager)
        {
            EventQueue eventQueue = mainStateManager.eventQueue;

            Flags.OnMoveChanged += _ => mainStateManager.OnMoveChanged();
            Flags.OnGroundChanged += _ => mainStateManager.OnGroundChanged();
            Flags.OnShiftChanged += _ => mainStateManager.OnShiftChanged();
            Flags.OnSneakChanged += _ => mainStateManager.OnSneakChanged();
        }
    }
}