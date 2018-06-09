using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Behdar_DrugStore
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void exit_Click(object sender, EventArgs e)
        { Application.Exit(); }

        private void login_Click(object sender, EventArgs e)
        {
            errorbox.Text = "";
            if (username.Text == "")
            {
                errorbox.Text = "لطفا نام کاربری را وارد کنید.";
                return;
            }
            else if(password.Text == "")
            {
                errorbox.Text = "لطفا کلمه عبور را وارد کنید.";
                return;
            }

            Data.userTA.FillByFind(Data.userDT, username.Text);
            if(Data.userDT.Count > 0)
            {
                if(password.Text == Data.userDT.Rows[0][1].ToString())
                {
                    Data.logedin_username = username.Text;
                    Data.logedin_type = Data.userDT.Rows[0][5].ToString();
                    Form F = new BehdarDS();
                    this.Hide();
                    F.ShowDialog();
                }
                else
                {
                    errorbox.Text = "کلمه عبور اشتباه است.";
                    return;
                }
            }
            else
            {
                errorbox.Text = "نام کاربری اشتباه است.";
                return;
            }
        }

        private void errorbox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        
    }
}
