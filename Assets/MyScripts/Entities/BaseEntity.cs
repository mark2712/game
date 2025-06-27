using UnityEngine;

namespace Entities
{
    [System.Serializable]
    public abstract class BaseEntity : MonoBehaviour
    {
        public virtual string EntityName { get; set; }
        public virtual string EntityPrefabPath { get; set; }
        public virtual Stats.BaseStats Stats { get; set; }
        public virtual string Vectors { get; set; } // тут надо придумать название свойства, здесь будут координаты, повороты и размеры 

        void Awake()
        {
            var initStats = new Stats.InitStats();
            Stats = new Stats.BaseStats(initStats);
            // ещё надо получить EntityPrefabPath
        }

        public void FixedUpdate()
        {
            Stats.Tick(Time.deltaTime);
        }

        public void ReceiveDamage(float amount)
        {
            Stats.Health.ChangeCurrentValue(-amount);
            Debug.Log($"{EntityName} получил {amount} урона. Текущее здоровье: {Stats.Health.CurrentValue}");
        }

        public void Spawn() { }
        public void Save() { }
        public void Load() { }

        // protected virtual void Update()
        // {
        //     Stats.Tick(Time.deltaTime);
        // }

    }
}

// public ResistanceBlock Resistances;

// public List<Effect> ActiveEffects = new();
// public List<Buff> ActiveBuffs = new();

// public void ApplyEffect(Effect effect) { /* Проверка устойчивости и добавление */ }
// public void ApplyBuff(Buff buff) { /* Проверка иммунитетов и т. д. */ }
// public void Tick(float deltaTime) { /* Апдейт баффов и эффектов */ }