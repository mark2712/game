using UnityEngine;

namespace States
{
    public class MoveState : MoveStateBase
    {
        protected Vector2 moveInput = GameContext.playerController.MoveInput;
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
                    case (0, 1): GameContext.playerAnimationController.MoveForward(); break;
                    case (0, -1): GameContext.playerAnimationController.MoveBackward(); break;
                    case (1, 0): GameContext.playerAnimationController.MoveRight(); break;
                    case (-1, 0): GameContext.playerAnimationController.MoveLeft(); break;
                    case (1, 1): GameContext.playerAnimationController.MoveForwardRight(); break;
                    case (-1, 1): GameContext.playerAnimationController.MoveForwardLeft(); break;
                    case (1, -1): GameContext.playerAnimationController.MoveBackwardRight(); break;
                    case (-1, -1): GameContext.playerAnimationController.MoveBackwardLeft(); break;
                        // default: GameContext.playerAnimationController.Stand(); break;
                }
            }
        }
    }
}


// public State GetGameMoveState(Vector2 moveInput)
// {
//     int dirX = moveInput.x > 0 ? 1 : moveInput.x < 0 ? -1 : 0;
//     int dirY = moveInput.y > 0 ? 1 : moveInput.y < 0 ? -1 : 0;

//     return (dirX, dirY) switch
//     {
//         (0, 1) => new MoveForwardState(),
//         (0, -1) => new MoveBackwardState(),
//         (1, 0) => new MoveRightState(),
//         (-1, 0) => new MoveLeftState(),
//         (1, 1) => new MoveForwardRightState(),
//         (-1, 1) => new MoveForwardLeftState(),
//         (1, -1) => new MoveBackwardRightState(),
//         (-1, -1) => new MoveBackwardLeftState(),
//         _ => new MoveState()
//     };
// }