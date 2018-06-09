using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Behdar_DrugStore.Models;

namespace Behdar_DrugStore.Controlers
{
    public class PresDrugC
    {
        public BehdarDataSetTableAdapters.presdrugTableAdapter TA = new BehdarDataSetTableAdapters.presdrugTableAdapter();
        public BehdarDataSet.presdrugDataTable DT = new BehdarDataSet.presdrugDataTable();
        public BehdarDataSet.presdrugDataTable QDT = new BehdarDataSet.presdrugDataTable();
        public PrescriptionC PrescriptionC = new PrescriptionC();
        public DrugC DrugC = new DrugC();


        public List<PresDrug> All()
        {
            List<PresDrug> presdrugs = new List<PresDrug>();
            this.TA.Fill(this.DT);
            if (this.DT.Count > 0)
            {
                foreach (BehdarDataSet.presdrugRow row in this.DT)
                {
                    presdrugs.Add(PresDrug(row));
                }
            }
            return presdrugs;
        }

        public List<PresDrug> All(int org_prescription, bool qdt=false)
        {
            List<PresDrug> presdrugs = new List<PresDrug>();
            if (qdt)
            {
                this.TA.FillByPresDrugs(this.QDT, org_prescription);
                if (this.QDT.Count > 0)
                {
                    foreach (BehdarDataSet.presdrugRow row in this.QDT)
                    {
                        presdrugs.Add(PresDrug(row));
                    }
                }
            }
            else
            {
                this.TA.FillByPresDrugs(this.DT, org_prescription);
                if (this.DT.Count > 0)
                {
                    foreach (BehdarDataSet.presdrugRow row in this.DT)
                    {
                        presdrugs.Add(PresDrug(row));
                    }
                }
            }
            return presdrugs;
        }

        public PresDrug PresDrug(BehdarDataSet.presdrugRow row)
        {
            return new PresDrug(PrescriptionC.Find(int.Parse(row[0].ToString())),
                                DrugC.Find(int.Parse(row[1].ToString())),
                                int.Parse(row[2].ToString()));
        }

        public PresDrug Find(int org_prescription, int org_drug)
        {
            this.TA.FillByFind(QDT, org_prescription, org_drug);
            if (QDT.Count > 0)
            {
                return PresDrug(QDT[0]);
            }
            return new PresDrug();
        }

        public void Delete(int org_prescription, int org_drug)
        {
            this.TA.DeletePresdrug(org_prescription, org_drug);
        }

        public PresDrug Update(int amount, int org_prescription, int org_drug)
        {
            this.TA.UpdatePresdrug(amount, org_prescription, org_drug);
            return Find(org_prescription, org_drug);
        }

        public void Insert(int org_prescription, int org_drug, int amount)
        {
            this.TA.Insert(org_prescription, org_drug, amount);
        }
    }
}
