namespace States
{
    public abstract class HandsBase : State
    {
        public override SM SM => SMController.HandsSM;
    }

    // public abstract class RightHandState : State
    // {
    //     public override SM SM => SMController.RightHandSM;
    // }

    // public abstract class LeftHandState : State
    // {
    //     public override SM SM => SMController.LeftHandSM;
    // }
}