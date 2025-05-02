using States;

public static class PlayerSpeed
{
    public static float Base = 3.5f;
    public static float Run;
    public static float Sneak;
    public static float SneakSlow;
    public static float Hit;

    static PlayerSpeed()
    {
        Run = Base * 2f;
        Sneak = Base * 0.62f;
        SneakSlow = Base * 0.42f;
        Hit = Base * 0.12f;
    }

    public static float Get()
    {
        if (Flags.Get(FlagName.Sneak))
        {
            if (Flags.Get(FlagName.Shift))
            {
                return Sneak;
            }
            else
            {
                return SneakSlow;
            }
        }
        else
        {
            if (Flags.Get(FlagName.Shift))
            {
                return Run;
            }
            else
            {
                return Base;
            }
        }
    }
}