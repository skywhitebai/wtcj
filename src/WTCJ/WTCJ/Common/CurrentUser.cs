using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WTCJ
{
    public class CurrentUser
    {
        public static loginuserdetail User
        {
            get { return (loginuserdetail)HttpContext.Current.Session["loginuser"]; }
        }
    }
}