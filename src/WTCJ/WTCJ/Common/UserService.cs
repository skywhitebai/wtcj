using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WTCJ
{
    public class UserService : Page
    {
        private loginuserdetail _loginuserdetail = new loginuserdetail();

        #region 公开方法

        /// <summary>
        /// 用户登陆信息
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public loginuserdetail UserLogin(Model.Sys_User currentUser)
        {
            loginuserdetail login =new loginuserdetail();
            login.Userinfo = currentUser;
            Session["LoginUser"] = login;
            return login;
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        /// <returns></returns>
        public bool UserLoginOut()
        {
            Session["LoginUser"] = null;
            return false;
        }
        #endregion
    }
}