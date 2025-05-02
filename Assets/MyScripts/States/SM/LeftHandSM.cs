namespace States
{
    public class LeftHandSM : SM
    {
        public override State DefaultState => new LHandEmpty();
    }
}