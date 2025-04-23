namespace States
{
    public abstract class ModalState : State
    {
        public override SM SM => SMController.ModalSM;
    }
}