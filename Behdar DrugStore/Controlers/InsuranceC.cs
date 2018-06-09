using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Behdar_DrugStore.Models;

namespace Behdar_DrugStore.Controlers
{
    public class InsuranceC
    {
        public BehdarDataSetTableAdapters.insuranceTableAdapter TA = new BehdarDataSetTableAdapters.insuranceTableAdapter();
        public BehdarDataSet.insuranceDataTable DT = new BehdarDataSet.insuranceDataTable();
        public BehdarDataSet.insuranceDataTable QDT = new BehdarDataSet.insuranceDataTable();

        public List<Insurance> All()
        {
            List<Insurance> insurances = new List<Insurance>();
            this.TA.Fill(this.DT);
            if (this.DT.Count > 0)
            {
                foreach (BehdarDataSet.insuranceRow row in this.DT)
                {
                    insurances.Add(Insurance(row));
                }
            }
            return insurances;
        }

        public void All(ComboBox cb)
        {
            cb.Items.Clear();
            if (this.DT.Count > 0)
            {
                foreach (BehdarDataSet.insuranceRow row in this.DT)
                {
                    cb.Items.Add(string.Format("[{0}] {1}", row[0], row[1]));
                }
            }
        }

        public Insurance Insurance(BehdarDataSet.insuranceRow row)
        {
            return new Insurance(int.Parse(row[0].ToString()),
                                row[1].ToString(),
                                float.Parse(row[2].ToString()));
        }
        
        public Insurance Find(int id)
        {
            this.TA.FillByFind(this.QDT, id);
            if (this.QDT.Count > 0)
            {
                return Insurance(this.QDT[0]);
            }
            return new Insurance();
        }

        public void Delete(int id)
        {
            this.TA.DeleteInsurance(id);
        }

        public Insurance Update(string name, float off, int org_id)
        {
            this.TA.UpdateInsurance(name, off, org_id);
            return new Insurance(org_id, name, off);
        }

        public void Insert(string name, float off)
        {
            this.TA.Insert(name, off);
        }
    }
}
