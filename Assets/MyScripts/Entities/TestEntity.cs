using UnityEngine;

namespace Entities
{
    [System.Serializable]
    public class TestEntity : BaseEntity
    {
        public override string EntityName => "TestEntity";
        public override Stats.BaseStats Stats { get; set; } // задать статы по умолчанию для этой сущности
    }

    public class EntitySpawner // пока что этот класс просто спавнить заранее запрограммированыые сущности
    {
        // получить список сущностей из файла сохранения
        // заспавнить сущность с нужными статами. Если статов у этой сущности нет то будет спавн с её стандартными статами

        // получить статы 
    }

    public class EntityLoader // пока что этот класс просто спавнить заранее запрограммированыые сущности
    {
        // получить список сущностей из файла сохранения
        // заспавнить сущность с нужными статами. Если статов у этой сущности нет то будет спавн с её стандартными статами

        // получить статы 
    }
}

