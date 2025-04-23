namespace States
{
    public class ModalSM : SM
    {
        public override State DefaultState => new NoneModalState();
        // public ModalSM(SM parentSM) : base(parentSM) { }
    }
}