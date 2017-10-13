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
    public class ContractMoneyExcel
    {
        BLL.Contract_Money BLL = new WTCJ.BLL.Contract_Money();
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
            List<Model.Contract_Money> list = new List<Model.Contract_Money>();
            DataTable dtArea = new BLL.Area().GetAllList().Tables[0];
            DataTable dtCustomer = new BLL.Customer().GetAllList().Tables[0];

            DateTime parmTime = DateTime.Now;
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
                Model.Contract_Money model = new Model.Contract_Money();
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
                if (dt.Rows[i]["销售合同第一年回款日期"] != null && dt.Rows[i]["销售合同第一年回款日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["销售合同第一年回款日期"].ToString().Trim(), out parmTime))
                    {
                        model.销售合同第一年回款日期 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",销售合同第一年回款日期[" + dt.Rows[i]["销售合同第一年回款日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["合同签订时间建设合同"] != null && dt.Rows[i]["合同签订时间建设合同"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["合同签订时间建设合同"].ToString().Trim(), out parmTime))
                    {
                        model.合同签订时间建设合同 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",合同签订时间建设合同[" + dt.Rows[i]["合同签订时间建设合同"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["合同签订时间买卖合同"] != null && dt.Rows[i]["合同签订时间买卖合同"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["合同签订时间买卖合同"].ToString().Trim(), out parmTime))
                    {
                        model.合同签订时间买卖合同 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",合同签订时间买卖合同[" + dt.Rows[i]["合同签订时间买卖合同"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["合同签订时间维护合同"] != null && dt.Rows[i]["合同签订时间维护合同"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["合同签订时间维护合同"].ToString().Trim(), out parmTime))
                    {
                        model.合同签订时间维护合同 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",合同签订时间维护合同[" + dt.Rows[i]["合同签订时间维护合同"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商收入信息年限"] != null && dt.Rows[i]["运营商收入信息年限"].ToString().Trim() != "")
                {

                    if (int.TryParse(dt.Rows[i]["运营商收入信息年限"].ToString().Trim(), out parmInt))
                    {
                        model.运营商收入信息年限 = parmInt;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息年限[" + dt.Rows[i]["运营商收入信息年限"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入信息含税租金"] != null && dt.Rows[i]["运营商收入信息含税租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商收入信息含税租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商收入信息含税租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息含税租金[" + dt.Rows[i]["运营商收入信息含税租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入信息合同金额"] != null && dt.Rows[i]["运营商收入信息合同金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商收入信息合同金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商收入信息合同金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息合同金额[" + dt.Rows[i]["运营商收入信息合同金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入信息不含税租金"] != null && dt.Rows[i]["运营商收入信息不含税租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商收入信息不含税租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商收入信息不含税租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息不含税租金[" + dt.Rows[i]["运营商收入信息不含税租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入信息不含税总额"] != null && dt.Rows[i]["运营商收入信息不含税总额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商收入信息不含税总额"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商收入信息不含税总额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息不含税总额[" + dt.Rows[i]["运营商收入信息不含税总额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入信息税率"] != null && dt.Rows[i]["运营商收入信息税率"].ToString().Replace("%", "").Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商收入信息税率"].ToString().Replace("%", "").Trim(), out parmDecimal))
                    {
                        model.运营商收入信息税率 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息税率[" + dt.Rows[i]["运营商收入信息税率"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入信息税额"] != null && dt.Rows[i]["运营商收入信息税额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商收入信息税额"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商收入信息税额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息税额[" + dt.Rows[i]["运营商收入信息税额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入信息生效时间"] != null && dt.Rows[i]["运营商收入信息生效时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商收入信息生效时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商收入信息生效时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息生效时间[" + dt.Rows[i]["运营商收入信息生效时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商收入信息到期时间"] != null && dt.Rows[i]["运营商收入信息到期时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商收入信息到期时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商收入信息到期时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息到期时间[" + dt.Rows[i]["运营商收入信息到期时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商收入信息签订时间"] != null && dt.Rows[i]["运营商收入信息签订时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商收入信息签订时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商收入信息签订时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入信息签订时间[" + dt.Rows[i]["运营商收入信息签订时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商收入信息签订方"] != null && dt.Rows[i]["运营商收入信息签订方"].ToString().Trim() != "")
                {
                    model.运营商收入信息签订方 = dt.Rows[i]["运营商收入信息签订方"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商收入信息合同编码"] != null && dt.Rows[i]["运营商收入信息合同编码"].ToString().Trim() != "")
                {
                    model.运营商收入信息合同编码 = dt.Rows[i]["运营商收入信息合同编码"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商收入信息项目区域"] != null && dt.Rows[i]["运营商收入信息项目区域"].ToString().Trim() != "")
                {
                    model.运营商收入信息项目区域 = dt.Rows[i]["运营商收入信息项目区域"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商收入信息合同内容"] != null && dt.Rows[i]["运营商收入信息合同内容"].ToString().Trim() != "")
                {
                    model.运营商收入信息合同内容 = dt.Rows[i]["运营商收入信息合同内容"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商收入信息合同付款方式条例"] != null && dt.Rows[i]["运营商收入信息合同付款方式条例"].ToString().Trim() != "")
                {
                    model.运营商收入信息合同付款方式条例 = dt.Rows[i]["运营商收入信息合同付款方式条例"].ToString().Trim();
                }
                if (dt.Rows[i]["预估运营商收入"] != null && dt.Rows[i]["预估运营商收入"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["预估运营商收入"].ToString().Trim(), out parmDecimal))
                    {
                        model.预估运营商收入 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",预估运营商收入[" + dt.Rows[i]["预估运营商收入"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商收入差额"] != null && dt.Rows[i]["运营商收入差额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商收入差额"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商收入差额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商收入差额[" + dt.Rows[i]["运营商收入差额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通预估收入"] != null && dt.Rows[i]["伟通预估收入"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通预估收入"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通预估收入 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通预估收入[" + dt.Rows[i]["伟通预估收入"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通第一年应收销售款"] != null && dt.Rows[i]["伟通第一年应收销售款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通第一年应收销售款"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通第一年应收销售款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通第一年应收销售款[" + dt.Rows[i]["伟通第一年应收销售款"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["差额对比收入"] != null && dt.Rows[i]["差额对比收入"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["差额对比收入"].ToString().Trim(), out parmDecimal))
                    {
                        model.差额对比收入 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",差额对比收入[" + dt.Rows[i]["差额对比收入"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["差额对比成本"] != null && dt.Rows[i]["差额对比成本"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["差额对比成本"].ToString().Trim(), out parmDecimal))
                    {
                        model.差额对比成本 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",差额对比成本[" + dt.Rows[i]["差额对比成本"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商开票及回款开票时间"] != null && dt.Rows[i]["运营商开票及回款开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商开票及回款开票时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商开票及回款开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商开票及回款开票时间[" + dt.Rows[i]["运营商开票及回款开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商开票及回款开票金额"] != null && dt.Rows[i]["运营商开票及回款开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商开票及回款开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商开票及回款开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商开票及回款开票金额[" + dt.Rows[i]["运营商开票及回款开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商开票及回款回款时间"] != null && dt.Rows[i]["运营商开票及回款回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商开票及回款回款时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商开票及回款回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商开票及回款回款时间[" + dt.Rows[i]["运营商开票及回款回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商开票及回款回款金额"] != null && dt.Rows[i]["运营商开票及回款回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商开票及回款回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商开票及回款回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商开票及回款回款金额[" + dt.Rows[i]["运营商开票及回款回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通开票及回款开票时间"] != null && dt.Rows[i]["伟通开票及回款开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["伟通开票及回款开票时间"].ToString().Trim(), out parmTime))
                    {
                        model.伟通开票及回款开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",伟通开票及回款开票时间[" + dt.Rows[i]["伟通开票及回款开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["伟通开票及回款开票金额"] != null && dt.Rows[i]["伟通开票及回款开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通开票及回款开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通开票及回款开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通开票及回款开票金额[" + dt.Rows[i]["伟通开票及回款开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通开票及回款回款时间"] != null && dt.Rows[i]["伟通开票及回款回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["伟通开票及回款回款时间"].ToString().Trim(), out parmTime))
                    {
                        model.伟通开票及回款回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",伟通开票及回款回款时间[" + dt.Rows[i]["伟通开票及回款回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["伟通开票及回款已回款金额"] != null && dt.Rows[i]["伟通开票及回款已回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通开票及回款已回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通开票及回款已回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通开票及回款已回款金额[" + dt.Rows[i]["伟通开票及回款已回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通开票及回款未回款金额"] != null && dt.Rows[i]["伟通开票及回款未回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通开票及回款未回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通开票及回款未回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通开票及回款未回款金额[" + dt.Rows[i]["伟通开票及回款未回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商合同收款账号"] != null && dt.Rows[i]["运营商合同收款账号"].ToString().Trim() != "")
                {
                    model.运营商合同收款账号 = dt.Rows[i]["运营商合同收款账号"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商合同收款账号账号开户行"] != null && dt.Rows[i]["运营商合同收款账号账号开户行"].ToString().Trim() != "")
                {
                    model.运营商合同收款账号账号开户行 = dt.Rows[i]["运营商合同收款账号账号开户行"].ToString().Trim();
                }
                if (dt.Rows[i]["销售共管账号"] != null && dt.Rows[i]["销售共管账号"].ToString().Trim() != "")
                {
                    model.销售共管账号 = dt.Rows[i]["销售共管账号"].ToString().Trim();
                }
                if (dt.Rows[i]["销售共管账号账号开户行"] != null && dt.Rows[i]["销售共管账号账号开户行"].ToString().Trim() != "")
                {
                    model.销售共管账号账号开户行 = dt.Rows[i]["销售共管账号账号开户行"].ToString().Trim();
                }
                if (dt.Rows[i]["建设验收单签订时间"] != null && dt.Rows[i]["建设验收单签订时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["建设验收单签订时间"].ToString().Trim(), out parmTime))
                    {
                        model.建设验收单签订时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",建设验收单签订时间[" + dt.Rows[i]["建设验收单签订时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["销售验收单签订时间"] != null && dt.Rows[i]["销售验收单签订时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["销售验收单签订时间"].ToString().Trim(), out parmTime))
                    {
                        model.销售验收单签订时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",销售验收单签订时间[" + dt.Rows[i]["销售验收单签订时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商验收交付单确认时间"] != null && dt.Rows[i]["运营商验收交付单确认时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商验收交付单确认时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商验收交付单确认时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商验收交付单确认时间[" + dt.Rows[i]["运营商验收交付单确认时间"].ToString().Trim() + "]必须为日期");
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
                    List<Model.Contract_Money> modelExistsList = BLL.GetModelList(trans, "站点编码='" + list[i].站点编码 + "' and IsDeleted!=1");
                    if (modelExistsList != null && modelExistsList.Count > 0)
                    {
                        list[i].id = modelExistsList[0].id;
                        list[i].备注 = modelExistsList[0].备注;
                        list[i].IsDeleted = modelExistsList[0].IsDeleted;
                        list[i].CreateBy = modelExistsList[0].CreateBy;
                        list[i].CreateTime = modelExistsList[0].CreateTime;
                        list[i].UpdateBy = userId;
                        list[i].UpdateTime = timeNow;
                        BLL.Update(trans,list[i]);
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