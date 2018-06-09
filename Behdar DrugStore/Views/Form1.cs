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
    public partial class LoginForm : Form
    {
        UserC UserC = new UserC();

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

            User user = UserC.Find(username.Text);
            if(user.username != null)
            {
                if(password.Text == user.password)
                {
                    UserC.logedin_user = user;
                    Form F = new BehdarDS(UserC);
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
