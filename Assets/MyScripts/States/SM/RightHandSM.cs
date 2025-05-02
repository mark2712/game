namespace States
{
    public class RightHandSM : SM
    {
        public override State DefaultState => new RHandEmpty();
    }
}