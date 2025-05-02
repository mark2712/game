namespace States
{
    public class LegsSM : SM
    {
        public override State DefaultState => new LegsFree();

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
}