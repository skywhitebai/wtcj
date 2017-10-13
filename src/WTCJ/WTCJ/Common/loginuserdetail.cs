using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WTCJ
{
    public class loginuserdetail
    {

        public loginuserdetail()
        {
            this.userinfo = new Model.Sys_User();
        }
        private Model.Sys_User userinfo;

        public Model.Sys_User Userinfo
        {
            get { return userinfo; }
            set { userinfo = value; }
        }
    }
}