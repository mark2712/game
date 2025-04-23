using UnityEngine;

namespace States
{
    public class Move : BaseMove
    {
        protected Vector2 moveInput = GameContext.PlayerController.MoveInput;
        protected int dirX = 2;
        protected int dirY = 2;

        public override void Enter()
        {
            base.Enter();
            UpdateAnimation();
        }

        public override void Update()
        {
            base.Update();
            moveInput = GameContext.InputController.MoveInput;
            UpdateAnimation();
        }

        // public override State MoveInput(Vector2 moveInput)
        // {
        //     // base.MoveInput(moveInput);
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
                    case (0, 1): GameContext.PlayerAnimationController.MoveForward(); break;
                    case (0, -1): GameContext.PlayerAnimationController.MoveBackward(); break;
                    case (1, 0): GameContext.PlayerAnimationController.MoveRight(); break;
                    case (-1, 0): GameContext.PlayerAnimationController.MoveLeft(); break;
                    case (1, 1): GameContext.PlayerAnimationController.MoveForwardRight(); break;
                    case (-1, 1): GameContext.PlayerAnimationController.MoveForwardLeft(); break;
                    case (1, -1): GameContext.PlayerAnimationController.MoveBackwardRight(); break;
                    case (-1, -1): GameContext.PlayerAnimationController.MoveBackwardLeft(); break;
                }
            }
        }
    }
}