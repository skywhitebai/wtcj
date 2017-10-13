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
    public class JdSfExcel
    {
        BLL.JD_SF BLL = new WTCJ.BLL.JD_SF();
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
            List<Model.JD_SF> list = new List<Model.JD_SF>();
            DataTable dtDepartment = new BLL.Department().GetAllList().Tables[0];
            DataTable dtArea = new BLL.Area().GetAllList().Tables[0];
            DataTable dtCustomer = new BLL.Customer().GetAllList().Tables[0];
            DataTable dtCommonData = new BLL.Common_Data().GetList(" DataType in('最新状态')").Tables[0];

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
                Model.JD_SF model = new Model.JD_SF();
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
                if (dt.Rows[i]["类别"] != null && dt.Rows[i]["类别"].ToString().Trim() != "")
                {
                    if (dt.Rows[i]["类别"].ToString().Trim() != "自持" && dt.Rows[i]["类别"].ToString().Trim() != "销售")
                    {
                        sbErroI.Append(",类别[" + dt.Rows[i]["类别"].ToString().Trim() + "]不正确，类别必须是自持或销售");
                    }
                    else
                    {
                        model.类别 = dt.Rows[i]["类别"].ToString().Trim();
                    }
                }
                else
                {
                    sbErroI.Append(",类别不能为空");
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
                if (dt.Rows[i]["客户"] != null && dt.Rows[i]["客户"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCustomerId(dtCustomer, dt.Rows[i]["客户"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",客户[" + dt.Rows[i]["客户"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.客户 = parm;
                    }
                }
                else
                {
                    sbErroI.Append(",客户不能为空");
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
                if (dt.Rows[i]["地址"] != null && dt.Rows[i]["地址"].ToString().Trim() != "")
                {
                    model.地址 = dt.Rows[i]["地址"].ToString().Trim();
                }
                if (dt.Rows[i]["建站面积"] != null && dt.Rows[i]["建站面积"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["建站面积"].ToString().Trim(), out parmDecimal))
                    {
                        model.建站面积 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",建站面积[" + dt.Rows[i]["建站面积"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["预算表或损益表审批时间"] != null && dt.Rows[i]["预算表或损益表审批时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["预算表或损益表审批时间"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",预算表或损益表审批时间[" + dt.Rows[i]["预算表或损益表审批时间"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.预算表或损益表审批时间 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",预算表或损益表审批时间[" + dt.Rows[i]["预算表或损益表审批时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["与伟通签订单项合同日期"] != null && dt.Rows[i]["与伟通签订单项合同日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["与伟通签订单项合同日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",与伟通签订单项合同日期[" + dt.Rows[i]["与伟通签订单项合同日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.与伟通签订单项合同日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",与伟通签订单项合同日期[" + dt.Rows[i]["与伟通签订单项合同日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["最新状态"] != null && dt.Rows[i]["最新状态"].ToString().Trim() != "")
                {
                    string parm = CommonHelper.getCommonDataValue(dtCommonData, "最新状态", dt.Rows[i]["最新状态"].ToString().Trim());
                    if (parm == "")
                    {
                        sbErroI.Append(",最新状态[" + dt.Rows[i]["最新状态"].ToString().Trim() + "]不存在");
                    }
                    else
                    {
                        model.最新状态 = parm;
                    }
                }
                else
                {
                    sbErroI.Append(",最新状态不能为空");
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
                if (dt.Rows[i]["年租金"] != null && dt.Rows[i]["年租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["年租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.年租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",年租金[" + dt.Rows[i]["年租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["年限"] != null && dt.Rows[i]["年限"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["年限"].ToString().Trim(), out parmDecimal))
                    {
                        model.年限 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",年限[" + dt.Rows[i]["年限"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["总收入"] != null && dt.Rows[i]["总收入"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["总收入"].ToString().Trim(), out parmDecimal))
                    {
                        model.总收入 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",总收入[" + dt.Rows[i]["总收入"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通应收款"] != null && dt.Rows[i]["伟通应收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通应收款"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通应收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通应收款[" + dt.Rows[i]["伟通应收款"].ToString().Trim() + "]必须为数字");
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
                if (dt.Rows[i]["预计进场日期"] != null && dt.Rows[i]["预计进场日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["预计进场日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",预计进场日期[" + dt.Rows[i]["预计进场日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.摘牌时间 != null && model.摘牌时间 > parmTime)
                        {
                            sbErroI.Append(",预计进场日期[" + dt.Rows[i]["预计进场日期"].ToString().Trim() + "]必须大于等于摘牌时间[" + dt.Rows[i]["摘牌时间"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.预计进场日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",预计进场日期[" + dt.Rows[i]["预计进场日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["预计完工日期"] != null && dt.Rows[i]["预计完工日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["预计完工日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",预计完工日期[" + dt.Rows[i]["预计完工日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.预计进场日期 != null && model.预计进场日期 > parmTime)
                        {
                            sbErroI.Append(",预计完工日期[" + dt.Rows[i]["预预计完工日期计进场日期"].ToString().Trim() + "]必须大于等于预计进场日期[" + dt.Rows[i]["预计进场日期"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.预计完工日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",预计完工日期[" + dt.Rows[i]["预计完工日期"].ToString().Trim() + "]必须为日期");
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
                if (dt.Rows[i]["选址定点"] != null && dt.Rows[i]["选址定点"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["选址定点"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",选址定点[" + dt.Rows[i]["选址定点"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.选址定点 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",选址定点[" + dt.Rows[i]["选址定点"].ToString().Trim() + "]必须为日期");
                    }
                }

                if (dt.Rows[i]["设计出图完成日期"] != null && dt.Rows[i]["设计出图完成日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["设计出图完成日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",设计出图完成日期[" + dt.Rows[i]["设计出图完成日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.设计出图完成日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",设计出图完成日期[" + dt.Rows[i]["设计出图完成日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["设计出图完成百分比"] != null && dt.Rows[i]["设计出图完成百分比"].ToString().Trim().Replace("%", "") != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["设计出图完成百分比"].ToString().Trim().Replace("%", ""), out parmDecimal))
                    {
                        model.设计出图完成百分比 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",设计出图完成百分比[" + dt.Rows[i]["设计出图完成百分比"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["设计出图完成设计面积"] != null && dt.Rows[i]["设计出图完成设计面积"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["设计出图完成设计面积"].ToString().Trim(), out parmDecimal))
                    {
                        model.设计出图完成设计面积 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",设计出图完成设计面积[" + dt.Rows[i]["设计出图完成设计面积"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["产品采购开始日期"] != null && dt.Rows[i]["产品采购开始日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["产品采购开始日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",产品采购开始日期[" + dt.Rows[i]["产品采购开始日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.产品采购开始日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",产品采购开始日期[" + dt.Rows[i]["产品采购开始日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["产品采购主材百分比"] != null && dt.Rows[i]["产品采购主材百分比"].ToString().Trim().Replace("%", "") != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["产品采购主材百分比"].ToString().Trim().Replace("%", ""), out parmDecimal))
                    {
                        model.产品采购主材百分比 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",产品采购主材百分比[" + dt.Rows[i]["产品采购主材百分比"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["产品采购辅材百分比"] != null && dt.Rows[i]["产品采购辅材百分比"].ToString().Trim().Replace("%", "") != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["产品采购辅材百分比"].ToString().Trim().Replace("%", ""), out parmDecimal))
                    {
                        model.产品采购辅材百分比 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",产品采购辅材百分比[" + dt.Rows[i]["产品采购辅材百分比"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["产品安装地停百分比"] != null && dt.Rows[i]["产品安装地停百分比"].ToString().Trim().Replace("%", "") != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["产品安装地停百分比"].ToString().Trim().Replace("%", ""), out parmDecimal))
                    {
                        model.产品安装地停百分比 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",产品安装地停百分比[" + dt.Rows[i]["产品安装地停百分比"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["产品安装地停面积"] != null && dt.Rows[i]["产品安装地停面积"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["产品安装地停面积"].ToString().Trim(), out parmDecimal))
                    {
                        model.产品安装地停面积 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",产品安装地停面积[" + dt.Rows[i]["产品安装地停面积"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["产品安装平层百分比"] != null && dt.Rows[i]["产品安装平层百分比"].ToString().Trim().Replace("%", "") != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["产品安装平层百分比"].ToString().Trim().Replace("%", ""), out parmDecimal))
                    {
                        model.产品安装平层百分比 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",产品安装平层百分比[" + dt.Rows[i]["产品安装平层百分比"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["产品安装平层面积"] != null && dt.Rows[i]["产品安装平层面积"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["产品安装平层面积"].ToString().Trim(), out parmDecimal))
                    {
                        model.产品安装平层面积 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",产品安装平层面积[" + dt.Rows[i]["产品安装平层面积"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["产品安装电梯百分比"] != null && dt.Rows[i]["产品安装电梯百分比"].ToString().Trim().Replace("%", "") != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["产品安装电梯百分比"].ToString().Trim().Replace("%", ""), out parmDecimal))
                    {
                        model.产品安装电梯百分比 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",产品安装电梯百分比[" + dt.Rows[i]["产品安装电梯百分比"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["主机安装完成日期"] != null && dt.Rows[i]["主机安装完成日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["主机安装完成日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",主机安装完成日期[" + dt.Rows[i]["主机安装完成日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.主机安装完成日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",主机安装完成日期[" + dt.Rows[i]["主机安装完成日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["光缆到位完成日期"] != null && dt.Rows[i]["光缆到位完成日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["光缆到位完成日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",光缆到位完成日期[" + dt.Rows[i]["光缆到位完成日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.光缆到位完成日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",光缆到位完成日期[" + dt.Rows[i]["光缆到位完成日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["设备开通完成日期"] != null && dt.Rows[i]["设备开通完成日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["设备开通完成日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",设备开通完成日期[" + dt.Rows[i]["设备开通完成日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.设备开通完成日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",设备开通完成日期[" + dt.Rows[i]["设备开通完成日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["销售验收日期"] != null && dt.Rows[i]["销售验收日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["销售验收日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",销售验收日期[" + dt.Rows[i]["销售验收日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else
                        {
                            model.销售验收日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",销售验收日期[" + dt.Rows[i]["销售验收日期"].ToString().Trim() + "]必须为日期");
                    }
                }

                if (dt.Rows[i]["运营商验收交付开始日期"] != null && dt.Rows[i]["运营商验收交付开始日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商验收交付开始日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",运营商验收交付开始日期[" + dt.Rows[i]["运营商验收交付开始日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.销售验收日期 != null && model.销售验收日期 > parmTime)
                        {
                            sbErroI.Append(",运营商验收交付开始日期[" + dt.Rows[i]["运营商验收交付开始日期"].ToString().Trim() + "]必须大于等于销售验收日期[" + dt.Rows[i]["销售验收日期"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.运营商验收交付开始日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",运营商验收交付开始日期[" + dt.Rows[i]["运营商验收交付开始日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商验收交付完成日期"] != null && dt.Rows[i]["运营商验收交付完成日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商验收交付完成日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",运营商验收交付完成日期[" + dt.Rows[i]["运营商验收交付完成日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.运营商验收交付开始日期 != null && model.运营商验收交付开始日期 > parmTime)
                        {
                            sbErroI.Append(",运营商验收交付完成日期[" + dt.Rows[i]["运营商验收交付完成日期"].ToString().Trim() + "]必须大于等于运营商验收交付开始日期[" + dt.Rows[i]["运营商验收交付开始日期"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.运营商验收交付完成日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",运营商验收交付完成日期[" + dt.Rows[i]["运营商验收交付完成日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商签订合同开始日期"] != null && dt.Rows[i]["运营商签订合同开始日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商签订合同开始日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",运营商签订合同开始日期[" + dt.Rows[i]["运营商签订合同开始日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.运营商验收交付完成日期 != null && model.运营商验收交付完成日期 > parmTime)
                        {
                            sbErroI.Append(",运营商签订合同开始日期[" + dt.Rows[i]["运营商签订合同开始日期"].ToString().Trim() + "]必须大于等于运营商验收交付完成日期[" + dt.Rows[i]["运营商验收交付完成日期"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.运营商签订合同开始日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",运营商签订合同开始日期[" + dt.Rows[i]["运营商签订合同开始日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商签订合同完成日期"] != null && dt.Rows[i]["运营商签订合同完成日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商签订合同完成日期"].ToString().Trim(), out parmTime))
                    {
                        if (parmTime > dateTimeNow)
                        {
                            sbErroI.Append(",运营商签订合同完成日期[" + dt.Rows[i]["运营商签订合同完成日期"].ToString().Trim() + "]必须小于等于今天");
                        }
                        else if (model.运营商签订合同开始日期 != null && model.运营商签订合同开始日期 > parmTime)
                        {
                            sbErroI.Append(",运营商签订合同完成日期[" + dt.Rows[i]["运营商签订合同完成日期"].ToString().Trim() + "]必须大于等于运营商签订合同开始日期[" + dt.Rows[i]["运营商签订合同开始日期"].ToString().Trim() + "]");
                        }
                        else
                        {
                            model.运营商签订合同完成日期 = parmTime;
                        }
                    }
                    else
                    {
                        sbErroI.Append(",运营商签订合同完成日期[" + dt.Rows[i]["运营商签订合同完成日期"].ToString().Trim() + "]必须为日期");
                    }
                }

                if (dt.Rows[i]["是否退点"] != null && dt.Rows[i]["是否退点"].ToString().Trim() != "")
                {
                    if (dt.Rows[i]["是否退点"].ToString().Trim() != "是" && dt.Rows[i]["是否退点"].ToString().Trim() != "否")
                    {
                        sbErroI.Append(",是否退点[" + dt.Rows[i]["是否退点"].ToString().Trim() + "]不正确，是否退点必须是是或否");
                    }
                    else
                    {
                        model.是否退点 = dt.Rows[i]["是否退点"].ToString().Trim();
                    }
                }
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
                    List<Model.JD_SF> modelExistsList = BLL.GetModelList(trans, "站点编码='" + list[i].站点编码 + "'  and IsDeleted!=1");
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