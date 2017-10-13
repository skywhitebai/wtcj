using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WTCJ.DBUtility;

namespace WTCJ.Excel
{
    public class CustomerExcel
    {
        BLL.Customer BLL = new WTCJ.BLL.Customer();
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
            List<Model.Customer> list = new List<Model.Customer>();
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
                Model.Customer model = new Model.Customer();
                if (dt.Rows[i]["客户名称"] != null && dt.Rows[i]["客户名称"].ToString().Trim() != "")
                {
                    model.CustomerName = dt.Rows[i]["客户名称"].ToString().Trim();
                }
                else
                {
                    sbErroI.Append(",客户名称不能为空");
                }
                if (dt.Rows[i]["联系人"] != null && dt.Rows[i]["联系人"].ToString().Trim() != "")
                {
                    model.Linkman = dt.Rows[i]["联系人"].ToString().Trim();
                }
                if (dt.Rows[i]["联系人电话"] != null && dt.Rows[i]["联系人电话"].ToString().Trim() != "")
                {
                    model.Telephone = dt.Rows[i]["联系人电话"].ToString().Trim();
                }
                if (dt.Rows[i]["排序"] != null && dt.Rows[i]["排序"].ToString().Trim() != "")
                {

                    if (int.TryParse(dt.Rows[i]["排序"].ToString().Trim(), out parmInt))
                    {
                        model.OrderBy = parmInt;
                    }
                    else
                    {
                        sbErroI.Append(",排序[" + dt.Rows[i]["排序"].ToString().Trim() + "]必须为数字");
                    }
                }
                if (dt.Rows[i]["备注"] != null && dt.Rows[i]["备注"].ToString().Trim() != "")
                {
                    model.Remark = dt.Rows[i]["备注"].ToString().Trim();
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
            try
            {
                int addCount = 0;
                int updateCount = 0;
                string userId = CurrentUser.User.Userinfo.UserID;
                DateTime timeNow = DateTime.Now;
                for (int i = 0; i < list.Count; i++)
                {
                    List<Model.Customer> modelExistsList = BLL.GetModelList("CustomerName='" + list[i].CustomerName + "' ");
                    if (modelExistsList != null && modelExistsList.Count > 0)
                    {
                        list[i].CustomerID = modelExistsList[0].CustomerID;
                        list[i].CustomerName = modelExistsList[0].CustomerName;
                        list[i].CreateBy = modelExistsList[0].CreateBy;
                        list[i].CreateTime = modelExistsList[0].CreateTime;
                        list[i].UpdateBy = userId;
                        list[i].UpdateTime = timeNow;
                        BLL.Update(list[i]);
                        updateCount++;
                    }
                    else
                    {
                        list[i].CreateBy = userId;
                        list[i].CreateTime = timeNow;
                        list[i].CustomerID = Guid.NewGuid().ToString();
                        BLL.Add(list[i]);
                        addCount++;
                    }
                }
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
                json.Status = JsonObject.STATUS_FAIL;
                json.ErroMessage = "导入失败，失败原因：" + ex.Message;
                return json;
            }
            finally
            {
            }

        }

    }
}