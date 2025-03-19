namespace States
{
    public class FlagsEvents
    {
        private MainStateManager _mainStateManager;

        public FlagsEvents(MainStateManager mainStateManager)
        {
            _mainStateManager = mainStateManager;

            Flags.OnMoveChanged += _ => _mainStateManager.OnMoveChanged();
            Flags.OnGroundChanged += _ => _mainStateManager.OnGroundChanged();
            Flags.OnShiftChanged += _ => _mainStateManager.OnShiftChanged();
            Flags.OnSneakChanged += _ => _mainStateManager.OnSneakChanged();
        }
    }
}