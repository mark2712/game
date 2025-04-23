namespace States
{
    public class NoneModalState : ModalState
    {
        public override State TabPerformed()
        {
            return new InventoryState();
        }
    }
}