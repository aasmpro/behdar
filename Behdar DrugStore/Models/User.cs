using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behdar_DrugStore.Models
{
    public class User
    {
        public string username, password, fname, lname, ncode;
        public int type, status;

        public User()
        {
            this.username = this.password = this.fname = this.lname = this.ncode = null;
            this.type = this.status = -1;
        }

        public User(string username, string password, string fname, string lname, string ncode, int type, int status)
        {
            this.username = username;
            this.password = password;
            this.fname = fname;
            this.lname = lname;
            this.ncode = ncode;
            this.type = type;
            this.status = status;
        }

        public override string ToString()
        {
            return this.username;
        }

        public override bool Equals(object obj)
        {
            User u = (User)obj;
            if (this.username == u.username)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.username.GetHashCode();
        }
    }
}
