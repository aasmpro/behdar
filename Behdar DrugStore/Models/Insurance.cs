using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behdar_DrugStore.Models
{
    public class Insurance
    {
        public string name;
        public int id;
        public float off;

        public Insurance()
        {
            this.id = -1;
            this.name = null;
            this.off = -1;
        }

        public Insurance(int id, string name, float off)
        {
            this.id = id;
            this.name = name;
            this.off = off;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", this.id, this.name);
        }

        public override bool Equals(object obj)
        {
            Insurance i = (Insurance)obj;
            if (this.id == i.id)
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
