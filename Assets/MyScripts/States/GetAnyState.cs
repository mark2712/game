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

        public static State GetEnvState()
        {
            if (Flags.Get(FlagName.Fly))
            {
                return new BaseGame(); // состояние полёт
            }
            else if (Flags.Get(FlagName.Air))
            {
                return new BaseGame(); // состояние воздух
            }
            else if (Flags.Get(FlagName.Water))
            {
                return new BaseGame(); // состояние вода
            }
            else if (Flags.Get(FlagName.WaterBody))
            {
                if (Flags.Get(FlagName.Shift) || Flags.Get(FlagName.Sneak))
                {
                    return new BaseGame(); // состояние вода
                }
            }
            return new BaseGame(); // состояние земля
        }


        public static void GetEnvState1()
        {
            if (Flags.Get(FlagName.Fly))
            {
                // состояние полёт
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