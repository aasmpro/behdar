using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Behdar_DrugStore.Controlers;
using Behdar_DrugStore.Models;

namespace Behdar_DrugStore
{
    public partial class BehdarDS : Form
    {
        UserC UserC;
        DrugC DrugC = new DrugC();
        DfactoryC DfactoryC = new DfactoryC();
        InsuranceC InsuranceC = new InsuranceC();
        PresDrugC PresDrugC = new PresDrugC();
        PrescriptionC PrescriptionC = new PrescriptionC();

        string[] separators = { "[", "]", " " };
        Point p, pp;
        bool move;

        public BehdarDS(UserC uc)
        {
            InitializeComponent();
            UserC = uc;
        }

        private void BehdarDS_Load(object sender, EventArgs e)
        {
            UserC.All();
            userGridView.DataSource = UserC.DT;
            UserC.All(cbPresU);

            DrugC.All();
            drugGridView.DataSource = DrugC.DT;

            InsuranceC.All();
            insGridView.DataSource = InsuranceC.DT;
            InsuranceC.All(cbPresI);

            PresDrugC.All();
            presdrugGridView.DataSource = PresDrugC.DT;

            PrescriptionC.All();
            presGridView.DataSource = PrescriptionC.DT;

            DfactoryC.All();
            facGridView.DataSource = DfactoryC.DT;
            DfactoryC.All(cbDrugF);

            if (UserC.logedin_user.type == 1 || UserC.logedin_user.type == 2)
            {
                butUser.Visible = false;
                butSal.Visible = false;
            }
            
            presGridView_SelectionChanged(null, EventArgs.Empty);
            avaiable_buttons();
        }


        // movements
        private void ST_MouseDown(object sender, MouseEventArgs e)
        { if (e.Button == MouseButtons.Left) { move = true; p.X = e.X; p.Y = e.Y; } }
        private void ST_MouseMove(object sender, MouseEventArgs e)
        { if (move == true) { pp.X = this.Location.X + (e.X - p.X); pp.Y = this.Location.Y + (e.Y - p.Y); this.Location = pp; } }
        private void ST_MouseUp(object sender, MouseEventArgs e)
        { move = false; }


        // primary buttons click actions
        private void tbUserPE_KeyDown(object sender, KeyEventArgs e)
        { e.SuppressKeyPress = true; }
        private void exit_Click(object sender, EventArgs e)
        { Application.Exit(); }
        private void minimize_Click(object sender, EventArgs e)
        { this.WindowState = FormWindowState.Minimized; }
        private void logout_Click(object sender, EventArgs e)
        { Application.Restart(); }
        private void butRes_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabRes; avaiable_buttons(); }
        private void butDrug_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabDrug; avaiable_buttons(); }
        private void butFac_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabFac; avaiable_buttons(); }
        private void butIns_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabIns; avaiable_buttons(); }
        private void butUser_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabUser; avaiable_buttons(); }
        private void butSal_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabSal; }
        private void butVersion_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabVer; sacd_v(false); }
        private void butPresDrugs_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabResDrugs; avaiable_buttons(); }
        private void button1_Click(object sender, EventArgs e)
        { Content.SelectedTab = tabUserP; }
        private void sacd_v(bool va)
        {
            butAdd.Visible = va;
            butSave.Visible = va;
            butDelete.Visible = va;
            butCls.Visible = va;
        }
        private void avaiable_buttons()
        {
            sacd_v(true);
            butPresDrugs.Visible = true;
            button1.Visible = true;
            butAddD.Visible = true;
            butRemD.Visible = true;

            if (Content.SelectedTab == tabRes)
            {
                if(presGridView.Rows.Count == 0)
                {
                    butDelete.Visible = false;
                    butSave.Visible = false;
                    butPresDrugs.Visible = false;
                    butCls.PerformClick();
                }
            }
            else if (Content.SelectedTab == tabDrug)
            {
                if (drugGridView.Rows.Count == 0)
                {
                    butDelete.Visible = false;
                    butSave.Visible = false;
                    butCls.PerformClick();
                }
            }
            else if (Content.SelectedTab == tabFac)
            {
                if (facGridView.Rows.Count == 0)
                {
                    butDelete.Visible = false;
                    butSave.Visible = false;
                    butCls.PerformClick();
                }
            }
            else if (Content.SelectedTab == tabIns)
            {
                if (insGridView.Rows.Count == 0)
                {
                    butDelete.Visible = false;
                    butSave.Visible = false;
                    butCls.PerformClick();
                }
            }
            else if (Content.SelectedTab == tabUser)
            {
                if (userGridView.Rows.Count == 0)
                {
                    butDelete.Visible = false;
                    butSave.Visible = false;
                    button1.Visible = false;
                    butCls.PerformClick();
                }
                else if (userGridView.SelectedRows[0].Cells[0].Value.ToString() == UserC.logedin_user.username)
                {
                    butDelete.Visible = false;
                }
            }
            else if (Content.SelectedTab == tabUserP)
            {
                sacd_v(false);
                butSave.Visible = true;
            }
            else if (Content.SelectedTab == tabResDrugs)
            {
                sacd_v(false);
                if (drugsGridView.Rows.Count == 0)
                {
                    butAddD.Visible = false;
                    butCls.PerformClick();
                }
                if (presdrugGridView.Rows.Count == 0)
                {
                    butRemD.Visible = false;
                    butCls.PerformClick();
                }
            }
        }
        

        // hiding buttons based on the selected tab
        private void tabResDrugs_Enter(object sender, EventArgs e)
        {
            sacd_v(false);
            DrugC.All(true);
            drugsGridView.DataSource = DrugC.QDT;

            PresDrugC.All(int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()));
            presdrugGridView.DataSource = PresDrugC.DT;
        }
        private void tabResDrugs_Leave(object sender, EventArgs e)
        {
            sacd_v(true);
        }
        private void tabVer_Enter(object sender, EventArgs e)
        {
            sacd_v(false);
        }
        private void tabVer_Leave(object sender, EventArgs e)
        {
            sacd_v(true);
        }
        private void tabUserP_Enter(object sender, EventArgs e)
        {
            avaiable_buttons();
            tbUserUP.Text = tbUserU.Text;
            tbUserPP.Text = tbUserPPC.Text = "";
        }
        private void tabUserP_Leave(object sender, EventArgs e)
        {
            sacd_v(true);
        }


        // Getting a combo box value in Integer or String 
        private string GetCBValueS(ComboBox cb)
        {
            string[] data = cb.GetItemText(cb.SelectedItem).Split(separators, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                return data[0];
            }
            catch
            {
                return "-1";
            }
        }
        private int GetCBValueI(ComboBox cb)
        {
            return int.Parse(GetCBValueS(cb));
        }


        // handelling Error Messages
        private void Error(string err="")
        {
            if(err == "")
            {
                tbPresE.Text = err;
                tbDrugE.Text = err;
                tbDfacE.Text = err;
                tbInsE.Text = err;
                tbUserE.Text = err;
                tbUserPE.Text = err;
                return;
            }

            if (Content.SelectedTab == tabRes)
            {
                tbPresE.Text = err;
            }
            else if (Content.SelectedTab == tabDrug)
            {
                tbDrugE.Text = err;
            }
            else if (Content.SelectedTab == tabFac)
            {
                tbDfacE.Text = err;
            }
            else if (Content.SelectedTab == tabIns)
            {
                tbInsE.Text = err;
            }
            else if (Content.SelectedTab == tabUser)
            {
                tbUserE.Text = err;
            }
            else if (Content.SelectedTab == tabUserP)
            {
                tbUserPE.Text = err;
            }
        }
        

        // selection changed, setting values.
        private void insGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (insGridView.SelectedRows.Count > 0)
            {
                tbInsN.Text = insGridView.SelectedRows[0].Cells[1].Value.ToString();
                nmInsOff.Value = decimal.Parse(insGridView.SelectedRows[0].Cells[2].Value.ToString());
            }
        }
        private void presGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (presGridView.SelectedRows.Count > 0)
            {
                tbPresN.Text = presGridView.SelectedRows[0].Cells[1].Value.ToString();
                tbPresNC.Text = presGridView.SelectedRows[0].Cells[2].Value.ToString();
                cbPresI.SelectedIndex = cbPresI.FindString(string.Format("[{0}]", presGridView.SelectedRows[0].Cells[4].Value.ToString()));
                cbPresU.SelectedIndex = cbPresU.FindString(string.Format("{0}", presGridView.SelectedRows[0].Cells[3].Value.ToString()));
                if (presGridView.SelectedRows[0].Cells[3].Value.ToString() == "")
                {
                    cbPresU.SelectedIndex = -1;
                }
                FilltbACs(int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(presGridView.SelectedRows[0].Cells[4].Value.ToString()));
                tbPresData.Text = string.Format("نام و نام خانوادگی بیمار: {0} \t کد ملی بیمار: {1}", tbPresN.Text, tbPresNC.Text);
            }
        }
        private void drugGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (drugGridView.SelectedRows.Count > 0)
            {
                tbDrugN.Text = drugGridView.SelectedRows[0].Cells[1].Value.ToString();
                tbDrugT.Text = drugGridView.SelectedRows[0].Cells[2].Value.ToString();
                nmDrugP.Value = int.Parse(drugGridView.SelectedRows[0].Cells[3].Value.ToString());
                nmDrugA.Value = int.Parse(drugGridView.SelectedRows[0].Cells[5].Value.ToString());
                cbDrugF.SelectedIndex = cbDrugF.FindString(string.Format("[{0}]", drugGridView.SelectedRows[0].Cells[4].Value.ToString()));
            }
        }
        private void facGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (facGridView.SelectedRows.Count > 0)
            {
                tbFacN.Text = facGridView.SelectedRows[0].Cells[1].Value.ToString();
                tbFacI.Text = facGridView.SelectedRows[0].Cells[2].Value.ToString();
            }
        }
        private void userGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (userGridView.SelectedRows.Count > 0)
            {
                tbUserU.Text = userGridView.SelectedRows[0].Cells[0].Value.ToString();
                tbUserN.Text = userGridView.SelectedRows[0].Cells[2].Value.ToString();
                tbUserL.Text = userGridView.SelectedRows[0].Cells[3].Value.ToString();
                tbUserNC.Text = userGridView.SelectedRows[0].Cells[4].Value.ToString();
                cbUserT.SelectedIndex = int.Parse(userGridView.SelectedRows[0].Cells[5].Value.ToString());
                cbUserS.SelectedIndex = int.Parse(userGridView.SelectedRows[0].Cells[6].Value.ToString());

                if(tbUserU.Text == UserC.logedin_user.username)
                {
                    butDelete.Visible = false;
                }
                else
                {
                    butDelete.Visible = true;
                }
            }
        }
        private void drugsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (drugsGridView.SelectedRows.Count > 0)
            {
                nmAddD.Maximum = int.Parse(drugsGridView.SelectedRows[0].Cells[5].Value.ToString());
            }
        }


        // Clearing TBs. NMs and CBs
        private void butCls_Click(object sender, EventArgs e)
        {
            Error();
            tbPresN.Text = tbPresNC.Text = tbPresE.Text = "";
            tbDrugN.Text = tbDrugT.Text = tbDrugE.Text = "";
            tbFacN.Text = tbFacI.Text = tbDfacE.Text = tbInsN.Text = tbInsE.Text = "";
            tbUserU.Text = tbUserN.Text = tbUserL.Text = tbUserNC.Text = tbUserPP.Text = tbUserPPC.Text = "";
            nmDrugA.Value = nmDrugP.Value = nmInsOff.Value = 0;
            cbPresI.SelectedIndex = cbPresU.SelectedIndex = cbDrugF.SelectedIndex = cbUserS.SelectedIndex = cbUserT.SelectedIndex = -1;
        }


        // Inserting new records to db
        private void butAdd_Click(object sender, EventArgs e)
        {
            if (Content.SelectedTab == tabRes)
            {
                InsertPres();
            }
            else if (Content.SelectedTab == tabDrug)
            {
                InsertDrug();
            }
            else if (Content.SelectedTab == tabFac)
            {
                InsertDFac();
            }
            else if (Content.SelectedTab == tabIns)
            {
                InsertIns();
            }
            else if (Content.SelectedTab == tabUser)
            {
                InsertUser();
            }
        }
        private void InsertPres(bool update=false)
        {
            Error();
            int Pins = GetCBValueI(cbPresI);
            string Puser = GetCBValueS(cbPresU);
            if(Puser == "-1")
            {
                Error("لطفا یک کاربر را به عنوان ثبت کننده نسخه انتخاب کنید");
                return;
            }
            if (tbPresN.Text == "")
            {
                Error("لطفا نام و نام خانوادگی بیمار را وارد کنید");
                return;
            }
            if (tbPresNC.Text == "")
            {
                Error("لطفا کدملی بیمار را وارد کنید");
                return;
            }

            if (update)
            {
                PrescriptionC.Update(flname: tbPresN.Text, ncode: tbPresNC.Text, creator: Puser, insurance: Pins, date: DateTime.Now, int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()));
            }
            else
            {
                PrescriptionC.Insert(flname: tbPresN.Text, ncode: tbPresNC.Text, creator: Puser, insurance: Pins, date: DateTime.Now);
            }
            
            PrescriptionC.All();
            presGridView.Refresh();
            avaiable_buttons();
        }
        private void InsertDrug(bool update = false)
        {
            Error();
            int Ddfac = GetCBValueI(cbDrugF);
            if (tbDrugN.Text == "")
            {
                Error("لطفا نام دارو را وارد کنید");
                return;
            }
            if (tbDrugT.Text == "")
            {
                Error("لطفا نوع دارو را وارد کنید");
                return;
            }

            if (update)
            {
                DrugC.Update(tbDrugN.Text, tbDrugT.Text, int.Parse(nmDrugP.Value.ToString()), Ddfac, int.Parse(nmDrugA.Value.ToString()), int.Parse(drugGridView.SelectedRows[0].Cells[0].Value.ToString()));
            }
            else
            {
                DrugC.Insert(tbDrugN.Text, tbDrugT.Text, int.Parse(nmDrugP.Value.ToString()), Ddfac, int.Parse(nmDrugA.Value.ToString()));
            }

            DrugC.All();
            drugGridView.Refresh();
            presGridView_SelectionChanged(null, EventArgs.Empty);
            avaiable_buttons();
        }
        private void InsertDFac(bool update = false)
        {
            Error();
            if (tbFacN.Text == "")
            {
                Error("لطفا نام داروسازی را وارد کنید");
                return;
            }
            if (tbFacI.Text == "")
            {
                Error("لطفا اطلاعات داروسازی را وارد کنید");
                return;
            }

            if (update)
            {
                DfactoryC.Update(tbFacN.Text, tbFacI.Text, int.Parse(facGridView.SelectedRows[0].Cells[0].Value.ToString()));
            }
            else
            {
                DfactoryC.Insert(tbFacN.Text, tbFacI.Text);
            }
            
            DfactoryC.All();
            facGridView.Refresh();
            DfactoryC.All(cbDrugF);
            avaiable_buttons();
        }
        private void InsertIns(bool update = false)
        {
            Error();
            if (tbInsN.Text == "")
            {
                Error("لطفا نام بیمه را وارد کنید");
                return;
            }

            if (update)
            {
                InsuranceC.Update(tbInsN.Text, float.Parse(nmInsOff.Value.ToString()), int.Parse(insGridView.SelectedRows[0].Cells[0].Value.ToString()));
            }
            else
            {
                InsuranceC.Insert(tbInsN.Text, float.Parse(nmInsOff.Value.ToString()));
            }

            InsuranceC.All();
            insGridView.Refresh();
            InsuranceC.All(cbPresI);
            avaiable_buttons();
        }
        private void InsertUser(bool update = false)
        {
            Error();
            if (tbUserU.Text == "")
            {
                Error("لطفا نام کاربری را وارد کنید");
                return;
            }
            else if (update == false)
            {
                User user = UserC.Find(tbUserU.Text);
                if (user.username != null)
                {
                    Error("این نام کاربری در سیستم موجود است لطفا نام کاربری دیگری را وارد کنید");
                    return;
                }
            }
            if (tbUserN.Text == "")
            {
                Error("لطفا نام کاربر را وارد کنید");
                return;
            }
            else if (tbUserL.Text == "")
            {
                Error("لطفا نام خانوادگی کاربر را وارد کنید");
                return;
            }
            else if (tbUserNC.Text == "")
            {
                Error("لطفا کدملی کاربر را وارد کنید");
                return;
            }
            else if (cbUserT.SelectedIndex == -1)
            {
                Error("لطفا نوع اکانت کاربری را مشخص کنید");
                return;
            }
            else if (cbUserS.SelectedIndex == -1)
            {
                Error("لطفا وضعیت اکانت کاربری را مشخص کنید");
                return;
            }

            if (update)
            {
                if (userGridView.SelectedRows[0].Cells[0].Value.ToString() != tbUserU.Text )
                {
                    User user = UserC.Find(tbUserU.Text);
                    if (user.username != null)
                    {
                        Error("این نام کاربری در سیستم موجود است لطفا نام کاربری دیگری را وارد کنید");
                        return;
                    }
                }

                UserC.Update(tbUserU.Text, tbUserN.Text, tbUserL.Text, tbUserNC.Text, cbUserT.SelectedIndex, cbUserS.SelectedIndex, userGridView.SelectedRows[0].Cells[0].Value.ToString());
                if(UserC.logedin_user.username == userGridView.SelectedRows[0].Cells[0].Value.ToString())
                {
                    UserC.logedin_user = UserC.Find(tbUserU.Text);
                }
            }
            else
            {
                UserC.Insert(tbUserU.Text, tbUserU.Text, tbUserN.Text, tbUserL.Text, tbUserNC.Text, cbUserT.SelectedIndex, cbUserS.SelectedIndex);
                MessageBox.Show("کلمه عبور کاربر جدید، بصورت پیشفرض برابر با نام کاربری کاربر است");
            }

            UserC.All();
            userGridView.Refresh();
            UserC.All(cbPresU);
            avaiable_buttons();
        }
        private void butAddD_Click(object sender, EventArgs e)
        {
            if (int.Parse(nmAddD.Value.ToString()) < 1){
                nmAddD.Value = 1;
            }
            int pres = int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString());
            int drug = int.Parse(drugsGridView.SelectedRows[0].Cells[0].Value.ToString());
            PresDrug pd = PresDrugC.Find(pres, drug);
            if(pd.prescription.id > -1)
            {
                int nam = int.Parse(nmAddD.Value.ToString()) + pd.amount;
                PresDrugC.Update(nam, pres, drug);
            }
            else
            {
                PresDrugC.Insert(pres, drug, int.Parse(nmAddD.Value.ToString()));
            }

            int mam = int.Parse(drugsGridView.SelectedRows[0].Cells[5].Value.ToString()) - int.Parse(nmAddD.Value.ToString());
            DrugC.Update(mam, drug);

            DrugC.All(true);
            drugsGridView.DataSource = DrugC.DT;

            PresDrugC.All(int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()));
            presdrugGridView.DataSource = PresDrugC.DT;

            DrugC.All();
            drugGridView.Refresh();
            avaiable_buttons();

            FilltbACs(int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(presGridView.SelectedRows[0].Cells[4].Value.ToString()));
        }
        
        
        // Updateing records
        private void butSave_Click(object sender, EventArgs e)
        {
            if (Content.SelectedTab == tabRes)
            {
                InsertPres(true);
            }
            else if (Content.SelectedTab == tabDrug)
            {
                InsertDrug(true);
            }
            else if (Content.SelectedTab == tabFac)
            {
                InsertDFac(true);
            }
            else if (Content.SelectedTab == tabIns)
            {
                InsertIns(true);
            }
            else if (Content.SelectedTab == tabUser)
            {
                InsertUser(true);
            }
            else if (Content.SelectedTab == tabUserP)
            {
                avaiable_buttons();
                InsertUserP();
            }
        }
        private void InsertUserP()
        {
            Error();
            if (tbUserPP.Text == "")
            {
                Error("لطفا کلمه عبور جدید را وارد کنید");
                return;
            }
            else if(tbUserPP.Text != tbUserPPC.Text)
            {
                Error("تکرار کلمه عبور وارد شده با کلمه عبور بالا برابر نیست ");
                return;
            }

            UserC.Update(tbUserPP.Text, tbUserUP.Text);
            Content.SelectedTab = tabUser;
            MessageBox.Show("کلمه عبور جدید ثبت شد");
        }

        
        // Deleteing records
        private void butDelete_Click(object sender, EventArgs e)
        {
            if (Delete_Message("داده انتخاب شده حذف شود؟"))
            {
                if (Content.SelectedTab == tabRes)
                {
                    PrescriptionC.Delete(int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()));
                    PrescriptionC.All();
                    presGridView.Refresh();
                    avaiable_buttons();
                }
                else if (Content.SelectedTab == tabDrug)
                {
                    try
                    {
                        DrugC.Delete(int.Parse(drugGridView.SelectedRows[0].Cells[0].Value.ToString()));
                    }
                    catch
                    {
                        MessageBox.Show("به دلیل وجود ارجاعاتی در نسخه ها به این دارو، این دارو قابل حذف نیست");
                    }
                    DrugC.All();
                    drugGridView.Refresh();
                    avaiable_buttons();
                }
                else if (Content.SelectedTab == tabFac)
                {
                    DfactoryC.Delete(int.Parse(facGridView.SelectedRows[0].Cells[0].Value.ToString()));
                    DfactoryC.All();
                    facGridView.Refresh();
                    DfactoryC.All(cbDrugF);
                    DrugC.All();
                    drugGridView.Refresh();
                    avaiable_buttons();
                }
                else if (Content.SelectedTab == tabIns)
                {
                    InsuranceC.Delete(int.Parse(insGridView.SelectedRows[0].Cells[0].Value.ToString()));
                    InsuranceC.All();
                    insGridView.Refresh();
                    InsuranceC.All(cbPresI);
                    DrugC.All();
                    drugGridView.Refresh();
                    PrescriptionC.All();
                    presGridView.Refresh();
                    avaiable_buttons();
                }
                else if (Content.SelectedTab == tabUser)
                {
                    UserC.Delete(userGridView.SelectedRows[0].Cells[0].Value.ToString());
                    UserC.All();
                    userGridView.Refresh();
                    UserC.All(cbPresU);
                    PrescriptionC.All();
                    presGridView.Refresh();
                    avaiable_buttons();
                }
            }
        }
        private bool Delete_Message(string text, string title="")
        {
            return MessageBox.Show(text, title, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        private void butRemD_Click(object sender, EventArgs e)
        {
            int pres = int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString());
            int drugi = int.Parse(presdrugGridView.SelectedRows[0].Cells[0].Value.ToString());
            Drug drug = DrugC.Find(drugi);

            PresDrugC.Delete(pres, drugi);

            int nam = int.Parse(presdrugGridView.SelectedRows[0].Cells[1].Value.ToString()) + drug.amount;
            DrugC.Update(nam, drugi);
            
            DrugC.All(true);
            drugsGridView.DataSource = DrugC.QDT;

            PresDrugC.All(int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()));
            presdrugGridView.DataSource = PresDrugC.DT;
            
            DrugC.All();
            drugGridView.Refresh();
            avaiable_buttons();

            FilltbACs(int.Parse(presGridView.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(presGridView.SelectedRows[0].Cells[4].Value.ToString()));
        }


        // Accounting
        private float PresPrice(int pres, int ins, out int drugs_amount, out int real_price)
        {
            float off=0;
            PresDrugC.All(pres, true);
            drugs_amount = 0;
            real_price = 0;
            for (int i = 0; i < PresDrugC.QDT.Count(); i++)
            {
                Drug drug = DrugC.Find(int.Parse(PresDrugC.QDT.Rows[i][1].ToString()), true);
                real_price += int.Parse(PresDrugC.QDT.Rows[i][2].ToString()) * drug.price;
                drugs_amount += int.Parse(PresDrugC.QDT.Rows[i][2].ToString());
            }

            Insurance insurance = InsuranceC.Find(ins);
            if(insurance.id > -1)
            {
                off = insurance.off / 100;
            }

            return real_price - (real_price * off);
        }
        private void FilltbACs(int pres, int ins)
        {
            int drugs_amount, real_price;
            float price = PresPrice(pres, ins, out drugs_amount, out real_price);
            tbPresACP.Text = tbPresACD.Text = string.Format("تعداد داروهای نسخه: {0} \t/\t قیمت بدون بیمه: {1} (تومان) \t/\t قیمت با بیمه: {2} (تومان)",drugs_amount, real_price, price);
        }


        // Project Github Repository
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
