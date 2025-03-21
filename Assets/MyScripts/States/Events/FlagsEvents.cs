namespace States
{
    public class FlagsEvents
    {
        public FlagsEvents(MainStateManager mainStateManager)
        {
            EventQueue eventQueue = mainStateManager.eventQueue;

            Flags.OnMoveChanged += _ => eventQueue.AddEvent(() => mainStateManager.OnMoveChanged());
            Flags.OnGroundChanged += _ => eventQueue.AddEvent(() => mainStateManager.OnGroundChanged());
            Flags.OnShiftChanged += _ => eventQueue.AddEvent(() => mainStateManager.OnShiftChanged());
            Flags.OnSneakChanged += _ => eventQueue.AddEvent(() => mainStateManager.OnSneakChanged());
        }
    }
}