namespace States
{
    public abstract class HandsState : State
    {
        public override SM SM => GameContext.HandsSM;
    }

    public abstract class RightHandState : State
    {
        public override SM SM => GameContext.RightHandSM;
    }

    public abstract class LeftHandState : State
    {
        public override SM SM => GameContext.LeftHandSM;
    }

    public abstract class ModalState : State
    {
        public override SM SM => GameContext.ModalSM;
    }
}