using UnityEngine;

namespace States
{
    public class SneakState : BaseSneakState
    {
        protected Vector2 moveInput = GameContext.PlayerController.MoveInput;
        protected int dirX = 2;
        protected int dirY = 2;

        public override void Enter()
        {
            base.Enter();
            UpdateAnimation();

            // GameContext.playerAnimationController.Sneak();
        }

        public override State Update()
        {
            base.Update();
            moveInput = GameContext.InputController.MoveInput;
            GameContext.CameraPlayerController.SetLookInput(GameContext.InputController.LookInput);
            UpdateAnimation();
            return null;
        }

        // public override State MoveInput(Vector2 moveInput)
        // {
        //     base.MoveInput(moveInput);
        //     this.moveInput = moveInput;
        //     return null;
        // }

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
                    case (0, 1): GameContext.PlayerAnimationController.MoveSlowForward(); break;
                    case (0, -1): GameContext.PlayerAnimationController.MoveSlowBackward(); break;
                    case (1, 0): GameContext.PlayerAnimationController.MoveSlowRight(); break;
                    case (-1, 0): GameContext.PlayerAnimationController.MoveSlowLeft(); break;
                    case (1, 1): GameContext.PlayerAnimationController.MoveSlowForwardRight(); break;
                    case (-1, 1): GameContext.PlayerAnimationController.MoveSlowForwardLeft(); break;
                    case (1, -1): GameContext.PlayerAnimationController.MoveSlowBackwardRight(); break;
                    case (-1, -1): GameContext.PlayerAnimationController.MoveSlowBackwardLeft(); break;
                }
            }
        }
    }
}