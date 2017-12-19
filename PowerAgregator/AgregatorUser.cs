using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PowerAgregator
{
    public class AgregatorUser
    {
        public string Name { get; set; }
        public virtual List<ChatterUser> Chatters { get; set; } = new List<ChatterUser>();
        public ChatterUser ActiveDialog;
        public DateTime DialogExpire;

        public AgregatorUser(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Empty id is not allowed");
            Name = name;
            Chatters = new List<ChatterUser>();
        }

        public override string ToString()
        {
            return Name;
        }

        public AgregatorUser() { }
        public AgregatorUser(AgregatorUserData data)
        {
            this.Name = data.Name;
        }

        public AgregatorUserData StoreData()
        {
            return new AgregatorUserData
            {
                Name = Name
            };
        }
    }
}