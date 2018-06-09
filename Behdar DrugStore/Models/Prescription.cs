using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behdar_DrugStore.Models
{
    public class Prescription
    {
        public string flname, ncode;
        public int id;
        public User creator;
        public Insurance insurance;
        public DateTime date;

        public Prescription()
        {
            this.flname = this.ncode = null;
            this.id = -1;
            this.creator = new User();
            this.insurance = new Insurance();
            this.date = DateTime.Now;
        }

        public Prescription(int id, string flname, string ncode, User creator, Insurance insurance, DateTime date)
        {
            this.id = id;
            this.flname = flname;
            this.ncode = ncode;
            this.creator = creator;
            this.insurance = insurance;
            this.date = date;
        }

        public override string ToString()
        {
            return this.flname;
        }

        public override bool Equals(object obj)
        {
            Prescription p = (Prescription)obj;
            if (this.id == p.id)
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
