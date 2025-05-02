namespace States
{
    public class NoneModal : ModalBase
    {
        public override State TabPerformed()
        {
            return new Inventory();
        }
    }
}