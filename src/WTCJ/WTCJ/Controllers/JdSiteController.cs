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
    public class JdSiteController : Controller
    {
        //
        // GET: /JdSite/
        BLL.JD_SITE BLL = new BLL.JD_SITE();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <returns></returns>
        public string List(Model.JD_SITE model)
        {
            string where = "";
            if (!string.IsNullOrEmpty(model.部门) && CommonHelper.filterSql(model.部门))
            {
                where += "and 部门 ='" + model.部门 + "' ";
            }
            if (!string.IsNullOrEmpty(model.类别) && CommonHelper.filterSql(model.类别))
            {
                where += "and 类别 = '" + model.类别 + "' ";
            }
            if (!string.IsNullOrEmpty(model.区域) && CommonHelper.filterSql(model.区域))
            {
                where += "and 区域 = '" + model.区域 + "' ";
            }
            if (!string.IsNullOrEmpty(model.客户) && CommonHelper.filterSql(model.客户))
            {
                where += "and 客户 = '" + model.客户 + "' ";
            }
            if (!string.IsNullOrEmpty(model.站点编码) && CommonHelper.filterSql(model.站点编码))
            {
                where += "and 站点编码 like '%" + model.站点编码 + "%' ";
            }
            if (!string.IsNullOrEmpty(model.站点名称) && CommonHelper.filterSql(model.站点名称))
            {
                where += "and 站点名称 like '%" + model.站点名称 + "%' ";
            }
            if (!string.IsNullOrEmpty(model.站点类型归属) && CommonHelper.filterSql(model.站点类型归属))
            {
                where += "and 站点类型归属 = '" + model.站点类型归属 + "' ";
            }
            if (!string.IsNullOrEmpty(model.最新状态) && CommonHelper.filterSql(model.最新状态))
            {
                where += "and 最新状态 = '" + model.最新状态 + "' ";
            }
            if (!string.IsNullOrEmpty(model.是否退点) && CommonHelper.filterSql(model.是否退点))
            {
                where += "and 是否退点 = '" + model.是否退点 + "' ";
            }
            if (where != "")
            {
                where = where.Substring(4);
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
                dt = getDataTableInfo(dt);
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
        /// 保存数据字典数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(Model.JD_SITE model)
        {
            JsonObject json = new JsonObject();
            StringBuilder sbErro = new StringBuilder();
            if (string.IsNullOrEmpty(model.部门))
            {
                sbErro.Append(",部门不能为空");
            }
            else
            {
                Model.Department modelParmExist = new BLL.Department().GetModel(model.部门);
                if (modelParmExist == null)
                {
                    sbErro.Append(",部门不存在");
                }
            }
            if (string.IsNullOrEmpty(model.类别))
            {
                sbErro.Append(",类别不能为空");
            }
            else if (model.类别 != "自持" && model.类别 != "销售")
            {
                sbErro.Append(",类别必须是自持或销售");
            }
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
            if (string.IsNullOrEmpty(model.客户))
            {
                sbErro.Append(",客户不能为空");
            }
            else
            {
                Model.Customer modelParmExist = new BLL.Customer().GetModel(model.客户);
                if (modelParmExist == null)
                {
                    sbErro.Append(",客户不存在");
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
            if (!string.IsNullOrEmpty(model.站点类型归属))
            {
                int existsCount = new BLL.Common_Data().GetRecordCount("DataType='站点类型归属' and DataValue='" + model.站点类型归属 + "'");
                if (existsCount == 0)
                {
                    sbErro.Append(",站点类型归属不存在");
                }
            }
            else
            {
                sbErro.Append(",站点类型归属不能为空");
            }
            if (!string.IsNullOrEmpty(model.最新状态))
            {
                int existsCount = new BLL.Common_Data().GetRecordCount("DataType='最新状态' and DataValue='" + model.最新状态 + "'");
                if (existsCount == 0)
                {
                    sbErro.Append(",最新状态不存在");
                }
            }
            else
            {
                sbErro.Append(",最新状态不能为空");
            }
            if (string.IsNullOrEmpty(model.是否退点))
            {
                if (model.是否退点 != "是" && model.类别 != "否")
                {
                    sbErro.Append(",是否退点是是或否");
                }
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
                List<Model.JD_SITE> modelExistsList = BLL.GetModelList("站点编码='" + model.站点编码 + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "添加失败,此数据已存在";
                    return Json(json);
                }
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
                List<Model.JD_SITE> modelExistsList = BLL.GetModelList("站点编码='" + model.站点编码 + "' and id!='" + model.id + "'");
                if (modelExistsList != null && modelExistsList.Count > 0)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "修改失败,此数据已存在";
                    return Json(json);
                }
                Model.JD_SITE modelOld = BLL.GetModel(model.id);
                if (modelOld == null)
                {
                    json.Status = JsonObject.STATUS_FAIL;
                    json.ErroMessage = "数据不存在";
                    return Json(json);
                }
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT tt.*,dp.DepartmentName 部门Text,ar.AreaName 区域Text,cu.CustomerName 客户Text FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from JD_SITE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join Department dp on tt.部门=dp.DepartmentID ");
            strSql.Append(" left join Area ar on tt.区域=ar.AreaID ");
            strSql.Append(" left join Customer cu on tt.客户=cu.CustomerID ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 完善datatable数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DataTable getDataTableInfo(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return dt;
            }
            dt.Columns.Add("站点类型归属Text", typeof(string));
            dt.Columns.Add("最新状态Text", typeof(string));
            DataTable dtCommonData = new DataTable();
            DataSet ds = new BLL.Common_Data().GetList(" DataType in('站点类型归属','最新状态')");
            if (ds != null && ds.Tables.Count > 0)
            {
                dtCommonData = ds.Tables[0];
            }
            //如果数据字典为空，则不处理
            if (dtCommonData == null || dtCommonData.Rows.Count == 0)
            {
                return dt;
            }
            //遍历添加字典数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string 站点类型归属 = dt.Rows[i]["站点类型归属"].ToString();
                if (!string.IsNullOrEmpty(站点类型归属))
                {
                    DataRow[] drs = dtCommonData.Select("DataType='站点类型归属' and DataValue='" + 站点类型归属 + "'");
                    if (drs.Length > 0)
                    {
                        dt.Rows[i]["站点类型归属Text"] = drs[0]["DataText"];
                    }
                }

                string 最新状态 = dt.Rows[i]["最新状态"].ToString();
                if (!string.IsNullOrEmpty(最新状态))
                {
                    DataRow[] drs = dtCommonData.Select("DataType='最新状态' and DataValue='" + 最新状态 + "'");
                    if (drs.Length > 0)
                    {
                        dt.Rows[i]["最新状态Text"] = drs[0]["DataText"];
                    }
                }
            }
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
            DataTable dtTemplate = NOPI_ExcelHelp.ImportDataTableFromExcel2007(Server.MapPath("~/") + @"\Excel\Template\基站项目进度表模板.xlsx");
            json = new Excel.JdSiteExcel().Import(dt, dtTemplate);
            return Json(json);
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExport(Model.JD_SITE model)
        {
            string where = "";
            if (!string.IsNullOrEmpty(model.部门) && CommonHelper.filterSql(model.部门))
            {
                where += "and 部门 ='" + model.部门 + "' ";
            }
            if (!string.IsNullOrEmpty(model.类别) && CommonHelper.filterSql(model.类别))
            {
                where += "and 类别 = '" + model.类别 + "' ";
            }
            if (!string.IsNullOrEmpty(model.区域) && CommonHelper.filterSql(model.区域))
            {
                where += "and 区域 = '" + model.区域 + "' ";
            }
            if (!string.IsNullOrEmpty(model.客户) && CommonHelper.filterSql(model.客户))
            {
                where += "and 客户 = '" + model.客户 + "' ";
            }
            if (!string.IsNullOrEmpty(model.站点编码) && CommonHelper.filterSql(model.站点编码))
            {
                where += "and 站点编码 like '%" + model.站点编码 + "%' ";
            }
            if (!string.IsNullOrEmpty(model.站点名称) && CommonHelper.filterSql(model.站点名称))
            {
                where += "and 站点名称 like '%" + model.站点名称 + "%' ";
            }
            if (!string.IsNullOrEmpty(model.站点类型归属) && CommonHelper.filterSql(model.站点类型归属))
            {
                where += "and 站点类型归属 = '" + model.站点类型归属 + "' ";
            }
            if (!string.IsNullOrEmpty(model.最新状态) && CommonHelper.filterSql(model.最新状态))
            {
                where += "and 最新状态 = '" + model.最新状态 + "' ";
            }
            if (!string.IsNullOrEmpty(model.是否退点) && CommonHelper.filterSql(model.是否退点))
            {
                where += "and 是否退点 = '" + model.是否退点 + "' ";
            }
            if (where != "")
            {
                where = where.Substring(4);
            }
            DataSet ds = BLL.GetList(where);
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            dt = getDataTableExportInfo(dt);
            string filePathTemplate = Server.MapPath("~/") + @"\Excel\Template\基站项目进度表模板.xlsx";
            //获取隐藏的列值
            List<Model.User_Columns> modelExistsList = new BLL.User_Columns().GetModelList("type='export' AND tableName='JdSite' AND UserId='" + CurrentUser.User.Userinfo.UserID + "'");
            string hideColumns = "";
            if (modelExistsList != null && modelExistsList.Count > 0)
            {
                hideColumns = modelExistsList[0].hideColumns.Trim(',');
            }
            else
            {
                hideColumns = "";
            }
            new NOPI_ExcelHelp().OutputExcel(dt, filePathTemplate, this.HttpContext
                , "基站项目进度信息" + DateTime.Now.ToString("yyyyMMddHHmmss"), hideColumns);
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
            DataTable dtDepartment = new BLL.Department().GetAllList().Tables[0];
            DataTable dtArea = new BLL.Area().GetAllList().Tables[0];
            DataTable dtCustomer = new BLL.Customer().GetAllList().Tables[0];
            DataTable dtCommonData = new BLL.Common_Data().GetList(" DataType in('站点类型归属','最新状态')").Tables[0];
            //遍历修改数据
            dt.Columns.Add("序号", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["部门"] = CommonHelper.getDepartmentName(dtDepartment, dt.Rows[i]["部门"]);
                dt.Rows[i]["区域"] = CommonHelper.getAreaName(dtArea, dt.Rows[i]["区域"]);
                dt.Rows[i]["客户"] = CommonHelper.getCustomerName(dtCustomer, dt.Rows[i]["客户"]);
                dt.Rows[i]["站点类型归属"] = CommonHelper.getCommonDataText(dtCommonData, "站点类型归属", dt.Rows[i]["站点类型归属"]);
                dt.Rows[i]["最新状态"] = CommonHelper.getCommonDataText(dtCommonData, "最新状态", dt.Rows[i]["最新状态"]);
                dt.Rows[i]["序号"] = i + 1;
            }
            dt.Columns.Remove("id");
            dt.Columns.Remove("Remark");
            dt.Columns.Remove("CreateBy");
            dt.Columns.Remove("CreateTime");
            dt.Columns.Remove("UpdateBy");
            dt.Columns.Remove("UpdateTime");
            return dt;
        }




        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public string getJdSite()
        {
            DataTable dt = getJdSiteInfo();
            String strJson = JsonHelper.GetJsonFromDataTable(dt);
            return strJson;
        }
        
        public DataTable getJdSiteInfo()
        {
            DataTable dtCommonData = new BLL.Common_Data().GetList(" DataType in('最新状态')").Tables[0];
            String sql = @"

select 类别,ISNULL(d.DepartmentName,部门) 部门,a.AreaName 区域,c.CustomerName 客户,
ISNULL(摘牌,0) 摘牌,
ISNULL(选址定点,0) 选址定点,
ISNULL(签订租赁合同,0) 签订租赁合同,
ISNULL(地墈,0) 地墈,
ISNULL(设计出图,0) 设计出图,
ISNULL(土建施工,0) 土建施工,
ISNULL(产品采购,0) 产品采购,
ISNULL(产品安装,0) 产品安装,
ISNULL(电力报建,0) 电力报建,
ISNULL(销售验收,0) 销售验收,
ISNULL(运营商验收交付,0) 运营商验收交付,
ISNULL(运营商签订合同,0) 运营商签订合同,
ISNULL(退点,0) 退点,
ISNULL(站点数量合计,0) 站点数量合计,
ISNULL(伟通预计应收金额,0) 伟通预计应收金额
FROM
(select t.部门,'自持' 类别,t.区域,t.客户,摘牌,选址定点,签订租赁合同,地墈,设计出图,土建施工,产品采购,产品安装,电力报建,销售验收,运营商验收交付,运营商签订合同,退点,站点数量合计,伟通预计应收金额
 from
(select distinct 部门,区域,客户 from JD_SITE where 类别='自持') t
left join(select count(0) 摘牌,部门,区域,客户 from JD_SITE a where a.最新状态='摘牌' and a.类别='自持'  group by 部门,区域,客户) t摘牌 on t.部门=t摘牌.部门 and t.区域=t摘牌.区域 and t.客户=t摘牌.客户
left join(select count(0) 选址定点,部门,区域,客户 from JD_SITE a where a.最新状态='选址、定点' and a.类别='自持'  group by 部门,区域,客户) t选址定点 on t.部门=t选址定点.部门 and t.区域=t选址定点.区域 and t.客户=t选址定点.客户
left join(select count(0) 签订租赁合同,部门,区域,客户 from JD_SITE a where a.最新状态='签订租赁合同' and a.类别='自持'  group by 部门,区域,客户) t签订租赁合同 on t.部门=t签订租赁合同.部门 and t.区域=t签订租赁合同.区域 and t.客户=t签订租赁合同.客户
left join(select count(0) 地墈,部门,区域,客户 from JD_SITE a where a.最新状态='地墈' and a.类别='自持'  group by 部门,区域,客户) t地墈 on t.部门=t地墈.部门 and t.区域=t地墈.区域 and t.客户=t地墈.客户
left join(select count(0) 设计出图,部门,区域,客户 from JD_SITE a where a.最新状态='设计出图' and a.类别='自持'  group by 部门,区域,客户) t设计出图 on t.部门=t设计出图.部门 and t.区域=t设计出图.区域 and t.客户=t设计出图.客户
left join(select count(0) 土建施工,部门,区域,客户 from JD_SITE a where a.最新状态='土建施工' and a.类别='自持'  group by 部门,区域,客户) t土建施工 on t.部门=t土建施工.部门 and t.区域=t土建施工.区域 and t.客户=t土建施工.客户
left join(select count(0) 产品采购,部门,区域,客户 from JD_SITE a where a.最新状态='产品采购' and a.类别='自持'  group by 部门,区域,客户) t产品采购 on t.部门=t产品采购.部门 and t.区域=t产品采购.区域 and t.客户=t产品采购.客户
left join(select count(0) 产品安装,部门,区域,客户 from JD_SITE a where a.最新状态='产品安装' and a.类别='自持'  group by 部门,区域,客户) t产品安装 on t.部门=t产品安装.部门 and t.区域=t产品安装.区域 and t.客户=t产品安装.客户
left join(select count(0) 电力报建,部门,区域,客户 from JD_SITE a where a.最新状态='电力报建' and a.类别='自持'  group by 部门,区域,客户) t电力报建 on t.部门=t电力报建.部门 and t.区域=t电力报建.区域 and t.客户=t电力报建.客户
left join(select count(0) 销售验收,部门,区域,客户 from JD_SITE a where a.最新状态='销售验收' and a.类别='自持'  group by 部门,区域,客户) t销售验收 on t.部门=t销售验收.部门 and t.区域=t销售验收.区域 and t.客户=t销售验收.客户
left join(select count(0) 运营商验收交付,部门,区域,客户 from JD_SITE a where a.最新状态='运营商验收、交付' and a.类别='自持'  group by 部门,区域,客户) t运营商验收交付 on t.部门=t运营商验收交付.部门 and t.区域=t运营商验收交付.区域 and t.客户=t运营商验收交付.客户
left join(select count(0) 运营商签订合同,部门,区域,客户 from JD_SITE a where a.最新状态='运营商签订合同' and a.类别='自持'  group by 部门,区域,客户) t运营商签订合同 on t.部门=t运营商签订合同.部门 and t.区域=t运营商签订合同.区域 and t.客户=t运营商签订合同.客户
left join(select count(0) 退点,部门,区域,客户 from JD_SITE a where a.是否退点='是' and a.类别='自持'  group by 部门,区域,客户) t退点 on t.部门=t退点.部门 and t.区域=t退点.区域 and t.客户=t退点.客户
left join(select count(0) 站点数量合计,部门,区域,客户 from JD_SITE a where a.类别='自持'  group by 部门,区域,客户) t站点数量合计 on t.部门=t站点数量合计.部门 and t.区域=t站点数量合计.区域 and t.客户=t站点数量合计.客户
left join(select sum(a.伟通应收款) 伟通预计应收金额,部门,区域,客户 from JD_SITE a where a.类别='自持'  group by 部门,区域,客户) t伟通预计应收金额 on t.部门=t伟通预计应收金额.部门 and t.区域=t伟通预计应收金额.区域 and t.客户=t伟通预计应收金额.客户
union all
select '合计' 部门,'自持' 类别,'' 区域,'' 客户,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 摘牌,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 选址定点,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 签订租赁合同,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 地墈,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 设计出图,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 土建施工,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 产品采购,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 产品安装,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 电力报建,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 销售验收,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 运营商验收交付,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='自持') 运营商签订合同,
(select count(0) from JD_SITE a where a.是否退点='是' and a.类别='自持') 退点,
(select count(0) from JD_SITE a where a.类别='自持') 站点数量合计,
(select sum(a.伟通应收款) from JD_SITE a where a.类别='自持') 伟通预计应收金额
union all
select t.部门,'销售' 类别,t.区域,t.客户,摘牌,选址定点,签订租赁合同,地墈,设计出图,土建施工,产品采购,产品安装,电力报建,销售验收,运营商验收交付,运营商签订合同,退点,站点数量合计,伟通预计应收金额 
 from
(select distinct 部门,区域,客户 from JD_SITE where 类别='销售') t
left join(select count(0) 摘牌,部门,区域,客户 from JD_SITE a where a.最新状态='摘牌' and a.类别='销售'  group by 部门,区域,客户) t摘牌 on t.部门=t摘牌.部门 and t.区域=t摘牌.区域 and t.客户=t摘牌.客户
left join(select count(0) 选址定点,部门,区域,客户 from JD_SITE a where a.最新状态='选址、定点' and a.类别='销售'  group by 部门,区域,客户) t选址定点 on t.部门=t选址定点.部门 and t.区域=t选址定点.区域 and t.客户=t选址定点.客户
left join(select count(0) 签订租赁合同,部门,区域,客户 from JD_SITE a where a.最新状态='签订租赁合同' and a.类别='销售'  group by 部门,区域,客户) t签订租赁合同 on t.部门=t签订租赁合同.部门 and t.区域=t签订租赁合同.区域 and t.客户=t签订租赁合同.客户
left join(select count(0) 地墈,部门,区域,客户 from JD_SITE a where a.最新状态='地墈' and a.类别='销售'  group by 部门,区域,客户) t地墈 on t.部门=t地墈.部门 and t.区域=t地墈.区域 and t.客户=t地墈.客户
left join(select count(0) 设计出图,部门,区域,客户 from JD_SITE a where a.最新状态='设计出图' and a.类别='销售'  group by 部门,区域,客户) t设计出图 on t.部门=t设计出图.部门 and t.区域=t设计出图.区域 and t.客户=t设计出图.客户
left join(select count(0) 土建施工,部门,区域,客户 from JD_SITE a where a.最新状态='土建施工' and a.类别='销售'  group by 部门,区域,客户) t土建施工 on t.部门=t土建施工.部门 and t.区域=t土建施工.区域 and t.客户=t土建施工.客户
left join(select count(0) 产品采购,部门,区域,客户 from JD_SITE a where a.最新状态='产品采购' and a.类别='销售'  group by 部门,区域,客户) t产品采购 on t.部门=t产品采购.部门 and t.区域=t产品采购.区域 and t.客户=t产品采购.客户
left join(select count(0) 产品安装,部门,区域,客户 from JD_SITE a where a.最新状态='产品安装' and a.类别='销售'  group by 部门,区域,客户) t产品安装 on t.部门=t产品安装.部门 and t.区域=t产品安装.区域 and t.客户=t产品安装.客户
left join(select count(0) 电力报建,部门,区域,客户 from JD_SITE a where a.最新状态='电力报建' and a.类别='销售'  group by 部门,区域,客户) t电力报建 on t.部门=t电力报建.部门 and t.区域=t电力报建.区域 and t.客户=t电力报建.客户
left join(select count(0) 销售验收,部门,区域,客户 from JD_SITE a where a.最新状态='销售验收' and a.类别='销售'  group by 部门,区域,客户) t销售验收 on t.部门=t销售验收.部门 and t.区域=t销售验收.区域 and t.客户=t销售验收.客户
left join(select count(0) 运营商验收交付,部门,区域,客户 from JD_SITE a where a.最新状态='运营商验收、交付' and a.类别='销售'  group by 部门,区域,客户) t运营商验收交付 on t.部门=t运营商验收交付.部门 and t.区域=t运营商验收交付.区域 and t.客户=t运营商验收交付.客户
left join(select count(0) 运营商签订合同,部门,区域,客户 from JD_SITE a where a.最新状态='运营商签订合同' and a.类别='销售'  group by 部门,区域,客户) t运营商签订合同 on t.部门=t运营商签订合同.部门 and t.区域=t运营商签订合同.区域 and t.客户=t运营商签订合同.客户
left join(select count(0) 退点,部门,区域,客户 from JD_SITE a where a.是否退点='是' and a.类别='销售'  group by 部门,区域,客户) t退点 on t.部门=t退点.部门 and t.区域=t退点.区域 and t.客户=t退点.客户
left join(select count(0) 站点数量合计,部门,区域,客户 from JD_SITE a where a.类别='销售'  group by 部门,区域,客户) t站点数量合计 on t.部门=t站点数量合计.部门 and t.区域=t站点数量合计.区域 and t.客户=t站点数量合计.客户
left join(select sum(a.伟通应收款) 伟通预计应收金额,部门,区域,客户 from JD_SITE a where a.类别='销售'  group by 部门,区域,客户) t伟通预计应收金额 on t.部门=t伟通预计应收金额.部门 and t.区域=t伟通预计应收金额.区域 and t.客户=t伟通预计应收金额.客户
union all
select '合计' 部门,'销售' 类别,'' 区域,'' 客户,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 摘牌,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 选址定点,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 签订租赁合同,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 地墈,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 设计出图,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 土建施工,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 产品采购,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 产品安装,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 电力报建,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 销售验收,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 运营商验收交付,
(select count(0) from JD_SITE a where a.最新状态='1' and a.类别='销售') 运营商签订合同,
(select count(0) from JD_SITE a where a.是否退点='是' and a.类别='销售') 退点,
(select count(0) from JD_SITE a where a.类别='销售') 站点数量合计,
(select sum(a.伟通应收款) from JD_SITE a where a.类别='销售') 伟通预计应收金额) T
left join Department d on t.部门=d.DepartmentID
left join area a on t.区域=a.AreaID
left join Customer c on t.客户=c.CustomerID";
            for (int i = 0; i < dtCommonData.Rows.Count; i++)
            {
                sql = sql.Replace("a.最新状态='" + dtCommonData.Rows[i]["DataText"].ToString() + "'", "a.最新状态='" + dtCommonData.Rows[i]["DataValue"].ToString() + "'");
            }
            return DbHelperSQL.Query(sql).Tables[0];

        }
   
     /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExportReport()
        {

            DataTable dt = getJdSiteInfo();
            
            new NOPI_ExcelHelp().OutputExcel(dt,  this.HttpContext
                , "基站项目进度表统计" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            return null;
        }
    }
}
