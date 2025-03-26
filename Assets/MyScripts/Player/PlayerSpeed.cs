public static class PlayerSpeed
{
    public static float Base = 3.5f;
    // public static float Run;
    // public static float Sneak;
    // public static float SneakSlow;

    static PlayerSpeed()
    {
        // Run = Sneak = SneakSlow = Base = 3.8f;
    }

    public static float Get()
    {
        if (States.Flags.Sneak)
        {
            if (States.Flags.Shift)
            {
                return Base * 0.62f;
            }
            else
            {
                return Base * 0.42f;
            }
        }
        else
        {
            if (States.Flags.Shift)
            {
                return Base * 2;
            }
            else
            {
                return Base;
            }
        }
    }
}