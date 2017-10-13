using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace WTCJ
{
    public class CommonHelper
    {
        /// <summary>
        /// 过滤SQL语句,防止注入 true 没有注入
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>true - 没有注入, false - 有注入 </returns>
        public static bool filterSql(string sSql)
        {
            int srcLen, decLen = 0;
            sSql = sSql.ToLower().Trim();
            srcLen = sSql.Length;
            sSql = sSql.Replace("exec ", "");
            sSql = sSql.Replace("delete ", "");
            sSql = sSql.Replace("master ", "");
            sSql = sSql.Replace("truncate ", "");
            sSql = sSql.Replace("declare ", "");
            sSql = sSql.Replace("create ", "");
            sSql = sSql.Replace("or ", "");
            sSql = sSql.Replace("'", "");
            decLen = sSql.Length;
            if (srcLen == decLen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查两个表中的字段是否匹配，
        /// </summary>
        /// <param name="dt">待检查表</param>
        /// <param name="dtTemplate">模板表</param>
        /// <returns></returns>
        public static string Matching(DataTable dt, DataTable dtTemplate)
        {
            //首先检查字段个数是否一致
            if (dt.Columns.Count < dtTemplate.Columns.Count)
            {
                return "导入的模版列数与目标表不同，请下载系统提供的最新导入模版";
            }

            StringBuilder sbErro = new StringBuilder();
            //其次检查字段名称是否一致
            foreach (DataColumn dc in dtTemplate.Columns)
            {
                bool ifHaveField = false;
                foreach (DataColumn dc1 in dt.Columns)
                {
                    if (dc.ColumnName.ToUpper().Trim() == dc1.ColumnName.ToUpper().Trim())
                    {
                        ifHaveField = true;
                        break;
                    }
                }
                //如果没有找到字段那么认为该字段在模板中不存在
                if (!ifHaveField)
                {
                    sbErro.Append(",字段【" + dc.ColumnName + "】同模板不匹配");
                }

            }
            if (sbErro.Length > 0)
            {
                return sbErro.ToString().Substring(1);
            }
            else
            {
                return "";
            }
        }
        public static string getDepartmentId(DataTable dt, string DepartmentName)
        {
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(DepartmentName))
            {
                return "";
            }
            else
            {
                DataRow[] drs = dt.Select("DepartmentName='" + DepartmentName + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["DepartmentID"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        public static string getAreaId(DataTable dt, string AreaName)
        {
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(AreaName))
            {
                return "";
            }
            else
            {
                DataRow[] drs = dt.Select("AreaName='" + AreaName + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["AreaID"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        public static string getCustomerId(DataTable dt, string CustomerName)
        {
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(CustomerName))
            {
                return "";
            }
            else
            {
                DataRow[] drs = dt.Select("CustomerName='" + CustomerName + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["CustomerID"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        public static string getCommonDataValue(DataTable dt, string DataType, object oDataText)
        {
            if (oDataText == null)
            {
                return null;
            }
            string DataText = oDataText.ToString();
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(DataType) || string.IsNullOrEmpty(DataText))
            {
                return "";
            }
            else
            {
                DataRow[] drs = dt.Select("DataType='" + DataType + "' and DataText='" + DataText + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["DataValue"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public static string getDepartmentName(DataTable dt, object oDepartmentId)
        {
            if (oDepartmentId == null)
            {
                return null;
            }
            string DepartmentId = oDepartmentId.ToString();
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(DepartmentId))
            {
                return DepartmentId;
            }
            else
            {
                DataRow[] drs = dt.Select("DepartmentId='" + DepartmentId + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["DepartmentName"].ToString();
                }
                else
                {
                    return DepartmentId;
                }
            }
        }
        public static string getAreaName(DataTable dt, object oAreaID)
        {
            if (oAreaID == null)
            {
                return null;
            }
            string AreaID = oAreaID.ToString();
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(AreaID))
            {
                return AreaID;
            }
            else
            {
                DataRow[] drs = dt.Select("AreaID='" + AreaID + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["AreaName"].ToString();
                }
                else
                {
                    return AreaID;
                }
            }
        }
        public static string getCustomerName(DataTable dt, object oCustomerID)
        {
            if (oCustomerID == null)
            {
                return null;
            }
            string CustomerID = oCustomerID.ToString();
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(CustomerID))
            {
                return CustomerID;
            }
            else
            {
                DataRow[] drs = dt.Select("CustomerID='" + CustomerID + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["CustomerName"].ToString();
                }
                else
                {
                    return CustomerID;
                }
            }
        }
        public static string getCommonDataText(DataTable dt, string DataType, object oDataValue)
        {
            if (oDataValue == null)
            {
                return null;
            }
            string DataValue = oDataValue.ToString();
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(DataType) || string.IsNullOrEmpty(DataValue))
            {
                return DataValue;
            }
            else
            {
                DataRow[] drs = dt.Select("DataType='" + DataType + "' and DataValue='" + DataValue + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["DataText"].ToString();
                }
                else
                {
                    return DataValue;
                }
            }
        }

        public static string getCompanyName(DataTable dt, object oCompanyID)
        {
            if (oCompanyID == null)
            {
                return null;
            }
            string CompanyID = oCompanyID.ToString();
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(CompanyID))
            {
                return CompanyID;
            }
            else
            {
                DataRow[] drs = dt.Select("id='" + CompanyID + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["CompanyName"].ToString();
                }
                else
                {
                    return CompanyID;
                }
            }
        }
        public static string getCompanyId(DataTable dt, string CompanyName)
        {
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(CompanyName))
            {
                return "";
            }
            else
            {
                DataRow[] drs = dt.Select("CompanyName='" + CompanyName + "'");
                if (drs.Length > 0)
                {
                    return drs[0]["id"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public static decimal SumDecimal(params decimal?[] someDecimal)
        {
            decimal returnValue = 0M;
            foreach (decimal? oneDecimal in someDecimal)
            {
                if (oneDecimal.HasValue)
                {
                    returnValue += (decimal)oneDecimal;
                }
                else
                {
                    returnValue += 0;
                }
            }
            return returnValue;
        }

    }
}