using UnityEngine;

namespace States
{
    public class SneakState : SneakStateBase
    {
        protected Vector2 moveInput = GameContext.playerController.MoveInput;
        protected int dirX = 2;
        protected int dirY = 2;

        public override void Enter()
        {
            base.Enter();
            UpdateAnimation();

            // GameContext.playerAnimationController.Sneak();
        }

        public override void Update()
        {
            base.Update();
            UpdateAnimation();
        }

        public override void MoveInput(Vector2 moveInput)
        {
            base.MoveInput(moveInput);
            this.moveInput = moveInput;
        }

        private void UpdateAnimation()
        {
            // Вычисляем новое направление
            int dirXnew = moveInput.x > 0 ? 1 : moveInput.x < 0 ? -1 : 0;
            int dirYnew = moveInput.y > 0 ? 1 : moveInput.y < 0 ? -1 : 0;

            // Если направление изменилось, обновляем анимацию
            if (dirXnew != dirX || dirYnew != dirY)
            {
                dirX = dirXnew;
                dirY = dirYnew;

                switch ((dirX, dirY))
                {
                    case (0, 1): GameContext.playerAnimationController.MoveSlowForward(); break;
                    case (0, -1): GameContext.playerAnimationController.MoveSlowBackward(); break;
                    case (1, 0): GameContext.playerAnimationController.MoveSlowRight(); break;
                    case (-1, 0): GameContext.playerAnimationController.MoveSlowLeft(); break;
                    case (1, 1): GameContext.playerAnimationController.MoveSlowForwardRight(); break;
                    case (-1, 1): GameContext.playerAnimationController.MoveSlowForwardLeft(); break;
                    case (1, -1): GameContext.playerAnimationController.MoveSlowBackwardRight(); break;
                    case (-1, -1): GameContext.playerAnimationController.MoveSlowBackwardLeft(); break;
                }
            }
        }
    }
}