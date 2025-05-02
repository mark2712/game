namespace States
{
    public abstract class BaseHands : State
    {
        public override SM SM => SMController.HandsSM;
    }
}