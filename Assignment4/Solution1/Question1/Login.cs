using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    public class Login
    {
        private static int totalLogins=0; //static variable 
        private DateTime loginTime; //normal variable

        public Login()
        {
            totalLogins++;
            loginTime = DateTime.Now;
        }

        public static int GetTotalLogins()
        {
            return totalLogins;
        }
        public DateTime GetLoginTime()
        {
            return loginTime;
        }
    }
}
