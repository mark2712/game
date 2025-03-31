using UnityEngine;

namespace States
{
    public class StandState : BaseMoveState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.playerAnimationController.Stand();
            GameContext.emotionController.SetEmotion("Neutral", 800f);
        }
    }
}