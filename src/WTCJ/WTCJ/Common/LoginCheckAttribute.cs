using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTCJ
{
    public class LoginCheckAttribute : ActionFilterAttribute
    {//执行Action之前操作
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAuthenticated = HttpContext.Current.Session["loginuser"] == null ? false : true;
            List<string> unLoginUrl = new List<string>();
            unLoginUrl.Add("/account/login");
            unLoginUrl.Add("/account/loginin");
            unLoginUrl.Add("/account/loginout"); //判断是否登录或是否用权限，如果有那么就进行相应的操作，否则跳转到登录页或者授权页面
            if (!isAuthenticated && !unLoginUrl.Contains(filterContext.HttpContext.Request.Url.LocalPath.ToLower().Trim('\\')))
            {
                //跳转到登录页面
                filterContext.HttpContext.Response.Redirect("/account/login");
            }
            else
            {
                if (filterContext.ActionParameters != null && filterContext.ActionParameters.Count > 0)
                {
                    //获取去除前后空格的参数
                    Dictionary<string, object> ActionParametersUpdate = new Dictionary<string, object>();
                    if (filterContext.ActionParameters.Keys != null)
                    {
                        foreach (string key in filterContext.ActionParameters.Keys)
                        {
                            object value = filterContext.ActionParameters[key];
                            if (value!=null&&value.GetType() == typeof(string) && value.ToString() != "")
                            {
                                ActionParametersUpdate.Add(key, value.ToString().Trim());
                            }
                        }
                    }
                    //去除空格后的参数赋值给filterContext.ActionParameters
                    if (ActionParametersUpdate != null && ActionParametersUpdate.Count > 0)
                    {
                        foreach (string key in ActionParametersUpdate.Keys)
                        {
                            filterContext.ActionParameters[key] = ActionParametersUpdate[key];
                        }
                    }
                }
                //处理Action之前操作内容根据我们提供的规则来定义这部分内容
                base.OnActionExecuting(filterContext);
            }

        }
    }
}