using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;
namespace WTCJ.Controllers
{
    public class CommonDataController : Controller
    {
        //
        // GET: /CommonData/
        BLL.Common_Data BLL = new BLL.Common_Data();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <returns></returns>
        public string List(string DataType)
        {
            string where = "";
            if (!string.IsNullOrEmpty(DataType) && CommonHelper.filterSql(DataType))
            {
                where += "DataType like '%" + DataType + "%'";
            }
            int total = BLL.GetRecordCount(where);
            int pageSize = Convert.ToInt32(Request["rows"]);
            int pageNum = Convert.ToInt32(Request["page"]);
            int startIndex = (pageNum - 1) * pageSize + 1;
            int endIndex = pageNum * pageSize;
            if (total >= startIndex)
            {
                DataSet ds = BLL.GetListByPage(where, " CreateTime desc ", startIndex, endIndex);
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
        public ActionResult Save(Model.Common_Data model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.DataType))
            {
                sbErro.Append(",数据类型不能为空");
            }
            if (string.IsNullOrEmpty(model.DataText))
            {
                sbErro.Append(",数据显示值不能为空");
            }
            if (string.IsNullOrEmpty(model.DataValue))
            {
                sbErro.Append(",数据Value值不能为空");
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
            if (string.IsNullOrEmpty(model.DataID))
            {
                //value 和 type 唯一确定一个text值
                List<Model.Common_Data> modelExistsList = BLL.GetModelList("DataType='" + model.DataType + "' and DataValue='" + model.DataValue + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                model.CreateTime = DateTime.Now;
                model.CreateBy = CurrentUser.User.Userinfo.UserID;
                model.DataID = Guid.NewGuid().ToString();
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
                List<Model.Common_Data> modelExistsList = BLL.GetModelList("DataType='" + model.DataType + "' and DataValue='" + model.DataValue + "' and DataID!='" + model.DataID + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                Model.Common_Data modelOld = BLL.GetModel(model.DataID);
                if (modelOld == null)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "数据不存在";
                    return Json(json);
                }
                modelOld.DataType = model.DataType;
                modelOld.DataText = model.DataText;
                modelOld.DataValue = model.DataValue;
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
        public string getComboboxJson(string DataType)
        {
            DataSet ds = BLL.GetList(" DataType='" + DataType + "'  order by OrderBy asc");
            if (ds != null && ds.Tables.Count > 0)
            {
                return JsonHelper.CreateComboboxJson(ds.Tables[0], "DataValue", "DataText");
            }
            else
            {
                return JsonHelper.CreateComboboxJson(null, "", "");
            }
        }
    }
}
