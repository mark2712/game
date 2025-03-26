namespace States
{
    public class MoveAirState : AirState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.emotionController.SetEmotion("Surprised", 50f);
        }
    }
}