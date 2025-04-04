using UnityEngine;

namespace States
{
    public class StandState : BaseMoveState
    {
        public override void Enter()
        {
            base.Enter();
            GameContext.PlayerAnimationController.Stand();
            GameContext.EmotionController.SetEmotion("Neutral", 800f);
        }
    }
}