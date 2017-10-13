using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text;
using WTCJ.DBUtility;
using System.IO;

namespace WTCJ.Controllers
{
    public class HealthXsController : Controller
    {
        //
        // GET: /HealthZj/
        BLL.Health_Xs BLL = new BLL.Health_Xs();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <returns></returns>
        public string List(Model.Health_Xs model)
        {
            string where = " IsDeleted!=1 ";

            if (!string.IsNullOrEmpty(model.区域) && CommonHelper.filterSql(model.区域))
            {
                where += "and 区域 = '" + model.区域 + "' ";
            }
            if (!string.IsNullOrEmpty(model.客户名称) && CommonHelper.filterSql(model.客户名称))
            {
                where += "and 客户名称 = '" + model.客户名称 + "' ";
            }
            if (!string.IsNullOrEmpty(model.站点编码) && CommonHelper.filterSql(model.站点编码))
            {
                where += "and 站点编码 like '%" + model.站点编码 + "%' ";
            }
            if (!string.IsNullOrEmpty(model.站点名称) && CommonHelper.filterSql(model.站点名称))
            {
                where += "and 站点名称 like '%" + model.站点名称 + "%' ";
            }
            int total = BLL.GetRecordCount(where);
            int pageSize = Convert.ToInt32(Request["rows"]);
            int pageNum = Convert.ToInt32(Request["page"]);
            int startIndex = (pageNum - 1) * pageSize + 1;
            int endIndex = pageNum * pageSize;
            if (total >= startIndex)
            {
                //需要修改dal 为了防止代码重复生成，在controller类中重写此方法
                DataSet ds = GetListByPage(where, " CreateTime desc ", startIndex, endIndex);
                DataTable dt = new DataTable();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                String strJson = JsonHelper.GetJsonFromDataTable(dt, total);
                return strJson;
            }
            else
            {
                String strJson = JsonHelper.GetJsonFromDataTable(null, total);
                return strJson;
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(Model.Health_Xs model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.区域))
            {
                sbErro.Append(",区域不能为空");
            }
            else
            {
                Model.Area modelParmExist = new BLL.Area().GetModel(model.区域);
                if (modelParmExist == null)
                {
                    sbErro.Append(",区域不存在");
                }
            }
            if (string.IsNullOrEmpty(model.客户名称))
            {
                sbErro.Append(",客户名称不能为空");
            }
            else
            {
                Model.Customer modelParmExist = new BLL.Customer().GetModel(model.客户名称);
                if (modelParmExist == null)
                {
                    sbErro.Append(",客户名称不存在");
                }
            }
            if (string.IsNullOrEmpty(model.站点编码))
            {
                sbErro.Append(",站点编码不能为空");
            }
            if (string.IsNullOrEmpty(model.站点名称))
            {
                sbErro.Append(",站点名称不能为空");
            }
            if (sbErro.Length > 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = sbErro.ToString().Substring(1);
                return Json(json);
            }
            //初始化自动生成值
            Excel.HealthXsExcel healthXsExcel = new Excel.HealthXsExcel();
            model.伟通收入不含税 = 0;
            model.累计应收金额 = 0;
            healthXsExcel.Get伟通收入不含税(model);
            healthXsExcel.Get累计应收金额(model);
            //如果ID为空，则是添加
            if (string.IsNullOrEmpty(model.id))
            {
                List<Model.Health_Xs> modelExistsList = BLL.GetModelList("站点编码='" + model.站点编码 + "' and IsDeleted!=1");
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
                List<Model.Health_Xs> modelExistsList = BLL.GetModelList("站点编码='" + model.站点编码 + "' and id!='" + model.id + "' and IsDeleted!=1");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
                Model.Health_Xs modelOld = BLL.GetModel(model.id);
                if (modelOld == null)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "数据不存在";
                    return Json(json);
                }
                if (modelOld.IsDeleted == 1)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "修改失败，数据已删除";
                    return Json(json);
                }
                model.IsDeleted = modelOld.IsDeleted;
                model.CreateBy = modelOld.CreateBy;
                model.CreateTime = modelOld.CreateTime;
                model.UpdateTime = DateTime.Now;
                model.UpdateBy = CurrentUser.User.Userinfo.UserID;
                bool res = BLL.Update(model);
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
        /// 删除数据
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
                    Model.Health_Xs model = BLL.GetModel(IDArry[i]);
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT tt.*,ar.AreaName 区域Text,cu.CustomerName 客户名称Text FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from Health_Xs T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join Area ar on tt.区域=ar.AreaID ");
            strSql.Append(" left join Customer cu on tt.客户名称=cu.CustomerID ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            DataTable dtTemplate = NOPI_ExcelHelp.ImportDataTableFromExcel2007(Server.MapPath("~/") + @"\Excel\Template\销售健康度模板.xlsx");
            json = new Excel.HealthXsExcel().Import(dt, dtTemplate);
            return Json(json);
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExport(Model.Health_Xs model)
        {
            string where = " IsDeleted!=1 ";

            if (!string.IsNullOrEmpty(model.区域) && CommonHelper.filterSql(model.区域))
            {
                where += "and 区域 = '" + model.区域 + "' ";
            }
            if (!string.IsNullOrEmpty(model.客户名称) && CommonHelper.filterSql(model.客户名称))
            {
                where += "and 客户名称 = '" + model.客户名称 + "' ";
            }
            if (!string.IsNullOrEmpty(model.站点编码) && CommonHelper.filterSql(model.站点编码))
            {
                where += "and 站点编码 like '%" + model.站点编码 + "%' ";
            }
            if (!string.IsNullOrEmpty(model.站点名称) && CommonHelper.filterSql(model.站点名称))
            {
                where += "and 站点名称 like '%" + model.站点名称 + "%' ";
            }
            DataSet ds = BLL.GetList(where);
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            dt = getDataTableExportInfo(dt);
            string filePathTemplate = Server.MapPath("~/") + @"\Excel\Template\销售健康度模板.xlsx";
            //获取隐藏的列值
            List<Model.User_Columns> modelExistsList = new BLL.User_Columns().GetModelList("type='export' AND tableName='HealthXs' AND UserId='" + CurrentUser.User.Userinfo.UserID + "'");
            string hideColumns = "";
            if (modelExistsList != null && modelExistsList.Count > 0)
            {
                hideColumns = modelExistsList[0].hideColumns.Trim(',');
            }
            else
            {
                hideColumns = "";
            }
            new NOPI_ExcelHelp().OutputExcel(dt, filePathTemplate, this.HttpContext, "销售健康度信息" + DateTime.Now.ToString("yyyyMMddHHmmss"), hideColumns);
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
            //删除前面的下划线
            foreach (DataColumn column in dt.Columns)
            {
                string columnName = column.Caption;
                if (!string.IsNullOrEmpty(columnName) && string.Equals(columnName.Substring(0, 1), "_"))
                {
                    column.Caption = columnName.Substring(1);
                }
            }
            dt.Columns.Add("序号", typeof(int));
            DataTable dtArea = new BLL.Area().GetAllList().Tables[0];
            DataTable dtCustomer = new BLL.Customer().GetAllList().Tables[0];
            //遍历修改数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["区域"] = CommonHelper.getAreaName(dtArea, dt.Rows[i]["区域"]);
                dt.Rows[i]["客户名称"] = CommonHelper.getCustomerName(dtCustomer, dt.Rows[i]["客户名称"]);
                dt.Rows[i]["序号"] = i + 1;
            }
            dt.Columns.Remove("id");
            dt.Columns.Remove("CreateBy");
            dt.Columns.Remove("CreateTime");
            dt.Columns.Remove("UpdateBy");
            dt.Columns.Remove("UpdateTime");
            dt.Columns.Remove("IsDeleted");
            return dt;
        }


    }
}
