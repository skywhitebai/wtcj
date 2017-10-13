using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTCJ.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginIn(string LoginID, string Password)
        {
            String erro = "";
            JsonObject json = new JsonObject();
            if (String.IsNullOrEmpty(LoginID))
            {
                erro += ",用户名不能为空";
            }
            else
            {
                LoginID = LoginID.Trim();
            }
            if (String.IsNullOrEmpty(Password))
            {
                erro += ",密码不能为空";
            }
            else
            {
                Password = Password.Trim();
            }
            //如果参数错误，则返回错误信息
            if (!String.IsNullOrEmpty(erro))
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = erro.Substring(1);
                return Json(json);
            }
            List<Model.Sys_User> userList=new BLL.Sys_User().GetModelList("LoginID='"+LoginID+"'");
            //如果用户为空，则返回错误信息
            if(userList==null||userList.Count==0){
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "用户名不存在";
                return Json(json);
            }
            Model.Sys_User user = userList[0];
            //如果密码错误
            if (!String.Equals("1", user.IsValid))
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "用户已停用";
                return Json(json);
            }
            //如果密码错误
            if (!String.Equals(Password, user.Password))
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "用户名密码错误";
                return Json(json);
            }
            //登陆成功 存储session信息
            new UserService().UserLogin(user);
            json.Status = JsonObject.STATUS_SUCCESS;
            return Json(json);
        }
        public ActionResult LoginOut()
        {
            JsonObject json = new JsonObject();
            new UserService().UserLoginOut();
            json.Status = JsonObject.STATUS_SUCCESS;
            return Json(json);
        }
        public ActionResult getCurrentUserName()
        {   
            JsonObject json = new JsonObject();
            json.Status = JsonObject.STATUS_SUCCESS;
            json.Data = CurrentUser.User.Userinfo.UserName;
            return Json(json);
        }
    }
}
