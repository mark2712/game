namespace States
{
    public class Hit : HitBase
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Hit;
            GameContext.PlayerAnimationController.Kick();
            StartTimer(1200);
            RegisterEvent(StateEventType.HitFinished, _ => HitFinished());
        }

        public override void Exit()
        {
            base.Exit();
            GameContext.PlayerController.NowMoveSpeed = PlayerSpeed.Get();
        }

        public override void Update()
        {
            GameContext.CameraPlayerController.Update(GameContext.InputController.LookInput);
            GameContext.PlayerController.SetMoveInput(GameContext.InputController.MoveInput); // можно немного сместиться в выбранном направлении

            if (IsTimerFinished())
            {
                SM.TriggerEvent(StateEventType.HitFinished);
            }
        }

        private State HitFinished()
        {
            if (GameContext.InputActions.Player.Mouse1.IsPressed())
            {
                return new Hit();
            }
            return SM.GetGameState();
        }
    }
}