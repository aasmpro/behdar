using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behdar_DrugStore.Models
{
    public class Dfactory
    {
        public string name, data;
        public int id;

        public Dfactory()
        {
            this.name = this.data = null;
            this.id = -1;
        }

        public Dfactory(int id, string name, string data)
        {
            this.id = id;
            this.name = name;
            this.data = data;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", this.id, this.name);
        }

        public override bool Equals(object obj)
        {
            Dfactory df = (Dfactory)obj;
            if (this.id == df.id)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}
