namespace States
{
    public partial class SM
    {
        public static State GetGameState()
        {
            if (Flags.Get(FlagName.Sneak))
            {
                if (Flags.Get(FlagName.Ground))
                {
                    if (Flags.Get(FlagName.Move))
                    {
                        if (Flags.Get(FlagName.Shift))
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
                if (Flags.Get(FlagName.Ground))
                {
                    if (Flags.Get(FlagName.Move))
                    {
                        if (Flags.Get(FlagName.Shift))
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

        public static State GetLegsState()
        {
            if (Flags.Get(FlagName.LegsRope))
            {
                return new LegsRope();
            }
            else
            {
                return new LegsFree();
            }
        }

        public static State GetHandsState()
        {
            if (Flags.Get(FlagName.HandsRope))
            {
                return new HandsRope();
            }
            else
            {
                return new HandsFree();
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