using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Behdar_DrugStore.Models;

namespace Behdar_DrugStore.Controlers
{
    public class DrugC
    {
        public BehdarDataSetTableAdapters.drugTableAdapter TA = new BehdarDataSetTableAdapters.drugTableAdapter();
        public BehdarDataSet.drugDataTable DT = new BehdarDataSet.drugDataTable();
        public BehdarDataSet.drugDataTable QDT = new BehdarDataSet.drugDataTable();
        public BehdarDataSet.drugDataTable ADT = new BehdarDataSet.drugDataTable();
        public DfactoryC DfactoryC = new DfactoryC();

        public List<Drug> All(bool exist=false)
        {
            List<Drug> druges = new List<Drug>();
            if (exist)
            {
                this.TA.FillByExistDrug(this.QDT);
                if (this.QDT.Count > 0)
                {
                    foreach (BehdarDataSet.drugRow row in this.QDT)
                    {
                        druges.Add(Drug(row));
                    }
                }
            }
            else
            {
                this.TA.Fill(this.DT);
                if (this.DT.Count > 0)
                {
                    foreach (BehdarDataSet.drugRow row in this.DT)
                    {
                        druges.Add(Drug(row));
                    }
                }
            }
            return druges;
        }

        public Drug Drug(BehdarDataSet.drugRow row)
        {
            return new Drug(int.Parse(row[0].ToString()),
                            row[1].ToString(),
                            row[2].ToString(),
                            int.Parse(row[3].ToString()),
                            DfactoryC.Find(int.Parse(row[4].ToString())),
                            int.Parse(row[5].ToString())
                            );
        }

        public Drug Find(int org_id, bool adt=false)
        {
            if (adt)
            {
                this.TA.FillByFind(ADT, org_id);
                if (this.ADT.Count > 0)
                {
                    return Drug(this.ADT[0]);
                }
                return new Drug();
            }
            this.TA.FillByFind(this.QDT, org_id);
            if (this.QDT.Count > 0)
            {
                return Drug(this.QDT[0]);
            }
            return new Drug();
        }

        public void Delete(int org_id)
        {
            this.TA.DeleteDrug(org_id);
        }

        public Drug Update(string name, string type, int price, int dfactory, int amount, int org_id)
        {
            if(dfactory > -1)
            {
                this.TA.UpdateDrug(name, type, price, dfactory, amount, org_id);
            }
            else
            {
                this.TA.UpdateDrug(name, type, price, null, amount, org_id);
            }
            return Find(org_id);
        }

        public Drug Update(int amount, int org_id)
        {
            this.TA.UpdateDrugAmount(amount, org_id);
            return Find(org_id);
        }

        public void Insert(string name, string type, int price, int dfactory, int amount)
        {
            if (dfactory > -1)
            {
                this.TA.Insert(name, type, price, dfactory, amount);
            }
            else
            {
                this.TA.Insert(name, type, price, null, amount);
            }
        }
    }
}
