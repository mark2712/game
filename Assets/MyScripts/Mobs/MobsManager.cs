using System.Collections.Generic;

namespace Mobs
{
    public class MobsManager : ISaveLoad
    {
        private Dictionary<string, Mob> Mobs = new();

        private List<Mob> GetListMobs()
        {
            return null;
        }

        public string Save()
        {
            return "";
        }

        public void Load(string str)
        {

        }
    }
}