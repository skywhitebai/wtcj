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
    public class HealthZjExcel
    {
        BLL.Health_Zj BLL = new WTCJ.BLL.Health_Zj();
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
            List<Model.Health_Zj> list = new List<Model.Health_Zj>();
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
                Model.Health_Zj model = new Model.Health_Zj();
               
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
                if (dt.Rows[i]["运营商验收日期"] != null && dt.Rows[i]["运营商验收日期"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商验收日期"].ToString().Trim(), out parmTime))
                    {
                        model.运营商验收日期 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商验收日期[" + dt.Rows[i]["运营商验收日期"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商合同年限"] != null && dt.Rows[i]["运营商合同年限"].ToString().Trim() != "")
                {

                    if (int.TryParse(dt.Rows[i]["运营商合同年限"].ToString().Trim(), out parmInt))
                    {
                        model.运营商合同年限 = parmInt;
                    }
                    else
                    {
                        sbErroI.Append(",运营商合同年限[" + dt.Rows[i]["运营商合同年限"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商合同含税年租金"] != null && dt.Rows[i]["运营商合同含税年租金"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商合同含税年租金"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商合同含税年租金 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商合同含税年租金[" + dt.Rows[i]["运营商合同含税年租金"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["运营商合同金额"] != null && dt.Rows[i]["运营商合同金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["运营商合同金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.运营商合同金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",运营商合同金额[" + dt.Rows[i]["运营商合同金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["累计应收金额"] != null && dt.Rows[i]["累计应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["累计应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.累计应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",累计应收金额[" + dt.Rows[i]["累计应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["累计回款金额"] != null && dt.Rows[i]["累计回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["累计回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model.累计回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",累计回款金额[" + dt.Rows[i]["累计回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["税率"] != null && dt.Rows[i]["税率"].ToString().Replace("%","").Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["税率"].ToString().Replace("%", "").Trim(), out parmDecimal))
                    {
                        model.税率 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",税率[" + dt.Rows[i]["税率"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["伟通每月收入不含税"] != null && dt.Rows[i]["伟通每月收入不含税"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["伟通每月收入不含税"].ToString().Trim(), out parmDecimal))
                    {
                        model.伟通每月收入不含税 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",伟通每月收入不含税[" + dt.Rows[i]["伟通每月收入不含税"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["运营商合同生效时间"] != null && dt.Rows[i]["运营商合同生效时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商合同生效时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商合同生效时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商合同生效时间[" + dt.Rows[i]["运营商合同生效时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商合同到期时间"] != null && dt.Rows[i]["运营商合同到期时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商合同到期时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商合同到期时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商合同到期时间[" + dt.Rows[i]["运营商合同到期时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商合同签订时间"] != null && dt.Rows[i]["运营商合同签订时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["运营商合同签订时间"].ToString().Trim(), out parmTime))
                    {
                        model.运营商合同签订时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",运营商合同签订时间[" + dt.Rows[i]["运营商合同签订时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["运营商合同签订方"] != null && dt.Rows[i]["运营商合同签订方"].ToString().Trim() != "")
                {
                    model.运营商合同签订方 = dt.Rows[i]["运营商合同签订方"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商合同合同编码"] != null && dt.Rows[i]["运营商合同合同编码"].ToString().Trim() != "")
                {
                    model.运营商合同合同编码 = dt.Rows[i]["运营商合同合同编码"].ToString().Trim();
                }
                if (dt.Rows[i]["项目区域"] != null && dt.Rows[i]["项目区域"].ToString().Trim() != "")
                {
                    model.项目区域 = dt.Rows[i]["项目区域"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商合同合同内容"] != null && dt.Rows[i]["运营商合同合同内容"].ToString().Trim() != "")
                {
                    model.运营商合同合同内容 = dt.Rows[i]["运营商合同合同内容"].ToString().Trim();
                }
                if (dt.Rows[i]["运营商合同付款方式条例"] != null && dt.Rows[i]["运营商合同付款方式条例"].ToString().Trim() != "")
                {
                    model.运营商合同付款方式条例 = dt.Rows[i]["运营商合同付款方式条例"].ToString().Trim();
                }
                

                if (dt.Rows[i]["2016年开票时间"] != null && dt.Rows[i]["2016年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2016年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2016年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2016年开票时间[" + dt.Rows[i]["2016年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2016年开票金额"] != null && dt.Rows[i]["2016年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2016年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2016年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2016年开票金额[" + dt.Rows[i]["2016年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2016年应收时间"] != null && dt.Rows[i]["2016年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2016年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2016年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2016年应收时间[" + dt.Rows[i]["2016年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2016年应收金额"] != null && dt.Rows[i]["2016年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2016年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2016年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2016年应收金额[" + dt.Rows[i]["2016年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2016年运营商合同实际回款时间"] != null && dt.Rows[i]["2016年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2016年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2016年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2016年运营商合同实际回款时间[" + dt.Rows[i]["2016年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2016年运营商合同实际回款金额"] != null && dt.Rows[i]["2016年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2016年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2016年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2016年运营商合同实际回款金额[" + dt.Rows[i]["2016年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2016年应收未收款"] != null && dt.Rows[i]["2016年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2016年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2016年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2016年应收未收款[" + dt.Rows[i]["2016年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }


                if (dt.Rows[i]["2017年开票时间"] != null && dt.Rows[i]["2017年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2017年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2017年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2017年开票时间[" + dt.Rows[i]["2017年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2017年开票金额"] != null && dt.Rows[i]["2017年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2017年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2017年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2017年开票金额[" + dt.Rows[i]["2017年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2017年应收时间"] != null && dt.Rows[i]["2017年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2017年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2017年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2017年应收时间[" + dt.Rows[i]["2017年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2017年应收金额"] != null && dt.Rows[i]["2017年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2017年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2017年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2017年应收金额[" + dt.Rows[i]["2017年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2017年运营商合同实际回款时间"] != null && dt.Rows[i]["2017年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2017年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2017年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2017年运营商合同实际回款时间[" + dt.Rows[i]["2017年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2017年运营商合同实际回款金额"] != null && dt.Rows[i]["2017年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2017年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2017年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2017年运营商合同实际回款金额[" + dt.Rows[i]["2017年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2017年应收未收款"] != null && dt.Rows[i]["2017年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2017年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2017年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2017年应收未收款[" + dt.Rows[i]["2017年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }



                if (dt.Rows[i]["2018年开票时间"] != null && dt.Rows[i]["2018年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2018年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2018年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2018年开票时间[" + dt.Rows[i]["2018年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2018年开票金额"] != null && dt.Rows[i]["2018年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2018年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2018年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2018年开票金额[" + dt.Rows[i]["2018年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2018年应收时间"] != null && dt.Rows[i]["2018年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2018年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2018年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2018年应收时间[" + dt.Rows[i]["2018年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2018年应收金额"] != null && dt.Rows[i]["2018年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2018年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2018年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2018年应收金额[" + dt.Rows[i]["2018年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2018年运营商合同实际回款时间"] != null && dt.Rows[i]["2018年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2018年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2018年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2018年运营商合同实际回款时间[" + dt.Rows[i]["2018年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2018年运营商合同实际回款金额"] != null && dt.Rows[i]["2018年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2018年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2018年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2018年运营商合同实际回款金额[" + dt.Rows[i]["2018年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2018年应收未收款"] != null && dt.Rows[i]["2018年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2018年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2018年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2018年应收未收款[" + dt.Rows[i]["2018年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }


                if (dt.Rows[i]["2019年开票时间"] != null && dt.Rows[i]["2019年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2019年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2019年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2019年开票时间[" + dt.Rows[i]["2019年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2019年开票金额"] != null && dt.Rows[i]["2019年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2019年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2019年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2019年开票金额[" + dt.Rows[i]["2019年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2019年应收时间"] != null && dt.Rows[i]["2019年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2019年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2019年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2019年应收时间[" + dt.Rows[i]["2019年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2019年应收金额"] != null && dt.Rows[i]["2019年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2019年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2019年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2019年应收金额[" + dt.Rows[i]["2019年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2019年运营商合同实际回款时间"] != null && dt.Rows[i]["2019年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2019年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2019年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2019年运营商合同实际回款时间[" + dt.Rows[i]["2019年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2019年运营商合同实际回款金额"] != null && dt.Rows[i]["2019年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2019年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2019年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2019年运营商合同实际回款金额[" + dt.Rows[i]["2019年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2019年应收未收款"] != null && dt.Rows[i]["2019年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2019年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2019年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2019年应收未收款[" + dt.Rows[i]["2019年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2020年开票时间"] != null && dt.Rows[i]["2020年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2020年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2020年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2020年开票时间[" + dt.Rows[i]["2020年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2020年开票金额"] != null && dt.Rows[i]["2020年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2020年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2020年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2020年开票金额[" + dt.Rows[i]["2020年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2020年应收时间"] != null && dt.Rows[i]["2020年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2020年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2020年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2020年应收时间[" + dt.Rows[i]["2020年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2020年应收金额"] != null && dt.Rows[i]["2020年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2020年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2020年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2020年应收金额[" + dt.Rows[i]["2020年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2020年运营商合同实际回款时间"] != null && dt.Rows[i]["2020年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2020年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2020年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2020年运营商合同实际回款时间[" + dt.Rows[i]["2020年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2020年运营商合同实际回款金额"] != null && dt.Rows[i]["2020年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2020年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2020年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2020年运营商合同实际回款金额[" + dt.Rows[i]["2020年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2020年应收未收款"] != null && dt.Rows[i]["2020年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2020年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2020年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2020年应收未收款[" + dt.Rows[i]["2020年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2021年开票时间"] != null && dt.Rows[i]["2021年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2021年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2021年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2021年开票时间[" + dt.Rows[i]["2021年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2021年开票金额"] != null && dt.Rows[i]["2021年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2021年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2021年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2021年开票金额[" + dt.Rows[i]["2021年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2021年应收时间"] != null && dt.Rows[i]["2021年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2021年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2021年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2021年应收时间[" + dt.Rows[i]["2021年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2021年应收金额"] != null && dt.Rows[i]["2021年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2021年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2021年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2021年应收金额[" + dt.Rows[i]["2021年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2021年运营商合同实际回款时间"] != null && dt.Rows[i]["2021年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2021年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2021年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2021年运营商合同实际回款时间[" + dt.Rows[i]["2021年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2021年运营商合同实际回款金额"] != null && dt.Rows[i]["2021年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2021年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2021年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2021年运营商合同实际回款金额[" + dt.Rows[i]["2021年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2021年应收未收款"] != null && dt.Rows[i]["2021年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2021年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2021年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2021年应收未收款[" + dt.Rows[i]["2021年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2022年开票时间"] != null && dt.Rows[i]["2022年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2022年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2022年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2022年开票时间[" + dt.Rows[i]["2022年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2022年开票金额"] != null && dt.Rows[i]["2022年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2022年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2022年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2022年开票金额[" + dt.Rows[i]["2022年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2022年应收时间"] != null && dt.Rows[i]["2022年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2022年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2022年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2022年应收时间[" + dt.Rows[i]["2022年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2022年应收金额"] != null && dt.Rows[i]["2022年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2022年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2022年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2022年应收金额[" + dt.Rows[i]["2022年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2022年运营商合同实际回款时间"] != null && dt.Rows[i]["2022年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2022年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2022年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2022年运营商合同实际回款时间[" + dt.Rows[i]["2022年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2022年运营商合同实际回款金额"] != null && dt.Rows[i]["2022年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2022年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2022年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2022年运营商合同实际回款金额[" + dt.Rows[i]["2022年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2022年应收未收款"] != null && dt.Rows[i]["2022年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2022年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2022年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2022年应收未收款[" + dt.Rows[i]["2022年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2023年开票时间"] != null && dt.Rows[i]["2023年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2023年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2023年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2023年开票时间[" + dt.Rows[i]["2023年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2023年开票金额"] != null && dt.Rows[i]["2023年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2023年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2023年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2023年开票金额[" + dt.Rows[i]["2023年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2023年应收时间"] != null && dt.Rows[i]["2023年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2023年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2023年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2023年应收时间[" + dt.Rows[i]["2023年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2023年应收金额"] != null && dt.Rows[i]["2023年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2023年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2023年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2023年应收金额[" + dt.Rows[i]["2023年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2023年运营商合同实际回款时间"] != null && dt.Rows[i]["2023年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2023年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2023年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2023年运营商合同实际回款时间[" + dt.Rows[i]["2023年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2023年运营商合同实际回款金额"] != null && dt.Rows[i]["2023年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2023年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2023年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2023年运营商合同实际回款金额[" + dt.Rows[i]["2023年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2023年应收未收款"] != null && dt.Rows[i]["2023年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2023年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2023年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2023年应收未收款[" + dt.Rows[i]["2023年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2024年开票时间"] != null && dt.Rows[i]["2024年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2024年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2024年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2024年开票时间[" + dt.Rows[i]["2024年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2024年开票金额"] != null && dt.Rows[i]["2024年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2024年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2024年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2024年开票金额[" + dt.Rows[i]["2024年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2024年应收时间"] != null && dt.Rows[i]["2024年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2024年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2024年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2024年应收时间[" + dt.Rows[i]["2024年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2024年应收金额"] != null && dt.Rows[i]["2024年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2024年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2024年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2024年应收金额[" + dt.Rows[i]["2024年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2024年运营商合同实际回款时间"] != null && dt.Rows[i]["2024年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2024年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2024年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2024年运营商合同实际回款时间[" + dt.Rows[i]["2024年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2024年运营商合同实际回款金额"] != null && dt.Rows[i]["2024年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2024年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2024年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2024年运营商合同实际回款金额[" + dt.Rows[i]["2024年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2024年应收未收款"] != null && dt.Rows[i]["2024年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2024年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2024年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2024年应收未收款[" + dt.Rows[i]["2024年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }


                if (dt.Rows[i]["2025年开票时间"] != null && dt.Rows[i]["2025年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2025年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2025年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2025年开票时间[" + dt.Rows[i]["2025年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2025年开票金额"] != null && dt.Rows[i]["2025年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2025年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2025年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2025年开票金额[" + dt.Rows[i]["2025年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2025年应收时间"] != null && dt.Rows[i]["2025年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2025年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2025年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2025年应收时间[" + dt.Rows[i]["2025年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2025年应收金额"] != null && dt.Rows[i]["2025年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2025年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2025年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2025年应收金额[" + dt.Rows[i]["2025年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2025年运营商合同实际回款时间"] != null && dt.Rows[i]["2025年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2025年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2025年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2025年运营商合同实际回款时间[" + dt.Rows[i]["2025年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2025年运营商合同实际回款金额"] != null && dt.Rows[i]["2025年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2025年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2025年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2025年运营商合同实际回款金额[" + dt.Rows[i]["2025年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2025年应收未收款"] != null && dt.Rows[i]["2025年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2025年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2025年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2025年应收未收款[" + dt.Rows[i]["2025年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }



                if (dt.Rows[i]["2026年开票时间"] != null && dt.Rows[i]["2026年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2026年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2026年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2026年开票时间[" + dt.Rows[i]["2026年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2026年开票金额"] != null && dt.Rows[i]["2026年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2026年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2026年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2026年开票金额[" + dt.Rows[i]["2026年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2026年应收时间"] != null && dt.Rows[i]["2026年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2026年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2026年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2026年应收时间[" + dt.Rows[i]["2026年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2026年应收金额"] != null && dt.Rows[i]["2026年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2026年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2026年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2026年应收金额[" + dt.Rows[i]["2026年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2026年运营商合同实际回款时间"] != null && dt.Rows[i]["2026年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2026年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2026年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2026年运营商合同实际回款时间[" + dt.Rows[i]["2026年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2026年运营商合同实际回款金额"] != null && dt.Rows[i]["2026年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2026年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2026年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2026年运营商合同实际回款金额[" + dt.Rows[i]["2026年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2026年应收未收款"] != null && dt.Rows[i]["2026年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2026年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2026年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2026年应收未收款[" + dt.Rows[i]["2026年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }


                if (dt.Rows[i]["2027年开票时间"] != null && dt.Rows[i]["2027年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2027年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2027年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2027年开票时间[" + dt.Rows[i]["2027年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2027年开票金额"] != null && dt.Rows[i]["2027年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2027年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2027年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2027年开票金额[" + dt.Rows[i]["2027年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2027年应收时间"] != null && dt.Rows[i]["2027年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2027年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2027年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2027年应收时间[" + dt.Rows[i]["2027年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2027年应收金额"] != null && dt.Rows[i]["2027年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2027年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2027年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2027年应收金额[" + dt.Rows[i]["2027年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2027年运营商合同实际回款时间"] != null && dt.Rows[i]["2027年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2027年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2027年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2027年运营商合同实际回款时间[" + dt.Rows[i]["2027年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2027年运营商合同实际回款金额"] != null && dt.Rows[i]["2027年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2027年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2027年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2027年运营商合同实际回款金额[" + dt.Rows[i]["2027年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2027年应收未收款"] != null && dt.Rows[i]["2027年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2027年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2027年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2027年应收未收款[" + dt.Rows[i]["2027年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2028年开票时间"] != null && dt.Rows[i]["2028年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2028年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2028年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2028年开票时间[" + dt.Rows[i]["2028年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2028年开票金额"] != null && dt.Rows[i]["2028年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2028年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2028年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2028年开票金额[" + dt.Rows[i]["2028年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2028年应收时间"] != null && dt.Rows[i]["2028年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2028年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2028年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2028年应收时间[" + dt.Rows[i]["2028年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2028年应收金额"] != null && dt.Rows[i]["2028年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2028年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2028年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2028年应收金额[" + dt.Rows[i]["2028年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2028年运营商合同实际回款时间"] != null && dt.Rows[i]["2028年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2028年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2028年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2028年运营商合同实际回款时间[" + dt.Rows[i]["2028年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2028年运营商合同实际回款金额"] != null && dt.Rows[i]["2028年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2028年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2028年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2028年运营商合同实际回款金额[" + dt.Rows[i]["2028年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2028年应收未收款"] != null && dt.Rows[i]["2028年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2028年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2028年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2028年应收未收款[" + dt.Rows[i]["2028年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2029年开票时间"] != null && dt.Rows[i]["2029年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2029年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2029年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2029年开票时间[" + dt.Rows[i]["2029年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2029年开票金额"] != null && dt.Rows[i]["2029年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2029年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2029年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2029年开票金额[" + dt.Rows[i]["2029年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2029年应收时间"] != null && dt.Rows[i]["2029年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2029年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2029年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2029年应收时间[" + dt.Rows[i]["2029年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2029年应收金额"] != null && dt.Rows[i]["2029年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2029年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2029年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2029年应收金额[" + dt.Rows[i]["2029年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2029年运营商合同实际回款时间"] != null && dt.Rows[i]["2029年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2029年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2029年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2029年运营商合同实际回款时间[" + dt.Rows[i]["2029年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2029年运营商合同实际回款金额"] != null && dt.Rows[i]["2029年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2029年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2029年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2029年运营商合同实际回款金额[" + dt.Rows[i]["2029年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2029年应收未收款"] != null && dt.Rows[i]["2029年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2029年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2029年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2029年应收未收款[" + dt.Rows[i]["2029年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2030年开票时间"] != null && dt.Rows[i]["2030年开票时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2030年开票时间"].ToString().Trim(), out parmTime))
                    {
                        model._2030年开票时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2030年开票时间[" + dt.Rows[i]["2030年开票时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2030年开票金额"] != null && dt.Rows[i]["2030年开票金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2030年开票金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2030年开票金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2030年开票金额[" + dt.Rows[i]["2030年开票金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2030年应收时间"] != null && dt.Rows[i]["2030年应收时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2030年应收时间"].ToString().Trim(), out parmTime))
                    {
                        model._2030年应收时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2030年应收时间[" + dt.Rows[i]["2030年应收时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2030年应收金额"] != null && dt.Rows[i]["2030年应收金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2030年应收金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2030年应收金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2030年应收金额[" + dt.Rows[i]["2030年应收金额"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["2030年运营商合同实际回款时间"] != null && dt.Rows[i]["2030年运营商合同实际回款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["2030年运营商合同实际回款时间"].ToString().Trim(), out parmTime))
                    {
                        model._2030年运营商合同实际回款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",2030年运营商合同实际回款时间[" + dt.Rows[i]["2030年运营商合同实际回款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["2030年运营商合同实际回款金额"] != null && dt.Rows[i]["2030年运营商合同实际回款金额"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2030年运营商合同实际回款金额"].ToString().Trim(), out parmDecimal))
                    {
                        model._2030年运营商合同实际回款金额 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2030年运营商合同实际回款金额[" + dt.Rows[i]["2030年运营商合同实际回款金额"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["2030年应收未收款"] != null && dt.Rows[i]["2030年应收未收款"].ToString().Trim() != "")
                {

                    if (decimal.TryParse(dt.Rows[i]["2030年应收未收款"].ToString().Trim(), out parmDecimal))
                    {
                        model._2030年应收未收款 = parmDecimal;
                    }
                    else
                    {
                        sbErroI.Append(",2030年应收未收款[" + dt.Rows[i]["2030年应收未收款"].ToString().Trim() + "]必须为数字");
                    }
                }

                if (dt.Rows[i]["推迟收款时间"] != null && dt.Rows[i]["推迟收款时间"].ToString().Trim() != "")
                {

                    if (DateTime.TryParse(dt.Rows[i]["推迟收款时间"].ToString().Trim(), out parmTime))
                    {
                        model.推迟收款时间 = parmTime;
                    }
                    else
                    {
                        sbErroI.Append(",推迟收款时间[" + dt.Rows[i]["推迟收款时间"].ToString().Trim() + "]必须为日期");
                    }
                }
                if (dt.Rows[i]["备注"] != null && dt.Rows[i]["备注"].ToString().Trim() != "")
                {
                        model.备注 = dt.Rows[i]["备注"].ToString().Trim();
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
                    List<Model.Health_Zj> modelExistsList = BLL.GetModelList(trans, "站点编码='" + list[i].站点编码 + "'  and IsDeleted!=1");
                    if (modelExistsList != null && modelExistsList.Count > 0)
                    {
                        list[i].id = modelExistsList[0].id;
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