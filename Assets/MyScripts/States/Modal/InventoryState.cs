namespace States
{
    public class InventoryState : ModalState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.UIManager.ToggleInventory(true);
        }

        public override void Exit()
        {
            base.Exit();
            GameContext.UIManager.ToggleInventory(false);
        }

        public override State TabPerformed()
        {
            return new NoneModalState();
        }
    }
}