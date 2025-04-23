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
                            return new Sneak();
                        }
                        else
                        {
                            return new SneakSlow();
                        }
                    }
                    else
                    {
                        return new SneakStand();
                    }
                }
                else
                {
                    return new SneakAir();
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
                            return new MoveRun();
                        }
                        else
                        {
                            return new Move();
                        }
                    }
                    else
                    {
                        return new Stand();
                    }
                }
                else
                {
                    return new MoveAir();
                }
            }
        }
    }
}



// if (Flags.Water)
// {
//     return Flags.Shift ? new SwimFast() : new Swim();
// }
// else if (Flags.Fly)
// {
//     return Flags.Shift ? new FlyFast() : new Fly();
// }
// else 