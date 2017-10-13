using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using WTCJ.DBUtility;

namespace WTCJ.Excel
{
    public class YzdjSyExcel
    {
        BLL.YzdjSy BLL = new WTCJ.BLL.YzdjSy();
        public JsonObject Import(DataTable dt, DataTable dtTemplate)
        {

            JsonObject json = new JsonObject();
            if (dt == null || dt.Rows.Count == 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "数据为空";
                return json;
            }

            if (dtTemplate == null)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "数据导入失败，模板错误，请联系管理员";
                return json;
            }
            string checkTemplate = CommonHelper.Matching(dt, dtTemplate);
            if (checkTemplate != "")
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "数据导入失败，" + checkTemplate + ",请下载最新模板";
                return json;
            }
            StringBuilder sbErro = new StringBuilder();
            List<Model.YzdjSy> list = new List<Model.YzdjSy>();
            DataTable dtArea = new BLL.Area().GetAllList().Tables[0];
            DataTable dtDepartment = new BLL.Department().GetAllList().Tables[0];
            DataTable dtCustomer = new BLL.Customer().GetAllList().Tables[0];
            DataTable dtCompany = new BLL.Company().GetAllList().Tables[0];
            DateTime parmTime = DateTime.Now;
            DateTime dateTimeNow = DateTime.Now;
            decimal parmDecimal = 0;
            int parmInt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i < dtTemplate.Rows.Count)
                {
                    //模板前几列不执行
                    continue;
                }
                bool checkNul = true; ;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null && dt.Rows[i][j].ToString() != "")
                    {
                        checkNul = false;
                        break;
                    }
                }
                if (checkNul)
                {//如果行数据为空则忽略
                    continue;
                }
                StringBuilder sbErroI = new StringBuilder();
                //如果第一列为~开头，则为示例数据，不导入
                if (dt.Rows[i][0] != null && dt.Rows[i][0].ToString() != "" && dt.Rows[i][0].ToString().Substring(0, 1) == "~")
                {
                    continue;
                }
                Model.YzdjSy model = new Model.YzdjSy();
                if (dt.Rows[i]["部门"] != null && dt.Rows[i]["部门"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getDepartmentId(dtDepartment, dt.Rows[i]["部门"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",部门[" + dt.Rows[i]["部门"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.部门 = parm;
                    }
                }
                else
                {
                    sbErroI.Append(",部门不能为空");
                }

                if (dt.Rows[i]["区域"] != null && dt.Rows[i]["区域"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getAreaId(dtArea, dt.Rows[i]["区域"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",区域[" + dt.Rows[i]["区域"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.区域 = parm;
                    }
                }
                else
                {
                    sbErroI.Append(",区域不能为空");
                }
                if (dt.Rows[i]["客户名称"] != null && dt.Rows[i]["客户名称"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCustomerId(dtCustomer, dt.Rows[i]["客户名称"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",客户名称[" + dt.Rows[i]["客户名称"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.客户名称 = parm;
                    }
                }
                else
                {
                    sbErroI.Append(",客户名称不能为空");
                }
                if (dt.Rows[i]["站点编码"] != null && dt.Rows[i]["站点编码"].ToString().Trim() != "")
                {
                    model.站点编码 = dt.Rows[i]["站点编码"].ToString().Trim();
                }
                else
                {
                    sbErroI.Append(",站点编码不能为空");
                }
                if (dt.Rows[i]["站点名称"] != null && dt.Rows[i]["站点名称"].ToString().Trim() != "")
                {
                    model.站点名称 = dt.Rows[i]["站点名称"].ToString().Trim();
                }
                else
                {
                    sbErroI.Append(",站点名称不能为空");
                }
                if (dt.Rows[i]["建站类型"] != null && dt.Rows[i]["建站类型"].ToString().Trim() != "")
                {
                    model.建站类型 = dt.Rows[i]["建站类型"].ToString().Trim();
                }
                if (dt.Rows[i]["经度"] != null && dt.Rows[i]["经度"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["经度"].ToString().Trim(), out parmDecimal))
                    {
                        model.经度 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",经度[" + dt.Rows[i]["经度"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["纬度"] != null && dt.Rows[i]["纬度"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["纬度"].ToString().Trim(), out parmDecimal))
                    {
                        model.纬度 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",纬度[" + dt.Rows[i]["纬度"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["摘牌时间"] != null && dt.Rows[i]["摘牌时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["摘牌时间"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",摘牌时间[" + dt.Rows[i]["摘牌时间"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.摘牌时间 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",摘牌时间[" + dt.Rows[i]["摘牌时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["进场施工时间"] != null && dt.Rows[i]["进场施工时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["进场施工时间"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",进场施工时间[" + dt.Rows[i]["进场施工时间"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.摘牌时间 != null && model.摘牌时间 > parmTime)
                        {
                            sbErroI.Append(",进场施工时间[" + dt.Rows[i]["进场施工时间"].ToString().Trim() + "]必须大于等于摘牌时间[" + dt.Rows[i]["摘牌时间"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.进场施工时间 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",进场施工时间[" + dt.Rows[i]["进场施工时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["预计完工时间"] != null && dt.Rows[i]["预计完工时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["预计完工时间"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",预计完工时间[" + dt.Rows[i]["预计完工时间"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.进场施工时间 != null && model.进场施工时间 > parmTime)
                        {
                            sbErroI.Append(",预计完工时间[" + dt.Rows[i]["预计完工时间"].ToString().Trim() + "]必须大于等于进场施工时间[" + dt.Rows[i]["进场施工时间"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.预计完工时间 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",预计完工时间[" + dt.Rows[i]["预计完工时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["建站周期"] != null && dt.Rows[i]["建站周期"].ToString().Trim() != "")
                {

                    if (int.TryParse(dt.Rows[i]["建站周期"].ToString().Trim(), out parmInt))
                    {
                        model.建站周期 = parmInt;
                    }
                    else
                    {
                        sbErroI.Append(",建站周期[" + dt.Rows[i]["建站周期"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["预估运营商收入年租金"] != null && dt.Rows[i]["预估运营商收入年租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["预估运营商收入年租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.预估运营商收入年租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",预估运营商收入年租金[" + dt.Rows[i]["预估运营商收入年租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["预估运营商收入年限"] != null && dt.Rows[i]["预估运营商收入年限"].ToString().Trim() != "")
                {

                    if (int.TryParse(dt.Rows[i]["预估运营商收入年限"].ToString().Trim(), out parmInt))
                    {
                        model.预估运营商收入年限 = parmInt;
                    }
                    else
                    {
                        sbErroI.Append(",预估运营商收入年限[" + dt.Rows[i]["预估运营商收入年限"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["预估运营商收入总租金"] != null && dt.Rows[i]["预估运营商收入总租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["预估运营商收入总租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.预估运营商收入总租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",预估运营商收入总租金[" + dt.Rows[i]["预估运营商收入总租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通收入"] != null && dt.Rows[i]["伟通收入"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通收入"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通收入 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通收入[" + dt.Rows[i]["伟通收入"].ToString().Trim() + "]必须为数字");
                    }
                }
                #region 成本
                if (dt.Rows[i]["成本设备单位1"] != null && dt.Rows[i]["成本设备单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本设备单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本设备单位1[" + dt.Rows[i]["成本设备单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本设备单位1 = parm;
                    }
                }
                if (dt.Rows[i]["成本设备成本1"] != null && dt.Rows[i]["成本设备成本1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本设备成本1"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本设备成本1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本设备成本1[" + dt.Rows[i]["成本设备成本1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本设备单位2"] != null && dt.Rows[i]["成本设备单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本设备单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本设备单位2[" + dt.Rows[i]["成本设备单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本设备单位2 = parm;
                    }
                }
                if (dt.Rows[i]["成本设备成本2"] != null && dt.Rows[i]["成本设备成本2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本设备成本2"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本设备成本2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本设备成本2[" + dt.Rows[i]["成本设备成本2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本场地业主"] != null && dt.Rows[i]["成本场地业主"].ToString().Trim() != "")
                {
                    model.成本场地业主 = dt.Rows[i]["成本场地业主"].ToString().Trim();
                }
                if (dt.Rows[i]["成本租赁成本"] != null && dt.Rows[i]["成本租赁成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本租赁成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本租赁成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本租赁成本[" + dt.Rows[i]["成本租赁成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本设计单位"] != null && dt.Rows[i]["成本设计单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本设计单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本设计单位[" + dt.Rows[i]["成本设计单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本设计单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本设计成本"] != null && dt.Rows[i]["成本设计成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本设计成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本设计成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本设计成本[" + dt.Rows[i]["成本设计成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本地勘单位"] != null && dt.Rows[i]["成本地勘单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本地勘单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本地勘单位[" + dt.Rows[i]["成本地勘单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本地勘单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本地勘成本"] != null && dt.Rows[i]["成本地勘成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本地勘成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本地勘成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本地勘成本[" + dt.Rows[i]["成本地勘成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本监理单位"] != null && dt.Rows[i]["成本监理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本监理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本监理单位[" + dt.Rows[i]["成本监理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本监理单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本监理成本"] != null && dt.Rows[i]["成本监理成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本监理成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本监理成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本监理成本[" + dt.Rows[i]["成本监理成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本项目管理单位"] != null && dt.Rows[i]["成本项目管理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本项目管理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本项目管理单位[" + dt.Rows[i]["成本项目管理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本项目管理单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本项目管理成本"] != null && dt.Rows[i]["成本项目管理成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本项目管理成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本项目管理成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本项目管理成本[" + dt.Rows[i]["成本项目管理成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本土建施工单位1"] != null && dt.Rows[i]["成本土建施工单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本土建施工单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本土建施工单位1[" + dt.Rows[i]["成本土建施工单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本土建施工单位1 = parm;
                    }
                }
                if (dt.Rows[i]["成本土建施工成本1"] != null && dt.Rows[i]["成本土建施工成本1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本土建施工成本1"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本土建施工成本1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本土建施工成本1[" + dt.Rows[i]["成本土建施工成本1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本土建施工单位2"] != null && dt.Rows[i]["成本土建施工单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本土建施工单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本土建施工单位2[" + dt.Rows[i]["成本土建施工单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本土建施工单位2 = parm;
                    }
                }
                if (dt.Rows[i]["成本土建施工成本2"] != null && dt.Rows[i]["成本土建施工成本2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本土建施工成本2"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本土建施工成本2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本土建施工成本2[" + dt.Rows[i]["成本土建施工成本2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本铁塔加工单位"] != null && dt.Rows[i]["成本铁塔加工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本铁塔加工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本铁塔加工单位[" + dt.Rows[i]["成本铁塔加工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本铁塔加工单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本铁塔加工成本"] != null && dt.Rows[i]["成本铁塔加工成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本铁塔加工成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本铁塔加工成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本铁塔加工成本[" + dt.Rows[i]["成本铁塔加工成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本安装施工单位"] != null && dt.Rows[i]["成本安装施工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本安装施工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本安装施工单位[" + dt.Rows[i]["成本安装施工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本安装施工单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本安装施工成本"] != null && dt.Rows[i]["成本安装施工成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本安装施工成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本安装施工成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本安装施工成本[" + dt.Rows[i]["成本安装施工成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本外电单位"] != null && dt.Rows[i]["成本外电单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本外电单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本外电单位[" + dt.Rows[i]["成本外电单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本外电单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本外电费"] != null && dt.Rows[i]["成本外电费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本外电费"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本外电费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本外电费[" + dt.Rows[i]["成本外电费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本杆体搬运单位"] != null && dt.Rows[i]["成本杆体搬运单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本杆体搬运单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本杆体搬运单位[" + dt.Rows[i]["成本杆体搬运单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本杆体搬运单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本杆体搬运费"] != null && dt.Rows[i]["成本杆体搬运费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本杆体搬运费"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本杆体搬运费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本杆体搬运费[" + dt.Rows[i]["成本杆体搬运费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本选址费用单位"] != null && dt.Rows[i]["成本选址费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本选址费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本选址费用单位[" + dt.Rows[i]["成本选址费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本选址费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本选址费"] != null && dt.Rows[i]["成本选址费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本选址费"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本选址费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本选址费[" + dt.Rows[i]["成本选址费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["成本其他费用单位"] != null && dt.Rows[i]["成本其他费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["成本其他费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",成本其他费用单位[" + dt.Rows[i]["成本其他费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.成本其他费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["成本其他费用"] != null && dt.Rows[i]["成本其他费用"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["成本其他费用"].ToString().Trim(), out parmDecimal))
                    {
                        model.成本其他费用 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",成本其他费用[" + dt.Rows[i]["成本其他费用"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["总成本"] != null && dt.Rows[i]["总成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["总成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.总成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",总成本[" + dt.Rows[i]["总成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["毛利率"] != null && dt.Rows[i]["毛利率"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["毛利率"].ToString().Trim(), out parmDecimal))
                    {
                        model.毛利率 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",毛利率[" + dt.Rows[i]["毛利率"].ToString().Trim() + "]必须为数字");
                    }
                }
                #endregion

                #region 已付款

                if (dt.Rows[i]["已付款设备单位1"] != null && dt.Rows[i]["已付款设备单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款设备单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款设备单位1[" + dt.Rows[i]["已付款设备单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款设备单位1 = parm;
                    }
                }
                if (dt.Rows[i]["已付款设备费1"] != null && dt.Rows[i]["已付款设备费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款设备费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款设备费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款设备费1[" + dt.Rows[i]["已付款设备费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款设备单位2"] != null && dt.Rows[i]["已付款设备单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款设备单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款设备单位2[" + dt.Rows[i]["已付款设备单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款设备单位2 = parm;
                    }
                }
                if (dt.Rows[i]["已付款设备费2"] != null && dt.Rows[i]["已付款设备费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款设备费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款设备费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款设备费2[" + dt.Rows[i]["已付款设备费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款业主"] != null && dt.Rows[i]["已付款业主"].ToString().Trim() != "")
                {
                    model.已付款业主 = dt.Rows[i]["已付款业主"].ToString().Trim();
                }
                if (dt.Rows[i]["已付款业主租金"] != null && dt.Rows[i]["已付款业主租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款业主租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款业主租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款业主租金[" + dt.Rows[i]["已付款业主租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款设计单位"] != null && dt.Rows[i]["已付款设计单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款设计单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款设计单位[" + dt.Rows[i]["已付款设计单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款设计单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款设计费"] != null && dt.Rows[i]["已付款设计费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款设计费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款设计费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款设计费[" + dt.Rows[i]["已付款设计费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款墈察单位"] != null && dt.Rows[i]["已付款墈察单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款墈察单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款墈察单位[" + dt.Rows[i]["已付款墈察单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款墈察单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款墈察费"] != null && dt.Rows[i]["已付款墈察费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款墈察费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款墈察费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款墈察费[" + dt.Rows[i]["已付款墈察费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款监理单位"] != null && dt.Rows[i]["已付款监理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款监理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款监理单位[" + dt.Rows[i]["已付款监理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款监理单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款监理费"] != null && dt.Rows[i]["已付款监理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款监理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款监理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款监理费[" + dt.Rows[i]["已付款监理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款项目管理单位"] != null && dt.Rows[i]["已付款项目管理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款项目管理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款项目管理单位[" + dt.Rows[i]["已付款项目管理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款项目管理单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款项目管理费"] != null && dt.Rows[i]["已付款项目管理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款项目管理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款项目管理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款项目管理费[" + dt.Rows[i]["已付款项目管理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款土建施工单位1"] != null && dt.Rows[i]["已付款土建施工单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款土建施工单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款土建施工单位1[" + dt.Rows[i]["已付款土建施工单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款土建施工单位1 = parm;
                    }
                }
                if (dt.Rows[i]["已付款土建施工费1"] != null && dt.Rows[i]["已付款土建施工费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款土建施工费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款土建施工费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款土建施工费1[" + dt.Rows[i]["已付款土建施工费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款土建施工单位2"] != null && dt.Rows[i]["已付款土建施工单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款土建施工单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款土建施工单位2[" + dt.Rows[i]["已付款土建施工单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款土建施工单位2 = parm;
                    }
                }
                if (dt.Rows[i]["已付款土建施工费2"] != null && dt.Rows[i]["已付款土建施工费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款土建施工费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款土建施工费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款土建施工费2[" + dt.Rows[i]["已付款土建施工费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款铁塔加工单位"] != null && dt.Rows[i]["已付款铁塔加工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款铁塔加工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款铁塔加工单位[" + dt.Rows[i]["已付款铁塔加工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款铁塔加工单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款铁塔加工费"] != null && dt.Rows[i]["已付款铁塔加工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款铁塔加工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款铁塔加工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款铁塔加工费[" + dt.Rows[i]["已付款铁塔加工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款安装施工单位"] != null && dt.Rows[i]["已付款安装施工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款安装施工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款安装施工单位[" + dt.Rows[i]["已付款安装施工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款安装施工单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款安装施工费"] != null && dt.Rows[i]["已付款安装施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款安装施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款安装施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款安装施工费[" + dt.Rows[i]["已付款安装施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款外电单位"] != null && dt.Rows[i]["已付款外电单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款外电单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款外电单位[" + dt.Rows[i]["已付款外电单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款外电单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款外电施工费"] != null && dt.Rows[i]["已付款外电施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款外电施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款外电施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款外电施工费[" + dt.Rows[i]["已付款外电施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款杆体搬运单位"] != null && dt.Rows[i]["已付款杆体搬运单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款杆体搬运单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款杆体搬运单位[" + dt.Rows[i]["已付款杆体搬运单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款杆体搬运单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款杆体搬运费"] != null && dt.Rows[i]["已付款杆体搬运费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款杆体搬运费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款杆体搬运费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款杆体搬运费[" + dt.Rows[i]["已付款杆体搬运费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款选址费用单位"] != null && dt.Rows[i]["已付款选址费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款选址费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款选址费用单位[" + dt.Rows[i]["已付款选址费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款选址费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款选址费"] != null && dt.Rows[i]["已付款选址费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款选址费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款选址费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款选址费[" + dt.Rows[i]["已付款选址费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款其他费用单位"] != null && dt.Rows[i]["已付款其他费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款其他费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款其他费用单位[" + dt.Rows[i]["已付款其他费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款其他费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款其他费用"] != null && dt.Rows[i]["已付款其他费用"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款其他费用"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款其他费用 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款其他费用[" + dt.Rows[i]["已付款其他费用"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["总计付款"] != null && dt.Rows[i]["总计付款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["总计付款"].ToString().Trim(), out parmDecimal))
                    {
                        model.总计付款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",总计付款[" + dt.Rows[i]["总计付款"].ToString().Trim() + "]必须为数字");
                    }
                }
                #endregion


                #region 发票情况

                if (dt.Rows[i]["发票情况设备单位1"] != null && dt.Rows[i]["发票情况设备单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况设备单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况设备单位1[" + dt.Rows[i]["发票情况设备单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况设备单位1 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况设备费1"] != null && dt.Rows[i]["发票情况设备费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况设备费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况设备费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况设备费1[" + dt.Rows[i]["发票情况设备费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况设备单位2"] != null && dt.Rows[i]["发票情况设备单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况设备单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况设备单位2[" + dt.Rows[i]["发票情况设备单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况设备单位2 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况设备费2"] != null && dt.Rows[i]["发票情况设备费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况设备费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况设备费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况设备费2[" + dt.Rows[i]["发票情况设备费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况业主"] != null && dt.Rows[i]["发票情况业主"].ToString().Trim() != "")
                {
                    model.发票情况业主 = dt.Rows[i]["发票情况业主"].ToString().Trim();
                }
                if (dt.Rows[i]["发票情况业主租金"] != null && dt.Rows[i]["发票情况业主租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况业主租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况业主租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况业主租金[" + dt.Rows[i]["发票情况业主租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况设计单位"] != null && dt.Rows[i]["发票情况设计单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况设计单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况设计单位[" + dt.Rows[i]["发票情况设计单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况设计单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况设计费"] != null && dt.Rows[i]["发票情况设计费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况设计费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况设计费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况设计费[" + dt.Rows[i]["发票情况设计费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况墈察单位"] != null && dt.Rows[i]["发票情况墈察单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况墈察单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况墈察单位[" + dt.Rows[i]["发票情况墈察单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况墈察单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况墈察费"] != null && dt.Rows[i]["发票情况墈察费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况墈察费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况墈察费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况墈察费[" + dt.Rows[i]["发票情况墈察费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况监理单位"] != null && dt.Rows[i]["发票情况监理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况监理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况监理单位[" + dt.Rows[i]["发票情况监理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况监理单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况监理费"] != null && dt.Rows[i]["发票情况监理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况监理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况监理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况监理费[" + dt.Rows[i]["发票情况监理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况项目管理单位"] != null && dt.Rows[i]["发票情况项目管理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况项目管理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况项目管理单位[" + dt.Rows[i]["发票情况项目管理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况项目管理单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况项目管理费"] != null && dt.Rows[i]["发票情况项目管理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况项目管理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况项目管理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况项目管理费[" + dt.Rows[i]["发票情况项目管理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况土建施工单位1"] != null && dt.Rows[i]["发票情况土建施工单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况土建施工单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况土建施工单位1[" + dt.Rows[i]["发票情况土建施工单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况土建施工单位1 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况土建施工费1"] != null && dt.Rows[i]["发票情况土建施工费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况土建施工费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况土建施工费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况土建施工费1[" + dt.Rows[i]["发票情况土建施工费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况土建施工单位2"] != null && dt.Rows[i]["发票情况土建施工单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况土建施工单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况土建施工单位2[" + dt.Rows[i]["发票情况土建施工单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况土建施工单位2 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况土建施工费2"] != null && dt.Rows[i]["发票情况土建施工费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况土建施工费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况土建施工费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况土建施工费2[" + dt.Rows[i]["发票情况土建施工费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况铁塔加工单位"] != null && dt.Rows[i]["发票情况铁塔加工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况铁塔加工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况铁塔加工单位[" + dt.Rows[i]["发票情况铁塔加工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况铁塔加工单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况铁塔加工费"] != null && dt.Rows[i]["发票情况铁塔加工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况铁塔加工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况铁塔加工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况铁塔加工费[" + dt.Rows[i]["发票情况铁塔加工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况安装施工单位"] != null && dt.Rows[i]["发票情况安装施工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况安装施工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况安装施工单位[" + dt.Rows[i]["发票情况安装施工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况安装施工单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况安装施工费"] != null && dt.Rows[i]["发票情况安装施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况安装施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况安装施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况安装施工费[" + dt.Rows[i]["发票情况安装施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况外电单位"] != null && dt.Rows[i]["发票情况外电单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况外电单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况外电单位[" + dt.Rows[i]["发票情况外电单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况外电单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况外电施工费"] != null && dt.Rows[i]["发票情况外电施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况外电施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况外电施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况外电施工费[" + dt.Rows[i]["发票情况外电施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况杆体搬运单位"] != null && dt.Rows[i]["发票情况杆体搬运单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况杆体搬运单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况杆体搬运单位[" + dt.Rows[i]["发票情况杆体搬运单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况杆体搬运单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况杆体搬运费"] != null && dt.Rows[i]["发票情况杆体搬运费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况杆体搬运费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况杆体搬运费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况杆体搬运费[" + dt.Rows[i]["发票情况杆体搬运费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况选址费用单位"] != null && dt.Rows[i]["发票情况选址费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况选址费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况选址费用单位[" + dt.Rows[i]["发票情况选址费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况选址费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况选址费"] != null && dt.Rows[i]["发票情况选址费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况选址费"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况选址费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况选址费[" + dt.Rows[i]["发票情况选址费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况其他费用单位"] != null && dt.Rows[i]["发票情况其他费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["发票情况其他费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",发票情况其他费用单位[" + dt.Rows[i]["发票情况其他费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.发票情况其他费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["发票情况其他费用"] != null && dt.Rows[i]["发票情况其他费用"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况其他费用"].ToString().Trim(), out parmDecimal))
                    {
                        model.发票情况其他费用 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况其他费用[" + dt.Rows[i]["发票情况其他费用"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["发票情况总计金额"] != null && dt.Rows[i]["发票情况总计金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["发票情况总计金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.总计付款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",发票情况总计金额[" + dt.Rows[i]["发票情况总计金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                #endregion


                #region 已付款未回发票

                if (dt.Rows[i]["已付款未回发票设备单位1"] != null && dt.Rows[i]["已付款未回发票设备单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票设备单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票设备单位1[" + dt.Rows[i]["已付款未回发票设备单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票设备单位1 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票设备费1"] != null && dt.Rows[i]["已付款未回发票设备费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票设备费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票设备费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票设备费1[" + dt.Rows[i]["已付款未回发票设备费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票设备单位2"] != null && dt.Rows[i]["已付款未回发票设备单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票设备单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票设备单位2[" + dt.Rows[i]["已付款未回发票设备单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票设备单位2 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票设备费2"] != null && dt.Rows[i]["已付款未回发票设备费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票设备费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票设备费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票设备费2[" + dt.Rows[i]["已付款未回发票设备费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票业主"] != null && dt.Rows[i]["已付款未回发票业主"].ToString().Trim() != "")
                {
                    model.已付款未回发票业主 = dt.Rows[i]["已付款未回发票业主"].ToString().Trim();
                }
                if (dt.Rows[i]["已付款未回发票业主租金"] != null && dt.Rows[i]["已付款未回发票业主租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票业主租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票业主租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票业主租金[" + dt.Rows[i]["已付款未回发票业主租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票设计单位"] != null && dt.Rows[i]["已付款未回发票设计单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票设计单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票设计单位[" + dt.Rows[i]["已付款未回发票设计单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票设计单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票设计费"] != null && dt.Rows[i]["已付款未回发票设计费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票设计费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票设计费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票设计费[" + dt.Rows[i]["已付款未回发票设计费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票墈察单位"] != null && dt.Rows[i]["已付款未回发票墈察单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票墈察单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票墈察单位[" + dt.Rows[i]["已付款未回发票墈察单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票墈察单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票墈察费"] != null && dt.Rows[i]["已付款未回发票墈察费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票墈察费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票墈察费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票墈察费[" + dt.Rows[i]["已付款未回发票墈察费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票监理单位"] != null && dt.Rows[i]["已付款未回发票监理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票监理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票监理单位[" + dt.Rows[i]["已付款未回发票监理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票监理单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票监理费"] != null && dt.Rows[i]["已付款未回发票监理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票监理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票监理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票监理费[" + dt.Rows[i]["已付款未回发票监理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票项目管理单位"] != null && dt.Rows[i]["已付款未回发票项目管理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票项目管理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票项目管理单位[" + dt.Rows[i]["已付款未回发票项目管理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票项目管理单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票项目管理费"] != null && dt.Rows[i]["已付款未回发票项目管理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票项目管理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票项目管理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票项目管理费[" + dt.Rows[i]["已付款未回发票项目管理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票土建施工单位1"] != null && dt.Rows[i]["已付款未回发票土建施工单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票土建施工单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票土建施工单位1[" + dt.Rows[i]["已付款未回发票土建施工单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票土建施工单位1 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票土建施工费1"] != null && dt.Rows[i]["已付款未回发票土建施工费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票土建施工费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票土建施工费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票土建施工费1[" + dt.Rows[i]["已付款未回发票土建施工费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票土建施工单位2"] != null && dt.Rows[i]["已付款未回发票土建施工单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票土建施工单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票土建施工单位2[" + dt.Rows[i]["已付款未回发票土建施工单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票土建施工单位2 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票土建施工费2"] != null && dt.Rows[i]["已付款未回发票土建施工费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票土建施工费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票土建施工费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票土建施工费2[" + dt.Rows[i]["已付款未回发票土建施工费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票铁塔加工单位"] != null && dt.Rows[i]["已付款未回发票铁塔加工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票铁塔加工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票铁塔加工单位[" + dt.Rows[i]["已付款未回发票铁塔加工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票铁塔加工单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票铁塔加工费"] != null && dt.Rows[i]["已付款未回发票铁塔加工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票铁塔加工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票铁塔加工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票铁塔加工费[" + dt.Rows[i]["已付款未回发票铁塔加工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票安装施工单位"] != null && dt.Rows[i]["已付款未回发票安装施工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票安装施工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票安装施工单位[" + dt.Rows[i]["已付款未回发票安装施工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票安装施工单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票安装施工费"] != null && dt.Rows[i]["已付款未回发票安装施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票安装施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票安装施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票安装施工费[" + dt.Rows[i]["已付款未回发票安装施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票外电单位"] != null && dt.Rows[i]["已付款未回发票外电单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票外电单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票外电单位[" + dt.Rows[i]["已付款未回发票外电单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票外电单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票外电施工费"] != null && dt.Rows[i]["已付款未回发票外电施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票外电施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票外电施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票外电施工费[" + dt.Rows[i]["已付款未回发票外电施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票杆体搬运单位"] != null && dt.Rows[i]["已付款未回发票杆体搬运单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票杆体搬运单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票杆体搬运单位[" + dt.Rows[i]["已付款未回发票杆体搬运单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票杆体搬运单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票杆体搬运费"] != null && dt.Rows[i]["已付款未回发票杆体搬运费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票杆体搬运费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票杆体搬运费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票杆体搬运费[" + dt.Rows[i]["已付款未回发票杆体搬运费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票选址费用单位"] != null && dt.Rows[i]["已付款未回发票选址费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票选址费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票选址费用单位[" + dt.Rows[i]["已付款未回发票选址费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票选址费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票选址费"] != null && dt.Rows[i]["已付款未回发票选址费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票选址费"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票选址费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票选址费[" + dt.Rows[i]["已付款未回发票选址费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票其他费用单位"] != null && dt.Rows[i]["已付款未回发票其他费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["已付款未回发票其他费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",已付款未回发票其他费用单位[" + dt.Rows[i]["已付款未回发票其他费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.已付款未回发票其他费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["已付款未回发票其他费用"] != null && dt.Rows[i]["已付款未回发票其他费用"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票其他费用"].ToString().Trim(), out parmDecimal))
                    {
                        model.已付款未回发票其他费用 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票其他费用[" + dt.Rows[i]["已付款未回发票其他费用"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["已付款未回发票总计金额"] != null && dt.Rows[i]["已付款未回发票总计金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["已付款未回发票总计金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.总计付款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",已付款未回发票总计金额[" + dt.Rows[i]["已付款未回发票总计金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                #endregion


                #region 未付款

                if (dt.Rows[i]["未付款设备单位1"] != null && dt.Rows[i]["未付款设备单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款设备单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款设备单位1[" + dt.Rows[i]["未付款设备单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款设备单位1 = parm;
                    }
                }
                if (dt.Rows[i]["未付款设备费1"] != null && dt.Rows[i]["未付款设备费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款设备费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款设备费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款设备费1[" + dt.Rows[i]["未付款设备费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款设备单位2"] != null && dt.Rows[i]["未付款设备单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款设备单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款设备单位2[" + dt.Rows[i]["未付款设备单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款设备单位2 = parm;
                    }
                }
                if (dt.Rows[i]["未付款设备费2"] != null && dt.Rows[i]["未付款设备费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款设备费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款设备费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款设备费2[" + dt.Rows[i]["未付款设备费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款业主"] != null && dt.Rows[i]["未付款业主"].ToString().Trim() != "")
                {
                    model.未付款业主 = dt.Rows[i]["未付款业主"].ToString().Trim();
                }
                if (dt.Rows[i]["未付款业主租金"] != null && dt.Rows[i]["未付款业主租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款业主租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款业主租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款业主租金[" + dt.Rows[i]["未付款业主租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款设计单位"] != null && dt.Rows[i]["未付款设计单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款设计单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款设计单位[" + dt.Rows[i]["未付款设计单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款设计单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款设计费"] != null && dt.Rows[i]["未付款设计费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款设计费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款设计费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款设计费[" + dt.Rows[i]["未付款设计费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款墈察单位"] != null && dt.Rows[i]["未付款墈察单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款墈察单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款墈察单位[" + dt.Rows[i]["未付款墈察单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款墈察单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款墈察费"] != null && dt.Rows[i]["未付款墈察费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款墈察费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款墈察费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款墈察费[" + dt.Rows[i]["未付款墈察费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款监理单位"] != null && dt.Rows[i]["未付款监理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款监理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款监理单位[" + dt.Rows[i]["未付款监理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款监理单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款监理费"] != null && dt.Rows[i]["未付款监理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款监理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款监理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款监理费[" + dt.Rows[i]["未付款监理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款项目管理单位"] != null && dt.Rows[i]["未付款项目管理单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款项目管理单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款项目管理单位[" + dt.Rows[i]["未付款项目管理单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款项目管理单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款项目管理费"] != null && dt.Rows[i]["未付款项目管理费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款项目管理费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款项目管理费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款项目管理费[" + dt.Rows[i]["未付款项目管理费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款土建施工单位1"] != null && dt.Rows[i]["未付款土建施工单位1"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款土建施工单位1"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款土建施工单位1[" + dt.Rows[i]["未付款土建施工单位1"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款土建施工单位1 = parm;
                    }
                }
                if (dt.Rows[i]["未付款土建施工费1"] != null && dt.Rows[i]["未付款土建施工费1"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款土建施工费1"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款土建施工费1 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款土建施工费1[" + dt.Rows[i]["未付款土建施工费1"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款土建施工单位2"] != null && dt.Rows[i]["未付款土建施工单位2"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款土建施工单位2"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款土建施工单位2[" + dt.Rows[i]["未付款土建施工单位2"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款土建施工单位2 = parm;
                    }
                }
                if (dt.Rows[i]["未付款土建施工费2"] != null && dt.Rows[i]["未付款土建施工费2"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款土建施工费2"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款土建施工费2 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款土建施工费2[" + dt.Rows[i]["未付款土建施工费2"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款铁塔加工单位"] != null && dt.Rows[i]["未付款铁塔加工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款铁塔加工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款铁塔加工单位[" + dt.Rows[i]["未付款铁塔加工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款铁塔加工单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款铁塔加工费"] != null && dt.Rows[i]["未付款铁塔加工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款铁塔加工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款铁塔加工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款铁塔加工费[" + dt.Rows[i]["未付款铁塔加工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款安装施工单位"] != null && dt.Rows[i]["未付款安装施工单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款安装施工单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款安装施工单位[" + dt.Rows[i]["未付款安装施工单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款安装施工单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款安装施工费"] != null && dt.Rows[i]["未付款安装施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款安装施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款安装施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款安装施工费[" + dt.Rows[i]["未付款安装施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款外电单位"] != null && dt.Rows[i]["未付款外电单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款外电单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款外电单位[" + dt.Rows[i]["未付款外电单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款外电单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款外电施工费"] != null && dt.Rows[i]["未付款外电施工费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款外电施工费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款外电施工费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款外电施工费[" + dt.Rows[i]["未付款外电施工费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款杆体搬运单位"] != null && dt.Rows[i]["未付款杆体搬运单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款杆体搬运单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款杆体搬运单位[" + dt.Rows[i]["未付款杆体搬运单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款杆体搬运单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款杆体搬运费"] != null && dt.Rows[i]["未付款杆体搬运费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款杆体搬运费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款杆体搬运费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款杆体搬运费[" + dt.Rows[i]["未付款杆体搬运费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款选址费用单位"] != null && dt.Rows[i]["未付款选址费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款选址费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款选址费用单位[" + dt.Rows[i]["未付款选址费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款选址费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款选址费"] != null && dt.Rows[i]["未付款选址费"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款选址费"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款选址费 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款选址费[" + dt.Rows[i]["未付款选址费"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款其他费用单位"] != null && dt.Rows[i]["未付款其他费用单位"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCompanyId(dtCompany, dt.Rows[i]["未付款其他费用单位"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",未付款其他费用单位[" + dt.Rows[i]["未付款其他费用单位"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.未付款其他费用单位 = parm;
                    }
                }
                if (dt.Rows[i]["未付款其他费用"] != null && dt.Rows[i]["未付款其他费用"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款其他费用"].ToString().Trim(), out parmDecimal))
                    {
                        model.未付款其他费用 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款其他费用[" + dt.Rows[i]["未付款其他费用"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["未付款总计金额"] != null && dt.Rows[i]["未付款总计金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["未付款总计金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.总计付款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",未付款总计金额[" + dt.Rows[i]["未付款总计金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                #endregion



                if (sbErroI.Length > 0)
                {
                    sbErro.Append(",第" + (i + 2) + "行数据：" + sbErroI.ToString().Substring(1));
                }
                list.Add(model);
            }
            //如果有错误信息
            if (sbErro.Length > 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = sbErro.ToString().Substring(1);
                return json;
            }
            if (list.Count == 0)
            {
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "数据为空";
                return json;
            }
            SqlConnection conn = new SqlConnection(PubConstant.ConnectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                int addCount = 0;
                int updateCount = 0;
                string userId = CurrentUser.User.Userinfo.UserID;
                DateTime timeNow = DateTime.Now;
                for (int i = 0; i < list.Count; i++)
                {
                    List<Model.YzdjSy> modelExistsList = BLL.GetModelList(trans, "站点编码='" + list[i].站点编码 + "' and IsDeleted!=1");
                    if (modelExistsList != null && modelExistsList.Count > 0)
                    {
                        list[i].id = modelExistsList[0].id;
                        list[i].备注 = modelExistsList[0].备注;
                        list[i].IsDeleted = modelExistsList[0].IsDeleted;
                        list[i].CreateBy = modelExistsList[0].CreateBy;
                        list[i].CreateTime = modelExistsList[0].CreateTime;
                        list[i].UpdateBy = userId;
                        list[i].UpdateTime = timeNow;
                        BLL.Update(trans, list[i]);
                        updateCount++;
                    }
                    else
                    {
                        list[i].IsDeleted = 0;
                        list[i].CreateBy = userId;
                        list[i].CreateTime = timeNow;
                        list[i].id = Guid.NewGuid().ToString();
                        BLL.Add(trans, list[i]);
                        addCount++;
                    }
                }
                trans.Commit();
                json.Status = JsonObject.STATUS_SUCCESS;
                json.Message = "导入成功";
                if (addCount > 0)
                {
                    json.Message += "，添加" + addCount + "条数据";
                }
                if (updateCount > 0)
                {
                    json.Message += "，修改" + updateCount + "条数据";
                }
                return json;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "导入失败，失败原因：" + ex.Message;
                return json;
            }
            finally
            {
                conn.Close();
            }

        }

    }
}