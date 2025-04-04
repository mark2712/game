namespace States
{
    public class MoveAirState : AirState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.EmotionController.SetEmotion("Surprised", 50f);
        }
    }
}