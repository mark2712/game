using System;
using UnityEngine;

namespace Stats
{
    public class FloatStat
    {
        public float BaseValue;    // Базовое значение (например, 100)
        public float MaxOverflow;  // Сколько максимум можно превысить базу (например, 25%)
        public float RegenRate;    // Регенерация вниз (в обычную сторону)

        public float CurrentValue;

        // События
        public Action OnDeath;
        public Action OnKnockout;
        public Action OnOverflow;
        public Action OnBackToLife;

        public FloatStat(float baseValue, float regenRate, float currentValue = -1f, float maxOverflow = 0.25f)
        {
            BaseValue = baseValue;
            RegenRate = regenRate;
            MaxOverflow = maxOverflow;
            CurrentValue = currentValue >= 0 ? currentValue : baseValue;
        }

        public float MaxValue => BaseValue * (1f + MaxOverflow);

        public void ChangeCurrentValue(float amount)
        {
            float oldValue = CurrentValue;
            CurrentValue += amount;
            CurrentValue = Mathf.Clamp(CurrentValue, -BaseValue * 2, MaxValue);

            // События
            if (oldValue > 0 && CurrentValue <= 0)
                OnKnockout?.Invoke();

            // if (oldValue > -BaseValue && CurrentValue <= -BaseValue)
            //     OnDeath?.Invoke();

            // if (oldValue <= BaseValue && CurrentValue > BaseValue)
            //     OnOverflow?.Invoke();

            // if (oldValue <= 0 && CurrentValue > 0)
            //     OnBackToLife?.Invoke();
        }

        public void ChangeBaseValue(float amount)
        {
            BaseValue += amount;
            if (CurrentValue > MaxValue)
                CurrentValue = MaxValue;
        }

        public void Regenerate(float deltaTime)
        {
            if (CurrentValue < BaseValue)
            {
                ChangeCurrentValue(RegenRate * deltaTime);
            }
            else if (CurrentValue > BaseValue)
            {
                // Перегретый HP теряет 1% от Base в секунду
                ChangeCurrentValue(-BaseValue * 0.01f * deltaTime);
            }
        }
    }

    // public class FloatStat
    // {
    //     public float MaxValue;
    //     public float CurrentValue;
    //     public float RegenRate;

    //     public FloatStat(float maxValue, float regenRate, float currentValue = 0)
    //     {
    //         MaxValue = maxValue;
    //         CurrentValue = currentValue;
    //         RegenRate = regenRate;
    //     }

    //     public void Regenerate(float deltaTime)
    //     {
    //         if (CurrentValue < MaxValue)
    //             ChangeCurrentValue(RegenRate * deltaTime);
    //     }

    //     public void ChangeCurrentValue(float amount)
    //     {
    //         CurrentValue = Mathf.Clamp(CurrentValue + amount, -MaxValue * 2, MaxValue);
    //     }

    //     public void ChangeMaxValue(float amount)
    //     {
    //         MaxValue += amount;
    //         if (CurrentValue > MaxValue)
    //             CurrentValue = MaxValue;
    //     }
    // }
}