using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Behdar_DrugStore
{
    class Data
    {
        public static string logedin_username;
        public static string logedin_type;

        public static BehdarDataSetTableAdapters.userTableAdapter userTA = new BehdarDataSetTableAdapters.userTableAdapter();
        public static BehdarDataSet.userDataTable userDT = new BehdarDataSet.userDataTable();
        public static BehdarDataSet.userDataTable userQDT = new BehdarDataSet.userDataTable();

        public static BehdarDataSetTableAdapters.prescriptionTableAdapter prescriptionTA = new BehdarDataSetTableAdapters.prescriptionTableAdapter();
        public static BehdarDataSet.prescriptionDataTable prescriptionDT = new BehdarDataSet.prescriptionDataTable();
        public static BehdarDataSet.prescriptionDataTable prescriptionQDT = new BehdarDataSet.prescriptionDataTable();

        public static BehdarDataSetTableAdapters.insuranceTableAdapter insuranceTA = new BehdarDataSetTableAdapters.insuranceTableAdapter();
        public static BehdarDataSet.insuranceDataTable insuranceDT = new BehdarDataSet.insuranceDataTable();
        public static BehdarDataSet.insuranceDataTable insuranceQDT = new BehdarDataSet.insuranceDataTable();

        public static BehdarDataSetTableAdapters.drugTableAdapter drugTA = new BehdarDataSetTableAdapters.drugTableAdapter();
        public static BehdarDataSet.drugDataTable drugDT = new BehdarDataSet.drugDataTable();
        public static BehdarDataSet.drugDataTable drugQDT = new BehdarDataSet.drugDataTable();
        public static BehdarDataSet.drugDataTable drugADT = new BehdarDataSet.drugDataTable();

        public static BehdarDataSetTableAdapters.presdrugTableAdapter presdrugTA = new BehdarDataSetTableAdapters.presdrugTableAdapter();
        public static BehdarDataSet.presdrugDataTable presdrugDT = new BehdarDataSet.presdrugDataTable();
        public static BehdarDataSet.presdrugDataTable presdrugQDT = new BehdarDataSet.presdrugDataTable();

        public static BehdarDataSetTableAdapters.dfactoryTableAdapter dfactoryTA = new BehdarDataSetTableAdapters.dfactoryTableAdapter();
        public static BehdarDataSet.dfactoryDataTable dfactoryDT = new BehdarDataSet.dfactoryDataTable();
        public static BehdarDataSet.dfactoryDataTable dfactoryQDT = new BehdarDataSet.dfactoryDataTable();
        

        public static void FillUser()
        {
            userTA.Fill(userDT);
        }

        public static void FillDrug()
        {
            drugTA.Fill(drugDT);
        }

        public static void FillInsurance()
        {
            insuranceTA.Fill(insuranceDT);
        }

        public static void FillPresDrug()
        {
            presdrugTA.Fill(presdrugDT);
        }

        public static void FillPrescription()
        {
            prescriptionTA.Fill(prescriptionDT);
        }

        public static void FillDFactory()
        {
            dfactoryTA.Fill(dfactoryDT);
        }

        public static void FillAll()
        {
            FillInsurance();
            FillPrescription();
            FillPresDrug();
            FillDFactory();
            FillUser();
            FillDrug();
        }

        public static void FillCB(ComboBox cb, string data)
        {
            cb.Items.Clear();
            if (data == "insurance")
            {
                for (int i = 0; i < Data.insuranceDT.Count(); i++)
                {
                    cb.Items.Add(string.Format("[{0}] {1}", Data.insuranceDT.Rows[i][0], Data.insuranceDT.Rows[i][1]));
                }
            }
            else if (data == "user")
            {
                for (int i = 0; i < Data.userDT.Count(); i++)
                {
                    cb.Items.Add(string.Format("{0}", Data.userDT.Rows[i][0]));
                }
            }
            else if (data == "dfactory")
            {
                for (int i = 0; i < Data.dfactoryDT.Count(); i++)
                {
                    cb.Items.Add(string.Format("[{0}] {1}", Data.dfactoryDT.Rows[i][0], Data.dfactoryDT.Rows[i][1]));
                }
            }
        }
    }
}
