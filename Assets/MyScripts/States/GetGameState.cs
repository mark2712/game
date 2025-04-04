namespace States
{
    public partial class SM
    {
        public static State GetGameState()
        {
            if (Flags.Sneak)
            {
                if (Flags.Ground)
                {
                    if (Flags.Move)
                    {
                        if (Flags.Shift)
                        {
                            return new SneakState();
                        }
                        else
                        {
                            return new SneakSlowState();
                        }
                    }
                    else
                    {
                        return new SneakStandState();
                    }
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
                    if (Flags.Move)
                    {
                        if (Flags.Shift)
                        {
                            return new MoveRunState();
                        }
                        else
                        {
                            return new MoveState();
                        }
                    }
                    else
                    {
                        return new StandState();
                    }
                }
                else
                {
                    return new MoveAirState();
                }
            }
        }
    }
}



// if (Flags.Water)
// {
//     return Flags.Shift ? new SwimFastState() : new SwimState();
// }
// else if (Flags.Fly)
// {
//     return Flags.Shift ? new FlyFastState() : new FlyState();
// }
// else 