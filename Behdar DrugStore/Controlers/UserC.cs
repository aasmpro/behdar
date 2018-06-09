using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Behdar_DrugStore.Models;

namespace Behdar_DrugStore.Controlers
{
    public class UserC
    {
        public BehdarDataSetTableAdapters.userTableAdapter TA = new BehdarDataSetTableAdapters.userTableAdapter();
        public BehdarDataSet.userDataTable DT = new BehdarDataSet.userDataTable();
        public BehdarDataSet.userDataTable QDT = new BehdarDataSet.userDataTable();
        public User logedin_user = new User();

        public List<User> All()
        {
            List<User> users = new List<User>();
            this.TA.Fill(this.DT);
            if(this.DT.Count > 0)
            {
                foreach (BehdarDataSet.userRow row in this.DT)
                {
                    users.Add(User(row));
                }
            }
            return users;
        }

        public void All(ComboBox cb)
        {
            cb.Items.Clear();
            if (this.DT.Count > 0)
            {
                foreach (BehdarDataSet.userRow row in this.DT)
                {
                    cb.Items.Add(string.Format("{0}", row[0]));
                }
            }
        }

        public User User(BehdarDataSet.userRow row)
        {
            return new User(row[0].ToString(),
                            row[1].ToString(),
                            row[2].ToString(),
                            row[3].ToString(),
                            row[4].ToString(),
                            int.Parse(row[5].ToString()),
                            int.Parse(row[6].ToString()));
        }

        public User Find(string org_username)
        {
            this.TA.FillByFind(this.QDT, org_username);
            if(this.QDT.Count > 0)
            {
                return User(this.QDT[0]);
            }
            return new User();
        }

        public void Delete(string org_username)
        {
            this.TA.DeleteUser(org_username);
        }

        public User Update(string username, string fname, string lname, string ncode, int type, int status, string org_username)
        {
            this.TA.UpdateLocals(username, fname, lname, ncode, type, status, org_username);
            return Find(username);
        }

        public User Update(string password, string org_username)
        {
            this.TA.UpdatePassword(password, org_username);
            return Find(org_username);
        }

        public void Insert(string username, string password, string fname, string lname, string ncode, int type, int status)
        {
            this.TA.Insert(username, password, fname, lname, ncode, type, status);
        }
    }
}
