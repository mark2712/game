namespace States
{
    public abstract class HandsState : State
    {
        public override StateManager StateManager => GameContext.handsStateManager;
        public StateManager mainStateManager = GameContext.mainStateManager;
    }

    public abstract class RightHandState : State
    {
        public override StateManager StateManager => GameContext.rightHandStateManager;
    }

    public abstract class LeftHandState : State
    {
        public override StateManager StateManager => GameContext.leftHandStateManager;
    }

    public abstract class ModalState : State
    {
        public override StateManager StateManager => GameContext.modalStateManager;
    }
}