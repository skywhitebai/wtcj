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
    /// <summary>
    /// 以租代建损益表
    /// </summary>
    public class YzdjSyController : Controller
    {
        //
        // GET: /YzdjSy/
        BLL.YzdjSy BLL = new BLL.YzdjSy();
        private decimal ConvertSumSomeDecimal(params decimal?[] someDecimal){
            decimal returnValue = 0M;
            foreach(decimal? oneDecimal in someDecimal){
                if(oneDecimal.HasValue){
                    returnValue +=(decimal)oneDecimal;
                }else{
                    returnValue +=0;
                }
            }
            return returnValue;
        }
        private void ReplaceSomeColumn(Model.YzdjSy model)
        {
            model.已付款设备单位1 = model.成本设备单位1;
            model.已付款设备单位2 = model.成本设备单位2;
            model.已付款业主 = model.成本场地业主;
            model.已付款设计单位 = model.成本设计单位;
            model.已付款墈察单位 = model.成本地勘单位;
            model.已付款监理单位 = model.成本监理单位;
            model.已付款项目管理单位 = model.成本项目管理单位;
            model.已付款土建施工单位1 = model.成本土建施工单位1;
            model.已付款土建施工单位2 = model.成本土建施工单位2;
            model.已付款铁塔加工单位 = model.成本铁塔加工单位;
            model.已付款安装施工单位 = model.成本安装施工单位;
            model.已付款外电单位 = model.成本外电单位;
            model.已付款杆体搬运单位 = model.成本杆体搬运单位;
            model.已付款选址费用单位 = model.成本选址费用单位;
            model.已付款其他费用单位 = model.成本其他费用单位;

            model.发票情况设备单位1 = model.成本设备单位1;
            model.发票情况设备单位2 = model.成本设备单位2;
            model.发票情况业主 = model.成本场地业主;
            model.发票情况设计单位 = model.成本设计单位;
            model.发票情况墈察单位 = model.成本地勘单位;
            model.发票情况监理单位 = model.成本监理单位;
            model.发票情况项目管理单位 = model.成本项目管理单位;
            model.发票情况土建施工单位1 = model.成本土建施工单位1;
            model.发票情况土建施工单位2 = model.成本土建施工单位2;
            model.发票情况铁塔加工单位 = model.成本铁塔加工单位;
            model.发票情况安装施工单位 = model.成本安装施工单位;
            model.发票情况外电单位 = model.成本外电单位;
            model.发票情况杆体搬运单位 = model.成本杆体搬运单位;
            model.发票情况选址费用单位 = model.成本选址费用单位;
            model.发票情况其他费用单位 = model.成本其他费用单位;

            model.已付款未回发票设备单位1 = model.成本设备单位1;
            model.已付款未回发票设备单位2 = model.成本设备单位2;
            model.已付款未回发票业主 = model.成本场地业主;
            model.已付款未回发票设计单位 = model.成本设计单位;
            model.已付款未回发票墈察单位 = model.成本地勘单位;
            model.已付款未回发票监理单位 = model.成本监理单位;
            model.已付款未回发票项目管理单位 = model.成本项目管理单位;
            model.已付款未回发票土建施工单位1 = model.成本土建施工单位1;
            model.已付款未回发票土建施工单位2 = model.成本土建施工单位2;
            model.已付款未回发票铁塔加工单位 = model.成本铁塔加工单位;
            model.已付款未回发票安装施工单位 = model.成本安装施工单位;
            model.已付款未回发票外电单位 = model.成本外电单位;
            model.已付款未回发票杆体搬运单位 = model.成本杆体搬运单位;
            model.已付款未回发票选址费用单位 = model.成本选址费用单位;
            model.已付款未回发票其他费用单位 = model.成本其他费用单位;

            model.未付款设备单位1 = model.成本设备单位1;
            model.未付款设备单位2 = model.成本设备单位2;
            model.未付款业主 = model.成本场地业主;
            model.未付款设计单位 = model.成本设计单位;
            model.未付款墈察单位 = model.成本地勘单位;
            model.未付款监理单位 = model.成本监理单位;
            model.未付款项目管理单位 = model.成本项目管理单位;
            model.未付款土建施工单位1 = model.成本土建施工单位1;
            model.未付款土建施工单位2 = model.成本土建施工单位2;
            model.未付款铁塔加工单位 = model.成本铁塔加工单位;
            model.未付款安装施工单位 = model.成本安装施工单位;
            model.未付款外电单位 = model.成本外电单位;
            model.未付款杆体搬运单位 = model.成本杆体搬运单位;
            model.未付款选址费用单位 = model.成本选址费用单位;
            model.未付款其他费用单位 = model.成本其他费用单位;
        }
        private void SubtractSomeColumn(Model.YzdjSy model)
        {
            model.已付款未回发票设备费1 = model.已付款设备费1 - model.发票情况设备费1;
            model.已付款未回发票设备费2 = model.已付款设备费2 - model.发票情况设备费2;
            model.已付款未回发票业主租金 = model.已付款业主租金 - model.发票情况业主租金;
            model.已付款未回发票设计费 = model.已付款设计费 - model.发票情况设计费;
            model.已付款未回发票墈察费 = model.已付款墈察费 - model.发票情况墈察费;
            model.已付款未回发票监理费 = model.已付款监理费 - model.发票情况监理费;
            model.已付款未回发票项目管理费 = model.已付款项目管理费 - model.发票情况项目管理费;
            model.已付款未回发票土建施工费1 = model.已付款土建施工费1 - model.发票情况土建施工费1;
            model.已付款未回发票土建施工费2 = model.已付款土建施工费2 - model.发票情况土建施工费2;
            model.已付款未回发票铁塔加工费 = model.已付款铁塔加工费 - model.发票情况铁塔加工费;
            model.已付款未回发票安装施工费 = model.已付款安装施工费 - model.发票情况安装施工费;
            model.已付款未回发票外电施工费 = model.已付款外电施工费 - model.发票情况外电施工费;
            model.已付款未回发票杆体搬运费 = model.已付款杆体搬运费 - model.发票情况杆体搬运费;
            model.已付款未回发票选址费 = model.已付款选址费 - model.发票情况选址费;
            model.已付款未回发票其他费用 = model.已付款其他费用 - model.发票情况其他费用;

            model.未付款设备费1 = model.成本设备成本1 - model.已付款设备费1;
            model.未付款设备费2 = model.成本设备成本2 - model.已付款设备费2;
            model.未付款业主租金 = model.成本租赁成本 - model.已付款业主租金;
            model.未付款设计费 = model.成本设计成本 - model.已付款设计费;
            model.未付款墈察费 = model.成本地勘成本 - model.已付款墈察费;
            model.未付款监理费 = model.成本监理成本 - model.已付款监理费;
            model.未付款项目管理费 = model.成本项目管理成本 - model.已付款项目管理费;
            model.未付款土建施工费1 = model.成本土建施工成本1 - model.已付款土建施工费1;
            model.未付款土建施工费2 = model.成本土建施工成本2 - model.已付款土建施工费2;
            model.未付款铁塔加工费 = model.成本铁塔加工成本 - model.已付款铁塔加工费;
            model.未付款安装施工费 = model.成本安装施工成本 - model.已付款安装施工费;
            model.未付款外电施工费 = model.成本外电费 - model.已付款外电施工费;
            model.未付款杆体搬运费 = model.成本杆体搬运费 - model.已付款杆体搬运费;
            model.未付款选址费 = model.成本选址费 - model.已付款选址费;
            model.未付款其他费用 = model.成本其他费用 - model.已付款其他费用;

        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <returns></returns>
        public string List(Model.YzdjSy model)
        {
            string where = " IsDeleted!=1 ";
            if (!string.IsNullOrEmpty(model.部门) && CommonHelper.filterSql(model.部门))
            {
                where += "and 部门 = '" + model.部门 + "' ";
            }
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
        public ActionResult Save(Model.YzdjSy model)
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
            #region 公司信息校验
            DataSet dsCompany = new BLL.Company().GetAllList();
            DataTable dtCompany = new DataTable();
            if (dsCompany != null && dsCompany.Tables.Count > 0)
            {
                dtCompany = dsCompany.Tables[0];
            }
            //if (!string.IsNullOrEmpty(model.成本监理单位))
            //{
            //    if (dtCompany == null || dtCompany.Rows.Count==0)
            //    {
            //        sbErro.Append(",成本[监理单位]不存在");
            //    }
            //    else
            //    {
            //        DataRow[] drs = dtCompany.Select("id='" + model.成本监理单位 + "'");
            //        if (drs == null || drs.Length == 0)
            //        {
            //            sbErro.Append(",成本[监理单位]不存在");
            //        }
            //    }
            //}
            if (!string.IsNullOrEmpty(model.成本设备单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本设备单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本设备单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本设备单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本设备单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本设备单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本设备单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本设备单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本设计单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本设计单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本设计单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本设计单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本地勘单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本地勘单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本地勘单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本地勘单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本监理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本监理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本监理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本监理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本项目管理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本项目管理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本项目管理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本项目管理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本土建施工单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本土建施工单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本土建施工单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本土建施工单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本土建施工单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本土建施工单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本土建施工单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本土建施工单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本铁塔加工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本铁塔加工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本铁塔加工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本铁塔加工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本安装施工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本安装施工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本安装施工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本安装施工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本外电单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本外电单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本外电单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本外电单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本杆体搬运单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本杆体搬运单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本杆体搬运单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本杆体搬运单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本选址费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本选址费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本选址费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本选址费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.成本其他费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",成本其他费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.成本其他费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",成本其他费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款设备单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款设备单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款设备单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款设备单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款设备单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款设备单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款设备单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款设备单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款设计单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款设计单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款设计单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款设计单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款墈察单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款墈察单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款墈察单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款墈察单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款监理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款监理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款监理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款监理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款项目管理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款项目管理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款项目管理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款项目管理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款土建施工单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款土建施工单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款土建施工单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款土建施工单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款土建施工单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款土建施工单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款土建施工单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款土建施工单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款铁塔加工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款铁塔加工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款铁塔加工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款铁塔加工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款安装施工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款安装施工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款安装施工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款安装施工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款外电单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款外电单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款外电单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款外电单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款杆体搬运单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款杆体搬运单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款杆体搬运单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款杆体搬运单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款选址费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款选址费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款选址费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款选址费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款其他费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款其他费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款其他费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款其他费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况设备单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况设备单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况设备单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况设备单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况设备单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况设备单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况设备单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况设备单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况设计单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况设计单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况设计单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况设计单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况墈察单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况墈察单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况墈察单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况墈察单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况监理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况监理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况监理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况监理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况项目管理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况项目管理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况项目管理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况项目管理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况土建施工单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况土建施工单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况土建施工单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况土建施工单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况土建施工单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况土建施工单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况土建施工单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况土建施工单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况铁塔加工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况铁塔加工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况铁塔加工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况铁塔加工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况安装施工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况安装施工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况安装施工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况安装施工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况外电单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况外电单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况外电单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况外电单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况杆体搬运单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况杆体搬运单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况杆体搬运单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况杆体搬运单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况选址费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况选址费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况选址费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况选址费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.发票情况其他费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",发票情况其他费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.发票情况其他费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",发票情况其他费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票设备单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票设备单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票设备单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票设备单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票设备单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票设备单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票设备单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票设备单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票设计单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票设计单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票设计单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票设计单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票墈察单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票墈察单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票墈察单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票墈察单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票监理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票监理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票监理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票监理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票项目管理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票项目管理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票项目管理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票项目管理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票土建施工单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票土建施工单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票土建施工单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票土建施工单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票土建施工单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票土建施工单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票土建施工单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票土建施工单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票铁塔加工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票铁塔加工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票铁塔加工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票铁塔加工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票安装施工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票安装施工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票安装施工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票安装施工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票外电单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票外电单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票外电单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票外电单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票杆体搬运单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票杆体搬运单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票杆体搬运单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票杆体搬运单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票选址费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票选址费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票选址费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票选址费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.已付款未回发票其他费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",已付款未回发票其他费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.已付款未回发票其他费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",已付款未回发票其他费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款设备单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款设备单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款设备单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款设备单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款设备单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款设备单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款设备单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款设备单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款设计单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款设计单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款设计单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款设计单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款墈察单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款墈察单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款墈察单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款墈察单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款监理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款监理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款监理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款监理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款项目管理单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款项目管理单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款项目管理单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款项目管理单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款土建施工单位1)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款土建施工单位1不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款土建施工单位1 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款土建施工单位1不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款土建施工单位2)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款土建施工单位2不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款土建施工单位2 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款土建施工单位2不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款铁塔加工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款铁塔加工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款铁塔加工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款铁塔加工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款安装施工单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款安装施工单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款安装施工单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款安装施工单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款外电单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款外电单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款外电单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款外电单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款杆体搬运单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款杆体搬运单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款杆体搬运单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款杆体搬运单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款选址费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款选址费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款选址费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款选址费用单位不存在"); } } }
            if (!string.IsNullOrEmpty(model.未付款其他费用单位)) { if (dtCompany == null || dtCompany.Rows.Count == 0) { sbErro.Append(",未付款其他费用单位不存在"); } else { DataRow[] drs = dtCompany.Select("id='" + model.未付款其他费用单位 + "'"); if (drs == null || drs.Length == 0) { sbErro.Append(",未付款其他费用单位不存在"); } } }


            #endregion
            if (sbErro.Length > 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = sbErro.ToString().Substring(1);
                return Json(json);
            }
            //如果ID为空，则是添加
            if (string.IsNullOrEmpty(model.id))
            {
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
                Model.YzdjSy modelOld = BLL.GetModel(model.id);
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
                model.总成本 = ConvertSumSomeDecimal(model.成本设备成本1, model.成本设备成本2, model.成本租赁成本,
                    model.成本设计成本, model.成本地勘成本, model.成本监理成本,
                     model.成本项目管理成本, model.成本土建施工成本1, model.成本土建施工成本2,
                      model.成本铁塔加工成本, model.成本安装施工成本, model.成本外电费,
                       model.成本杆体搬运费, model.成本选址费, model.成本其他费用
                    );
                ReplaceSomeColumn(model);
                model.总计付款 = ConvertSumSomeDecimal(model.已付款设备费1, model.已付款设备费2, model.已付款业主租金,
                    model.已付款设计费, model.已付款墈察费, model.已付款监理费,
                     model.已付款项目管理费, model.已付款土建施工费1, model.已付款土建施工费2,
                      model.已付款铁塔加工费, model.已付款安装施工费, model.已付款外电施工费,
                       model.已付款杆体搬运费, model.已付款选址费, model.已付款其他费用
                    );
                model.发票情况总计金额 = ConvertSumSomeDecimal(model.发票情况设备费1, model.发票情况设备费2, model.发票情况业主租金,
                    model.发票情况设计费, model.发票情况墈察费, model.发票情况监理费,
                     model.发票情况项目管理费, model.发票情况土建施工费1, model.发票情况土建施工费2,
                      model.发票情况铁塔加工费, model.发票情况安装施工费, model.发票情况外电施工费,
                       model.发票情况杆体搬运费, model.发票情况选址费, model.发票情况其他费用
                    );
                SubtractSomeColumn(model);
                model.已付款未回发票总计金额 = ConvertSumSomeDecimal(model.已付款未回发票设备费1, model.已付款未回发票设备费2, model.已付款未回发票业主租金,
                   model.已付款未回发票设计费, model.已付款未回发票墈察费, model.已付款未回发票监理费,
                    model.已付款未回发票项目管理费, model.已付款未回发票土建施工费1, model.已付款未回发票土建施工费2,
                     model.已付款未回发票铁塔加工费, model.已付款未回发票安装施工费, model.已付款未回发票外电施工费,
                      model.已付款未回发票杆体搬运费, model.已付款未回发票选址费, model.已付款未回发票其他费用
                   );
                model.未付款总计金额 = ConvertSumSomeDecimal(model.未付款设备费1, model.未付款设备费2, model.未付款业主租金,
                  model.未付款设计费, model.未付款墈察费, model.未付款监理费,
                   model.未付款项目管理费, model.未付款土建施工费1, model.未付款土建施工费2,
                    model.未付款铁塔加工费, model.未付款安装施工费, model.未付款外电施工费,
                     model.未付款杆体搬运费, model.未付款选址费, model.未付款其他费用
                  );
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
            int DoCount = 0;
            for (int i = 0; i < IDArry.Length; i++)
            {
                if (CommonHelper.filterSql(IDArry[i]))
                {
                    Model.YzdjSy model = BLL.GetModel(IDArry[i]);
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
            strSql.Append("SELECT tt.*,dp.DepartmentName 部门Text,ar.AreaName 区域Text,cu.CustomerName 客户名称Text FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from YzdjSy T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join Department dp on tt.部门=dp.DepartmentID ");
            strSql.Append(" left join Area ar on tt.区域=ar.AreaID ");
            strSql.Append(" left join Customer cu on tt.客户名称=cu.CustomerID ");
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
            dt.Columns.Add("成本设备单位1Text", typeof(string));
            dt.Columns.Add("成本设备单位2Text", typeof(string));
            dt.Columns.Add("成本设计单位Text", typeof(string));
            dt.Columns.Add("成本地勘单位Text", typeof(string));
            dt.Columns.Add("成本监理单位Text", typeof(string));
            dt.Columns.Add("成本项目管理单位Text", typeof(string));
            dt.Columns.Add("成本土建施工单位1Text", typeof(string));
            dt.Columns.Add("成本土建施工单位2Text", typeof(string));
            dt.Columns.Add("成本铁塔加工单位Text", typeof(string));
            dt.Columns.Add("成本安装施工单位Text", typeof(string));
            dt.Columns.Add("成本外电单位Text", typeof(string));
            dt.Columns.Add("成本杆体搬运单位Text", typeof(string));
            dt.Columns.Add("成本选址费用单位Text", typeof(string));
            dt.Columns.Add("成本其他费用单位Text", typeof(string));
            dt.Columns.Add("已付款设备单位1Text", typeof(string));
            dt.Columns.Add("已付款设备单位2Text", typeof(string));
            dt.Columns.Add("已付款设计单位Text", typeof(string));
            dt.Columns.Add("已付款墈察单位Text", typeof(string));
            dt.Columns.Add("已付款监理单位Text", typeof(string));
            dt.Columns.Add("已付款项目管理单位Text", typeof(string));
            dt.Columns.Add("已付款土建施工单位1Text", typeof(string));
            dt.Columns.Add("已付款土建施工单位2Text", typeof(string));
            dt.Columns.Add("已付款铁塔加工单位Text", typeof(string));
            dt.Columns.Add("已付款安装施工单位Text", typeof(string));
            dt.Columns.Add("已付款外电单位Text", typeof(string));
            dt.Columns.Add("已付款杆体搬运单位Text", typeof(string));
            dt.Columns.Add("已付款选址费用单位Text", typeof(string));
            dt.Columns.Add("已付款其他费用单位Text", typeof(string));
            dt.Columns.Add("发票情况设备单位1Text", typeof(string));
            dt.Columns.Add("发票情况设备单位2Text", typeof(string));
            dt.Columns.Add("发票情况设计单位Text", typeof(string));
            dt.Columns.Add("发票情况墈察单位Text", typeof(string));
            dt.Columns.Add("发票情况监理单位Text", typeof(string));
            dt.Columns.Add("发票情况项目管理单位Text", typeof(string));
            dt.Columns.Add("发票情况土建施工单位1Text", typeof(string));
            dt.Columns.Add("发票情况土建施工单位2Text", typeof(string));
            dt.Columns.Add("发票情况铁塔加工单位Text", typeof(string));
            dt.Columns.Add("发票情况安装施工单位Text", typeof(string));
            dt.Columns.Add("发票情况外电单位Text", typeof(string));
            dt.Columns.Add("发票情况杆体搬运单位Text", typeof(string));
            dt.Columns.Add("发票情况选址费用单位Text", typeof(string));
            dt.Columns.Add("发票情况其他费用单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票设备单位1Text", typeof(string));
            dt.Columns.Add("已付款未回发票设备单位2Text", typeof(string));
            dt.Columns.Add("已付款未回发票设计单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票墈察单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票监理单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票项目管理单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票土建施工单位1Text", typeof(string));
            dt.Columns.Add("已付款未回发票土建施工单位2Text", typeof(string));
            dt.Columns.Add("已付款未回发票铁塔加工单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票安装施工单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票外电单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票杆体搬运单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票选址费用单位Text", typeof(string));
            dt.Columns.Add("已付款未回发票其他费用单位Text", typeof(string));
            dt.Columns.Add("未付款设备单位1Text", typeof(string));
            dt.Columns.Add("未付款设备单位2Text", typeof(string));
            dt.Columns.Add("未付款设计单位Text", typeof(string));
            dt.Columns.Add("未付款墈察单位Text", typeof(string));
            dt.Columns.Add("未付款监理单位Text", typeof(string));
            dt.Columns.Add("未付款项目管理单位Text", typeof(string));
            dt.Columns.Add("未付款土建施工单位1Text", typeof(string));
            dt.Columns.Add("未付款土建施工单位2Text", typeof(string));
            dt.Columns.Add("未付款铁塔加工单位Text", typeof(string));
            dt.Columns.Add("未付款安装施工单位Text", typeof(string));
            dt.Columns.Add("未付款外电单位Text", typeof(string));
            dt.Columns.Add("未付款杆体搬运单位Text", typeof(string));
            dt.Columns.Add("未付款选址费用单位Text", typeof(string));
            dt.Columns.Add("未付款其他费用单位Text", typeof(string));


            DataTable dtData = new DataTable();
            DataSet ds = new BLL.Company().GetAllList();
            if (ds != null && ds.Tables.Count > 0)
            {
                dtData = ds.Tables[0];
            }
            //如果数据为空，则不处理
            if (dtData == null || dtData.Rows.Count == 0)
            {
                return dt;
            }
            //遍历添加数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //遍历列，找到需要添加的列
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string ColumnName = dt.Columns[j].ColumnName;
                    //如果是需要改变的文本
                    if (ColumnName.Contains("单位") && ColumnName.Contains("Text"))
                    {
                        string dataId = dt.Rows[i][dt.Columns[j].ColumnName.Replace("Text", "")].ToString();
                        if (!string.IsNullOrEmpty(dataId))
                        {
                            DataRow[] drs = dtData.Select("id='" + dataId + "'");
                            if (drs.Length > 0)
                            {
                                dt.Rows[i][ColumnName] = drs[0]["CompanyName"];
                            }
                        }
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
            DataTable dtTemplate = NOPI_ExcelHelp.ImportDataTableFromExcel2007(Server.MapPath("~/") + @"\Excel\Template\以租代建项目损益表模板.xlsx");
            json = new Excel.YzdjSyExcel().Import(dt, dtTemplate);
            return Json(json);
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ExcelExport(Model.YzdjSy model)
        {
            string where = " IsDeleted!=1 ";
            if (!string.IsNullOrEmpty(model.部门) && CommonHelper.filterSql(model.部门))
            {
                where += "and 部门 = '" + model.部门 + "' ";
            }
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
            string filePathTemplate = Server.MapPath("~/") + @"\Excel\Template\以租代建项目损益表模板.xlsx";
            List<Model.User_Columns> modelExistsList =new BLL.User_Columns().GetModelList("type='export' AND tableName='YzdjSy' AND UserId='" + CurrentUser.User.Userinfo.UserID + "'");
            string hideColumns = "";
            if (modelExistsList != null && modelExistsList.Count > 0)
            {
                hideColumns = modelExistsList[0].hideColumns.Trim(',');
            }
            else
            {
                hideColumns = "";
            }
            new NOPI_ExcelHelp().OutputExcel(dt, filePathTemplate, this.HttpContext, "以租代建项目损益信息" + DateTime.Now.ToString("yyyyMMddHHmmss"), hideColumns);
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
            DataTable dtCompany = new BLL.Company().GetAllList().Tables[0];
            //遍历修改数据
            dt.Columns.Add("序号", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["部门"] = CommonHelper.getDepartmentName(dtDepartment, dt.Rows[i]["部门"]);
                dt.Rows[i]["区域"] = CommonHelper.getAreaName(dtArea, dt.Rows[i]["区域"]);
                dt.Rows[i]["客户名称"] = CommonHelper.getCustomerName(dtCustomer, dt.Rows[i]["客户名称"]);
                //如果数据为空，则不处理
                if (dtCompany != null || dtCompany.Rows.Count > 0)
                {
                    //遍历列，找到需要添加的列
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string ColumnName = dt.Columns[j].ColumnName;
                        //如果是需要改变的文本
                        if (ColumnName.Contains("单位"))
                        {
                            dt.Rows[i][ColumnName] = CommonHelper.getCompanyName(dtCompany, dt.Rows[i][ColumnName]);
                           
                        }
                    }
                }
                dt.Rows[i]["序号"] = i + 1;
            }

            
           

            dt.Columns.Remove("id");
            dt.Columns.Remove("备注");
            dt.Columns.Remove("CreateBy");
            dt.Columns.Remove("CreateTime");
            dt.Columns.Remove("UpdateBy");
            dt.Columns.Remove("UpdateTime");
            return dt;
        }
    }
}
