using UnityEngine;

namespace Entities
{
    [System.Serializable]
    public class PlayerEntity : BaseEntity
    {
        public override string EntityName => "PlayerEntity";

        void Awake()
        {
            var initStats = new Stats.InitStats();
            Stats = new Stats.BaseStats(initStats);
        }
    }
}

