using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Behdar_DrugStore.Models;

namespace Behdar_DrugStore.Controlers
{
    public class PrescriptionC
    {
        public BehdarDataSetTableAdapters.prescriptionTableAdapter TA = new BehdarDataSetTableAdapters.prescriptionTableAdapter();
        public BehdarDataSet.prescriptionDataTable DT = new BehdarDataSet.prescriptionDataTable();
        public BehdarDataSet.prescriptionDataTable QDT = new BehdarDataSet.prescriptionDataTable();
        public UserC UserC = new UserC();
        public InsuranceC InsuranceC = new InsuranceC();

        public List<Prescription> All()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            this.TA.Fill(this.DT);
            if (this.DT.Count > 0)
            {
                foreach (BehdarDataSet.prescriptionRow row in this.DT)
                {
                    prescriptions.Add(Prescription(row));
                }
            }
            return prescriptions;
        }

        public Prescription Prescription(BehdarDataSet.prescriptionRow row)
        {
            return new Prescription(int.Parse(row[0].ToString()),
                                    row[1].ToString(),
                                    row[2].ToString(),
                                    UserC.Find(row[3].ToString()),
                                    InsuranceC.Find(int.Parse(row[4].ToString())),
                                    DateTime.Parse(row[5].ToString()));
        }

        public Prescription Find(int org_id)
        {
            this.TA.FillByFind(this.QDT, org_id);
            if (this.QDT.Count > 0)
            {
                return Prescription(this.QDT[0]);
            }
            return new Prescription();
        }

        public void Delete(int org_id)
        {
            this.TA.DeletePrescription(org_id);
        }

        public Prescription Update(string flname, string ncode, string creator, int insurance, DateTime date, int org_id)
        {
            if(insurance > -1)
            {
                this.TA.UpdatePrescription(flname, ncode, creator, insurance, date, org_id);
            }
            else
            {
                this.TA.UpdatePrescription(flname, ncode, creator, null, date, org_id);
            }
            return Find(org_id);
        }

        public void Insert(string flname, string ncode, string creator, int insurance, DateTime date)
        {
            this.TA.Insert(flname, ncode, creator, insurance, date);
        }
    }
}
