using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behdar_DrugStore.Models
{
    public class Drug
    {
        public string name, type;
        public int id, amount, price;
        public Dfactory dfactory;

        public Drug()
        {
            this.name = this.type = null;
            this.id = this.amount = this.price = -1;
            this.dfactory = new Dfactory();
        }

        public Drug(int id, string name, string type, int price, Dfactory dfactory, int amount)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.price = price;
            this.dfactory = dfactory;
            this.amount = amount;
        }

        public override string ToString()
        {
            return this.name;
        }

        public override bool Equals(object obj)
        {
            Drug d = (Drug)obj;
            if (this.id == d.id)
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
