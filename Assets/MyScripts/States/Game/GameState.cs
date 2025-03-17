using System;

namespace States
{
    public class GameState : State
    {
        public override void Enter()
        {
            throw new Exception("Нельзя напрямую войти в GameState");
        }

        public override State GetGameState()
        {
            if (Flags.Sneak)
            {
                if (Flags.Ground)
                {
                    return Flags.Shift ? new SneakSlowState() : new SneakState();
                }
                else
                {
                    return new SneakAirState();
                }
            }
            else
            {
                if (Flags.Ground)
                {
                    return Flags.Shift ? new MoveRunState() : new MoveState();
                }
                else
                {
                    return new MoveAirState();
                }
            }
        }
    }
}



// public override State GetGameState()
// {
//     // if (Flags.Water)
//     // {
//     //     return Flags.Shift ? new SwimFastState() : new SwimState();
//     // }
//     // else if (Flags.Fly)
//     // {
//     //     return Flags.Shift ? new FlyFastState() : new FlyState();
//     // }
//     // else 
//     if (Flags.Sneak)
//     {
//         if (Flags.Ground)
//         {
//             return Flags.Shift ? new SneakSlowState() : new SneakState();
//         }
//         else
//         {
//             return new SneakAirState();
//         }
//     }
//     else
//     {
//         if (Flags.Ground)
//         {
//             return Flags.Shift ? new MoveRunState() : new MoveState();
//         }
//         else
//         {
//             return new MoveAirState();
//         }
//     }
// }

// // public void ChooseGameState()
// // {
// //     GoToState(new GameState());
// // }