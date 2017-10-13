using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WTCJ.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        BLL.Department BLL = new BLL.Department();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <returns></returns>
        public string List(string DepartmentName)
        {
            string where = "";
            if (!string.IsNullOrEmpty(DepartmentName) && CommonHelper.filterSql(DepartmentName))
            {
                where += "DepartmentName like '%" + DepartmentName + "%'";
            }
            int total = BLL.GetRecordCount(where);
            int pageSize = Convert.ToInt32(Request["rows"]);
            int pageNum = Convert.ToInt32(Request["page"]);
            int startIndex = (pageNum - 1) * pageSize + 1;
            int endIndex = pageNum * pageSize;
            if (total >= startIndex)
            {
                DataSet ds = BLL.GetListByPage(where, " OrderBy asc", startIndex, endIndex);
                String strJson = JsonHelper.GetJsonFromDataSet(ds, total);
                return strJson;
            }
            else
            {
                String strJson = JsonHelper.GetJsonFromDataTable(null, total);
                return strJson;
            }
        }
        /// <summary>
        /// 保存数据字典数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(Model.Department model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.DepartmentName))
            {
                sbErro.Append(",部门名称不能为空");
            }
            if (model.OrderBy == null)
            {
                sbErro.Append(",排序不能为空");
            }
            if (sbErro.Length > 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = sbErro.ToString().Substring(1);
                return Json(json);
            }
            //如果ID为空，则是添加
            if (string.IsNullOrEmpty(model.DepartmentID))
            {
                //DepartmentName 唯一
                List<Model.Department> modelExistsList = BLL.GetModelList("DepartmentName='" + model.DepartmentName + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                model.CreateTime = DateTime.Now;
                model.CreateBy = CurrentUser.User.Userinfo.UserID;
                model.DepartmentID = Guid.NewGuid().ToString();
                bool res = BLL.Add(model);
                if (res)
                {
                    json.Status = JsonObject.STATUS_SUCCESS;
                    json.Message = "添加成功";
                    return Json(json);
                }
                else
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败";
                    return Json(json);
                }
            }
            else
            {
                //value 和 type 唯一确定一个text值
                List<Model.Department> modelExistsList = BLL.GetModelList("DepartmentName='" + model.DepartmentName + "' and DepartmentID!='" + model.DepartmentID + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                Model.Department modelOld = BLL.GetModel(model.DepartmentID);
                if (modelOld == null)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "数据不存在";
                    return Json(json);
                }
                modelOld.DepartmentName = model.DepartmentName;
                modelOld.OrderBy = model.OrderBy;
                modelOld.Remark = model.Remark;
                modelOld.UpdateTime = DateTime.Now;
                modelOld.UpdateBy = CurrentUser.User.Userinfo.UserID;
                bool res = BLL.Update(modelOld);
                if (res)
                {
                    json.Status = JsonObject.STATUS_SUCCESS;
                    json.Message = "修改成功";
                    return Json(json);
                }
                else
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "修改失败";
                    return Json(json);
                }
            }
        }
        /// <summary>
        /// 保存数据字典数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(string IDS)
        {
            JsonObject json = new JsonObject();
            if (string.IsNullOrEmpty(IDS))
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "请选择要删除的数据";
                return Json(json);
            }
            String[] IDArry = IDS.Trim(',').Split(',');
            StringBuilder IDlist = new StringBuilder();
            if (IDArry == null || IDArry.Length == 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "请选择要删除的数据";
                return Json(json);
            }

            for (int i = 0; i < IDArry.Length; i++)
            {
                if (CommonHelper.filterSql(IDArry[i]))
                {
                    IDlist.Append(",'");
                    IDlist.Append(IDArry[i]);
                    IDlist.Append("'");
                }
            }
            bool res = BLL.DeleteList(IDlist.ToString().Substring(1));
            if (res)
            {
                json.Status = JsonObject.STATUS_SUCCESS;
                json.Message = "删除成功";
                return Json(json);
            }
            else
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "删除失败";
                return Json(json);
            }
        }
        /// <summary>
        /// 获取下拉json数据
        /// </summary>
        /// <returns></returns>
        public string getComboboxJson()
        {
            DataSet ds = BLL.GetList(" 1=1  order by OrderBy asc");
            if (ds != null && ds.Tables.Count > 0)
            {
                return JsonHelper.CreateComboboxJson(ds.Tables[0], "DepartmentId", "DepartmentName");
            }
            else
            {
                return JsonHelper.CreateComboboxJson(null, "", "");
            }
        }
    }
}
