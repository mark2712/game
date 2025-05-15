public class MainStats
{
    public int Level = 1;

    public FloatStat Health = new(100f, 5f);     // base, regen
    public FloatStat Mana = new(50f, 2f);
    public FloatStat Stamina = new(60f, 3f);

    public float Stealth = 1.0f;
    public float Lockpicking = 0.0f;
    public float Luck = 0.0f;
    public float Charisma = 0.0f;

    public void Tick(float deltaTime)
    {
        Health.RegenTick(deltaTime);
        Mana.RegenTick(deltaTime);
        Stamina.RegenTick(deltaTime);
    }
}

public class FloatStat
{
    public float BaseValue;
    public float CurrentValue;
    public float RegenRate;

    public FloatStat(float baseValue, float regenRate = 0f)
    {
        BaseValue = baseValue;
        CurrentValue = baseValue;
        RegenRate = regenRate;
    }

    public void RegenTick(float deltaTime)
    {
        if (CurrentValue < BaseValue)
            CurrentValue = Mathf.Min(BaseValue, CurrentValue + RegenRate * deltaTime);
    }
}