using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;
using System.IO;

namespace WTCJ.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/
        BLL.Area BLL = new BLL.Area();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <returns></returns>
        public string List(string AreaName)
        {
            string where = "";
            if (!string.IsNullOrEmpty(AreaName) && CommonHelper.filterSql(AreaName))
            {
                where += "AreaName like '%" + AreaName + "%'";
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
        public ActionResult Save(Model.Area model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.AreaName))
            {
                sbErro.Append(",区域名称不能为空");
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
            if (string.IsNullOrEmpty(model.AreaID))
            {
                //DepartmentName 唯一
                List<Model.Area> modelExistsList = BLL.GetModelList("AreaName='" + model.AreaName + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                model.CreateTime = DateTime.Now;
                model.CreateBy = CurrentUser.User.Userinfo.UserID;
                model.AreaID = Guid.NewGuid().ToString();
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
                List<Model.Area> modelExistsList = BLL.GetModelList("AreaName='" + model.AreaName + "' and AreaID!='" + model.AreaID + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                Model.Area modelOld = BLL.GetModel(model.AreaID);
                if (modelOld == null)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "数据不存在";
                    return Json(json);
                }
                modelOld.AreaName = model.AreaName;
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
                return JsonHelper.CreateComboboxJson(ds.Tables[0], "AreaId", "AreaName");
            }
            else
            {
                return JsonHelper.CreateComboboxJson(null, "", "");
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExport(string AreaName)
        {
            string where = "";
            if (!string.IsNullOrEmpty(AreaName) && CommonHelper.filterSql(AreaName))
            {
                where += "AreaName like '%" + AreaName + "%'";
            }
            DataSet ds = BLL.GetList(where);
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            dt = getDataTableExportInfo(dt);
            string filePathTemplate = Server.MapPath("~/") + @"\Excel\Template\配置信息\区域管理模板.xlsx";
            new NOPI_ExcelHelp().OutputExcel(dt, filePathTemplate, this.HttpContext
                , "区域管理信息" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            return null;
        }
        /// <summary>
        /// 完善datatable数据  如果找不到，则显示ID或者value值
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DataTable getDataTableExportInfo(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return dt;
            }
            //遍历修改数据
            dt.Columns.Add("序号", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["序号"] = i + 1;
            }
            dt.Columns["AreaName"].ColumnName = "区域名称";
            dt.Columns["OrderBy"].ColumnName = "排序";
            dt.Columns["Remark"].ColumnName = "备注";
            return dt;
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelImport()
        {
            JsonObject json = new JsonObject();
            HttpPostedFileBase file = Request.Files["fileImport"];
            if (file == null || file.ContentLength <= 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "文件不能为空";
                return Json(json);
            }
            string[] FileType = new string[] { ".xls", ".xlsx" }; //定义上传文件的类型
            string filename = Path.GetFileName(file.FileName);
            int filesize = file.ContentLength;//获取上传文件的大小单位为字节byte  
            string fileEx = System.IO.Path.GetExtension(filename);//获取上传文件的扩展名  
            string NoFileName = System.IO.Path.GetFileNameWithoutExtension(filename);//获取无扩展名的文件名
            if (!fileEx.Contains(fileEx.ToLower()))
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "文件类型不对，只能导入xls和xlsx格式的文件";
                return Json(json);
            }
            DataTable dt = ExcelHelper.ReadExcelToDataTable(Server.MapPath("~/"), file, fileEx.ToLower());
            //查询和模板页列是否相同
            DataTable dtTemplate = NOPI_ExcelHelp.ImportDataTableFromExcel2007(Server.MapPath("~/") + @"\Excel\Template\配置信息\区域管理模板.xlsx");
            json = new Excel.AreaExcel().Import(dt, dtTemplate);
            return Json(json);
        }
    }
}
