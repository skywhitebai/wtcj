using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;

namespace WTCJ.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        BLL.Company BLL = new BLL.Company();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <returns></returns>
        public string List(string CompanyName)
        {
            string where = " IsDeleted!=1 ";
            if (!string.IsNullOrEmpty(CompanyName) && CommonHelper.filterSql(CompanyName))
            {
                where += " and CompanyName like '%" + CompanyName + "%'";
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
        public ActionResult Save(Model.Company model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.CompanyName))
            {
                sbErro.Append(",客户名称不能为空");
            }
            if (sbErro.Length > 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = sbErro.ToString().Substring(1);
                return Json(json);
            }
            //如果ID为空，则是添加
            if (string.IsNullOrEmpty(model.id))
            {
                //DepartmentName 唯一
                List<Model.Company> modelExistsList = BLL.GetModelList("CompanyName='" + model.CompanyName + "' and IsDeleted!=1 ");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                model.IsDeleted = 0;
                model.CreateTime = DateTime.Now;
                model.CreateBy = CurrentUser.User.Userinfo.UserID;
                model.id = Guid.NewGuid().ToString();
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
                List<Model.Company> modelExistsList = BLL.GetModelList("CompanyName='" + model.CompanyName + "' and id!='" + model.id + "' and IsDeleted!=1 ");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                Model.Company modelOld = BLL.GetModel(model.id);
                if (modelOld == null)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "数据不存在";
                    return Json(json);
                }
                if (modelOld.IsDeleted == 1)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "数据已删除";
                    return Json(json);
                }
                modelOld.CompanyName = model.CompanyName;
                modelOld.Linkman = model.Linkman;
                modelOld.Telephone = model.Telephone;
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
        /// 保存数据数据
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
            int DoCount = 0;
            for (int i = 0; i < IDArry.Length; i++)
            {
                if (CommonHelper.filterSql(IDArry[i]))
                {
                    Model.Company model = BLL.GetModel(IDArry[i]);
                    if (model != null)
                    {
                        model.IsDeleted = 1;
                        BLL.Update(model);
                        DoCount++;
                    }
                }
            }
            if (DoCount > 0)
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
            DataSet ds = BLL.GetList(" IsDeleteD!=1  order by OrderBy asc");
            if (ds != null && ds.Tables.Count > 0)
            {
                return JsonHelper.CreateComboboxJson(ds.Tables[0], "id", "CompanyName");
            }
            else
            {
                return JsonHelper.CreateComboboxJson(null, "", "");
            }
        }

    }
}
