public static class PlayerSpeed
{
    public static float Base = 3.5f;
    public static float Run;
    public static float Sneak;
    public static float SneakSlow;

    static PlayerSpeed()
    {
        Run = Base * 2f;
        Sneak = Base * 0.62f;
        SneakSlow = Base * 0.42f;
    }

    public static float Get()
    {
        if (States.Flags.Sneak)
        {
            if (States.Flags.Shift)
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
            if (States.Flags.Shift)
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