namespace States
{
    public class HandsStateManager : StateManager
    {
        public HandsStateManager(StateManager parentStateManager = null) : base(parentStateManager)
        {
            parentStateManager.handsStateManager = this;
        }
        
        public bool isNowHit = false;
    }

    public class RightHandStateManager : StateManager
    {
        public RightHandStateManager(StateManager parentStateManager = null) : base(parentStateManager)
        {
            parentStateManager.rightHandStateManager = this;
        }
    }

    public class LeftHandStateManager : StateManager
    {
        public LeftHandStateManager(StateManager parentStateManager = null) : base(parentStateManager)
        {
            parentStateManager.leftHandStateManager = this;
        }
    }

    public class ModalStateManager : StateManager
    {
        public ModalStateManager(StateManager parentStateManager = null) : base(parentStateManager)
        {
            parentStateManager.modalStateManager = this;
        }
    }
}