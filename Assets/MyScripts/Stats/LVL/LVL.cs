using System;
using UnityEngine;

namespace Stats
{
    public class LVL
    {
        public int Level;
        public float Experience;

        public const float baseExp = 100f;
        public const float expFactor = 1.2f;

        public event Action OnLevelUp;

        public LVL(int level = 1, float experience = 0)
        {
            Level = level;
            Experience = experience;
        }

        public void AddExperience(float amount)
        {
            Experience += amount;
            TryLevelUp();
        }

        private void TryLevelUp()
        {
            while (Experience >= GetRequiredExp(Level))
            {
                Experience -= GetRequiredExp(Level);
                Level++;
                Debug.Log($"Level up! New level: {Level}");
                OnLevelUp?.Invoke();
            }
        }

        private float GetRequiredExp(int level)
        {
            return baseExp * Mathf.Pow(level, expFactor);
        }
    }
    // public class LVL
    // {
    //     public int Level;
    //     public float Experience;

    //     public const float baseExp = 100f; // опыт, необходимый для перехода с 1 на 2 уровень
    //     public const float expFactor = 1.2f; // насколько сложнее каждый следующий уровень

    //     public LVL(int level = 1, float experience = 0)
    //     {
    //         Level = level;
    //         Experience = experience;
    //     }

    //     // Метод прибавления опыта
    //     public void AddExperience(float amount)
    //     {
    //         Experience += amount;
    //         TryLevelUp();
    //     }

    //     // Проверка на повышение уровня
    //     private void TryLevelUp()
    //     {
    //         while (Experience >= GetRequiredExp(Level))
    //         {
    //             Experience -= GetRequiredExp(Level);
    //             Level++;
    //             OnLevelUp();
    //         }
    //     }

    //     // Опыт, необходимый для повышения уровня
    //     private float GetRequiredExp(int level)
    //     {
    //         return baseExp * Mathf.Pow(level, expFactor);
    //     }

    //     // Метод можно переопределить или подписаться на событие
    //     private void OnLevelUp()
    //     {
    //         Debug.Log($"Level up! New level: {Level}");
    //     }
    // }
}