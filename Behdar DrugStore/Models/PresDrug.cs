using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behdar_DrugStore.Models
{
    public class PresDrug
    {
        public Prescription prescription;
        public Drug drug;
        public int amount;

        public PresDrug()
        {
            this.prescription = new Prescription();
            this.drug = new Drug();
            this.amount = -1;
        }

        public PresDrug(Prescription prescription, Drug drug, int amount)
        {
            this.prescription = prescription;
            this.drug = drug;
            this.amount = amount;
        }

        public override bool Equals(object obj)
        {
            PresDrug pd = (PresDrug)obj;
            if (this.prescription == pd.prescription && this.drug == pd.drug)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.prescription.GetHashCode() + this.drug.GetHashCode();
        }
    }
}
