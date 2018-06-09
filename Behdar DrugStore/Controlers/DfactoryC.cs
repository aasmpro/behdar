using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Behdar_DrugStore.Models;

namespace Behdar_DrugStore.Controlers
{
    public class DfactoryC
    {
        public BehdarDataSetTableAdapters.dfactoryTableAdapter TA = new BehdarDataSetTableAdapters.dfactoryTableAdapter();
        public BehdarDataSet.dfactoryDataTable DT = new BehdarDataSet.dfactoryDataTable();
        public BehdarDataSet.dfactoryDataTable QDT = new BehdarDataSet.dfactoryDataTable();

        public List<Dfactory> All()
        {
            List<Dfactory> dfactories = new List<Dfactory>();
            this.TA.Fill(this.DT);
            if (this.DT.Count > 0)
            {
                foreach (BehdarDataSet.dfactoryRow row in this.DT)
                {
                    dfactories.Add(Dfactory(row));
                }
            }
            return dfactories;
        }

        public void All(ComboBox cb)
        {
            cb.Items.Clear();
            if (this.DT.Count > 0)
            {
                foreach (BehdarDataSet.dfactoryRow row in this.DT)
                {
                    cb.Items.Add(string.Format("[{0}] {1}", row[0], row[1]));
                }
            }
        }

        public Dfactory Dfactory(BehdarDataSet.dfactoryRow row)
        {
            return new Dfactory(int.Parse(row[0].ToString()),
                                row[1].ToString(),
                                row[2].ToString());
        }
        
        public Dfactory Find(int org_id)
        {
            TA.FillByFind(this.QDT, org_id);
            if (this.QDT.Count > 0)
            {
                return Dfactory(this.QDT[0]);
            }
            return new Dfactory();
        }

        public void Delete(int org_id)
        {
            TA.DeleteDfactory(org_id);
        }

        public Dfactory Update(string name, string data, int org_id)
        {
            TA.UpdateDfactory(name, data, org_id);
            return new Dfactory(org_id, name, data);
        }

        public void Insert(string name, string data)
        {
            TA.Insert(name, data);
        }
    }
}
