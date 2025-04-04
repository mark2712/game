namespace States
{
    public class HandsSM : SM
    {
        public HandsSM(SM parentSM) : base(parentSM) { }

        public bool _isNowHit = false;
        public bool IsNowHit
        {
            get => _isNowHit;
            set
            {
                if (_isNowHit != value)
                {
                    _isNowHit = value;
                    NowHit();
                }
            }
        }

        public void NowHit()
        {
            if (_isNowHit)
            {
                GameContext.PlayerAnimationController.EditHandsLayerIndex(0);
            }
            else
            {
                GameContext.PlayerAnimationController.EditHandsLayerIndex(1);
            }
        }
    }

    public class RightHandSM : SM
    {
        public RightHandSM(SM parentSM) : base(parentSM) { }
    }

    public class LeftHandSM : SM
    {
        public LeftHandSM(SM parentSM) : base(parentSM) { }
    }

    public class ModalSM : SM
    {
        public ModalSM(SM parentSM) : base(parentSM) { }
    }
}