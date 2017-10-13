using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WTCJ.Controllers
{
    public class UserColumnsController : Controller
    {
        //
        // GET: /UserColumns/
        BLL.User_Columns BLL = new BLL.User_Columns();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(Model.User_Columns model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.type))
            {
                sbErro.Append(",类型不能为空");
            }
            if (string.IsNullOrEmpty(model.tableName))
            {
                sbErro.Append(",表名不能为空");
            }
            if (string.IsNullOrEmpty(model.hideColumns))
            {
                sbErro.Append(",隐藏列不能为空");
            }
            model.UserID = CurrentUser.User.Userinfo.UserID;
            List<Model.User_Columns> modelExistsList = BLL.GetModelList("type='" + model.type + "' AND tableName='" + model.tableName + "' AND UserId='" + model.UserID + "'");
            bool res = false;
            if (modelExistsList != null && modelExistsList.Count > 0)
            {
                Model.User_Columns modelOld = modelExistsList[0];
                modelOld.hideColumns = model.hideColumns;
                modelOld.UpdateBy = model.UserID;
                modelOld.UpdateTime = DateTime.Now;
                res = BLL.Update(modelOld);
            }
            else
            {
                model.id = Guid.NewGuid().ToString();
                model.CreateBy = model.UserID;
                model.CreateTime = DateTime.Now;
                res = BLL.Add(model);
            }
            if (res)
            {
                json.Status = JsonObject.STATUS_SUCCESS;
                json.Message = "保存成功";
                return Json(json);
            }
            else
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "保存失败";
                return Json(json);
            }
        }
        public ActionResult GetHideColumns(Model.User_Columns model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.type))
            {
                sbErro.Append(",类型不能为空");
            }
            if (string.IsNullOrEmpty(model.tableName))
            {
                sbErro.Append(",表名不能为空");
            }
            model.UserID = CurrentUser.User.Userinfo.UserID;
            List<Model.User_Columns> modelExistsList = BLL.GetModelList("type='" + model.type + "' AND tableName='" + model.tableName + "' AND UserId='" + model.UserID + "'");
            if (modelExistsList != null && modelExistsList.Count > 0)
            {
                json.Data = modelExistsList[0].hideColumns.Trim(',');
            }
            else
            {
                json.Data = "";
            }
            json.Status = JsonObject.STATUS_SUCCESS;
            json.Message = "获取成功";
            return Json(json);
        }

    }
}
