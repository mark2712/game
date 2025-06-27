using UnityEngine;

namespace Stats
{
    public class BaseStats : IStats
    {
        public InitStats InitStats = new();

        public LVL LVL { get; set; }
        public FloatStat Health { get; set; }
        public FloatStat Mana { get; set; }
        public FloatStat Stamina { get; set; }

        public float Stealth { get; set; }
        public float Luck { get; set; }
        public float Lockpicking { get; set; }
        public float Charisma { get; set; }

        public float Speed { get; set; }
        public Vector2 Look { get; set; }
        public Vector2 Move { get; set; }

        public BaseStats(InitStats initStats)
        {
            InitStats = initStats;

            LVL = new LVL(initStats.Level, initStats.Experience);
            Health = new FloatStat(initStats.Health.MaxValue, initStats.Health.RegenRate);
            Mana = new FloatStat(initStats.Mana.MaxValue, initStats.Mana.RegenRate);
            Stamina = new FloatStat(initStats.Stamina.MaxValue, initStats.Stamina.RegenRate);

            Stealth = initStats.Stealth;
            Luck = initStats.Luck;
            Lockpicking = initStats.Lockpicking;
            Charisma = initStats.Charisma;

            Speed = initStats.Speed;
            Look = initStats.Look;
            Move = initStats.Move;
        }

        public void Tick(float deltaTime)
        {
            Health.Regenerate(deltaTime);
            Mana.Regenerate(deltaTime);
            Stamina.Regenerate(deltaTime);
        }

        // при повышении уровня всё пересчитать
        public void Recalculate()
        {
            int lvl = LVL.Level;

            float hpBonus = lvl * 10f;
            float regenBonus = lvl * 0.1f;

            Health = new FloatStat(InitStats.Health.MaxValue + hpBonus, InitStats.Health.RegenRate + regenBonus);
            Health.CurrentValue = Health.MaxValue; // При левелапе — фулл хил

            Mana = new FloatStat(InitStats.Mana.MaxValue + lvl * 5f, InitStats.Mana.RegenRate + regenBonus);
            Mana.CurrentValue = Mana.MaxValue;

            Stamina = new FloatStat(InitStats.Stamina.MaxValue + lvl * 7f, InitStats.Stamina.RegenRate + regenBonus);
            Stamina.CurrentValue = Stamina.MaxValue;

            Stealth = InitStats.Stealth + lvl * 0.2f;
            Luck = InitStats.Luck + lvl * 0.1f;
            Lockpicking = InitStats.Lockpicking + lvl * 0.3f;
            Charisma = InitStats.Charisma + lvl * 0.15f;

            Speed = InitStats.Speed; // пока не меняем
            Look = InitStats.Look;
            Move = InitStats.Move;
        }
    }
}



// public class EntityStats // или AllStats
// {
//     public MainStats Stats = new(); // базовые характеристики
//     // шкалы
//     // а так же потом тут будут устойчивости, баффы и другие сохраняемые данные
// }



// public class FloatStat
// {
//     public float BaseValue;
//     public float CurrentValue; // может быть меньше 0 / от 0 до 100% норма, от 0 до -100% потеря сознания, меньше -100 смерть
//     public float RegenRate;

//     public FloatStat(float baseValue, float regenRate = 0f)
//     {
//         BaseValue = baseValue;
//         CurrentValue = baseValue;
//         RegenRate = regenRate;
//     }

//     // есть идея сделать события нак которые можно подписаться - достигнуто максимальное здоровье / здоровье меньше 0 / здоровье меньше (-BaseValue) / здоровье снова больше 0
//     // метод: изменить максимальное значение (если значение текущего здоровья больше макс то делаем = макс)
//     // метод: изменить текущее значение (не может привысить макс)
//     // метод: регенерация
//     public void RegenTick(float deltaTime)
//     {
//         if (CurrentValue < BaseValue)
//             CurrentValue = Mathf.Min(BaseValue, CurrentValue + RegenRate * deltaTime);
//     }
// }

// максимальное превышение (МП) пока что сделаем единым для всех = макс здоровье + 25% от макс здоровье
// метод: изменить максимальное значение (если значение текущего здоровья больше МП то делаем = МП)
// метод: изменить текущее значение (не может привысить МП)
// метод: изменить текущее значение (не может привысить МП)
// метод: регенерация работает так - если значение меньше базового то регенерация работает по обычной формуле. Если больше то наоборот здоровье отнимается по 1% в сек пока не станет 100%


// баффы
/*
кто наложил (можно использовать для передачи в эффекты)
на кого наложено
Enter
Update
Exit
Duration (продолжительность в мс), null значит вечность
*/