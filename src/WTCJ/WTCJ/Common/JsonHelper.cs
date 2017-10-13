using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;

namespace WTCJ
{
    public class JsonHelper
    { /// <summary>
        /// 生成Combobox JSON格式
        /// </summary>
        /// <param name="dt">数据源DataTable</param>
        /// <param name="type">0  用于列表查询下拉框 默认是全部， 1 是请选择 ，2 没有 请选择货全部 选项</param>
        /// 区分是新增时候用还是查询的时候用，查询是不用管默认选项
        /// <returns>Combobox的json格式  [{ "id":1,"text":"text1"}] </returns>
        public static string CreateComboboxJson(DataTable dt, int type)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder str = new StringBuilder();
                str.Append("[");
                if (type != 2)
                {
                    str.Append("{ ");
                    str.Append("\"id\": ");
                    str.Append(-1 + ",");
                    str.Append("\"text\": ");
                    if (type == 1 || type == 3)
                    {
                        str.Append("\"请选择\"");
                    }
                    else
                    {
                        str.Append("\"全部\"");
                    }
                    DataRow[] row = dt.Select("IsDefault=1");
                    if ((type == 0 || row.Length == 0) && type != 3)
                    {
                        str.Append(",\"selected\": ");
                        str.Append("true");
                    }
                    str.Append("},");
                }
                JsonString.Append(str.ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i < dt.Rows.Count - 1)
                    {
                        JsonString.Append("{ ");
                        JsonString.Append("\"id\": ");
                        JsonString.Append(dt.Rows[i]["ID"] + ",");
                        JsonString.Append("\"text\": ");
                        JsonString.Append("\"" + JsonCharFilter(dt.Rows[i]["name"].ToString()) + "\"");
                        if (dt.Rows[i]["IsDefault"].ToString() == "1" && type == 1)
                        {
                            JsonString.Append(",\"selected\": ");
                            JsonString.Append("true");
                        }
                        JsonString.Append("},");
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("{ ");
                        JsonString.Append("\"id\": ");
                        JsonString.Append(dt.Rows[i]["ID"] + ",");
                        JsonString.Append("\"text\": ");
                        JsonString.Append("\"" + JsonCharFilter(dt.Rows[i]["name"].ToString()) + "\"");
                        if (dt.Rows[i]["IsDefault"].ToString() == "1" && type == 1)
                        {
                            JsonString.Append(",\"selected\": ");
                            JsonString.Append("true");
                        }
                        JsonString.Append("}");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
                JsonString.Append("[");
            JsonString.Append("{ ");
            JsonString.Append("\"id\": ");
            JsonString.Append(-1 + ",");
            JsonString.Append("\"text\": ");
            JsonString.Append("\"请选择\"");
            JsonString.Append("}");
            JsonString.Append("]");
            return JsonString.ToString();
        }
        public static string CreateComboboxJson(DataTable dt,string idColumn,string textColumn)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i < dt.Rows.Count - 1)
                    {
                        JsonString.Append("{ ");
                        JsonString.Append("\"id\": \"");
                        JsonString.Append(dt.Rows[i][idColumn] + "\",");
                        JsonString.Append("\"text\": ");
                        JsonString.Append("\"" + JsonCharFilter(dt.Rows[i][textColumn].ToString()) + "\"");
                        JsonString.Append("},");
                    }
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("{ ");
                        JsonString.Append("\"id\": \"");
                        JsonString.Append(dt.Rows[i][idColumn] + "\",");
                        JsonString.Append("\"text\": ");
                        JsonString.Append("\"" + JsonCharFilter(dt.Rows[i][textColumn].ToString()) + "\"");
                        JsonString.Append("}");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                JsonString.Append("[]");
                return JsonString.ToString();
            }
        }
        /// <summary>    /// 根据DataTable生成Json树结构
        /// </summary>    /// <param name="tabel">数据源</param>
        /// <param name="ID">ID列</param>
        /// <param name="Name">Text列</param>
        /// <param name="Fatherid">关系字段</param>
        /// <param name="pId">父ID</param>
        /// GetTreeJsonByTable(datatable, "id", "title", "pid", "0")
        static StringBuilder result = new StringBuilder();
        static StringBuilder sb = new StringBuilder();
        /// <summary>
        ///
        /// </summary>
        /// <param name="tabel">dt</param>
        /// <param name="idCol">ID</param>
        /// <param name="txtCol">Name</param>
        /// <param name="rela">Fatherid</param>
        /// <param name="pId">0</param>
        /// <returns></returns>
        public static string GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId, int type)
        {
            if (tabel != null || tabel.Rows.Count > 0)
            {
                sb.Append("[");
                if (pId.ToString() == "0" && type == 1)
                {
                    sb.Append("{\"id\":\"0\",\"text\":\"根目录\",\"state\":\"open\"");
                    sb.Append("},");
                }
                string filer = string.Format("{0}='{1}'", rela, pId);
                DataRow[] rows = tabel.Select(filer);
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        sb.Append("{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol] + "\",\"state\":\"open\"");
                        if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                        {
                            sb.Append(",\"children\":");
                            GetTreeJsonByTable(tabel, idCol, txtCol, rela, row[idCol], type);
                            result.Append(sb.ToString());
                        }
                        result.Append(sb.ToString());
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                } sb.Append("]"); result.Append(sb.ToString());
            }
            return sb.ToString();
        }
        public static string GetJsonTreeByTable(DataTable dt, string where)
        {
            StringBuilder sbd = new StringBuilder();
            if (dt!=null&&dt.Rows.Count > 0)
            {
                DataRow[] row = dt.Select(where);
                sbd.Append("[");
                for (int i = 0; i < row.Length; i++)
                {
                    sbd.Append("{ ");
                    string url = row[i]["URL"].ToString();
                    int id = Convert.ToInt32(row[i]["id"].ToString());
                    if (!string.IsNullOrEmpty(url) && url.IndexOf('?') != -1)
                    {
                        url += "&pagesid=" + id + "&NowDateTimeSign=" + Guid.NewGuid();
                    }
                    else if (!string.IsNullOrEmpty(url) && url.IndexOf('?') == -1)
                    {
                        url += "?&pagesid=" + id + "&NowDateTimeSign=" + Guid.NewGuid();
                    }
                    sbd.Append("\"attributes\": {");
                    sbd.Append("\"url\": \"" + url + "\",");
                    sbd.Append("\"isreloadid\":\"" + row[i]["isreloadid"].ToString() + "\"");
                    sbd.Append("},");
                    sbd.Append("\"checked\": false, ");
                    sbd.Append("\"iconCls\": \"ext-icon-medal_gold_3\" ,");
                    if (row[i]["fatherid"].ToString() == "0")
                    {
                        sbd.Append("\"id\": \"" + row[i]["ID"].ToString() + "\" ,");
                    }
                    else
                    {
                        sbd.Append("\"id\": \"" + row[i]["ID"].ToString() + "\" ,");
                        sbd.Append("\"pid\": \"" + row[i]["fatherid"].ToString() + "\" ,");
                    }
                    sbd.Append("\"state\": \"open\", ");
                    sbd.Append("\"text\": \"" + row[i]["Name"].ToString().Replace("\"", "\\\"") + "\" ");
                    if (i == row.Length - 1)
                    {
                        sbd.Append("}");
                    }
                    else
                    {
                        sbd.Append("},");
                    }
                }
                sbd.Append("]");
            }
            else
            {
                sbd.Append("[]");
            }
            return sbd.ToString();
        }



        /// <summary>
        /// 根据子节点ID查询父节点名称
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fatherid"></param>
        /// <returns></returns>
        public static string GetFatherNameByFatherID(DataTable dt, string fatherid)
        {
            DataRow[] row = dt.Select("id=" + fatherid + "");
            if (row.Length > 0)
            {
                return row[0]["name"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 加载treeview
        /// </summary>
        /// <returns></returns>
        public static string GetTreeList(DataTable dt)
        {
            DataRow[] row = dt.Select(" fatherid=0");
            StringBuilder sbd = new StringBuilder();
            sbd.Append("{\"total\":" + dt.Rows.Count + ",\"rows\":");
            sbd.Append("[ ");
            if (row.Length > 0)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    sbd.Append("{ ");
                    int fatherid = Convert.ToInt32(row[i]["fatherid"].ToString());
                    int pagetypeid = Convert.ToInt32(row[i]["pagetypeid"].ToString());
                    int isreloadid = Convert.ToInt32(row[i]["isreloadid"].ToString());
                    sbd.Append("\"id\": \"" + row[i]["ID"].ToString() + "\" ,");
                    sbd.Append("\"name\": \"" + row[i]["Name"].ToString().Replace("\"", "\\\"") + "\", ");
                    sbd.Append("\"seq\": \"" + row[i]["Sequence"].ToString() + "\", ");
                    sbd.Append("\"url\": \"" + row[i]["url"].ToString().Replace("\"", "\\\"") + "\" ,");
                    sbd.Append("\"buttonid\": \"" + row[i]["buttonid"].ToString() + "\" ,");
                    sbd.Append("\"fatherid\": \"" + fatherid + "\" ,");
                    sbd.Append("\"iconCls\": \"icon-ok\" ,");
                    sbd.Append("\"pagetypename\": \"" + row[i]["pagetypename"].ToString().Replace("\"", "\\\"") + "\" ,");
                    sbd.Append("\"pagetypeid\": \"" + pagetypeid + "\" ,");
                    if (isreloadid == 1)
                    {
                        sbd.Append("\"isreloadid\": \"否\" ,");
                    }
                    else
                    {
                        sbd.Append("\"isreloadid\": \"是\" ,");
                    }
                    sbd.Append("\"state\": \"closed\" ");
                    sbd.Append("},");
                    sbd.Append(SetMenu(row[i]["ID"].ToString(), dt));
                }
            }
            sbd.Remove(sbd.Length - 1, 1);
            sbd.Append("]}");
            return sbd.ToString();
        }
        public static string SetMenu(string parentid, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            DataRow[] row = dt.Select(" fatherid=" + parentid + "");
            if (row.Length > 0)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    sb.Append("{ ");
                    int pagetypeid = Convert.ToInt32(row[i]["pagetypeid"].ToString());
                    int isreloadid = Convert.ToInt32(row[i]["isreloadid"].ToString());
                    sb.Append("\"id\": \"" + row[i]["ID"].ToString() + "\" ,");
                    sb.Append("\"name\": \"" + row[i]["Name"].ToString().Replace("\"", "\\\"") + "\", ");
                    sb.Append("\"seq\": \"" + row[i]["Sequence"].ToString() + "\", ");
                    sb.Append("\"url\": \"" + row[i]["url"].ToString().Replace("\"", "\\\"") + "\", ");
                    sb.Append("\"buttonid\": \"" + row[i]["buttonid"].ToString().Replace("\"", "\\\"") + "\" ,");
                    sb.Append(String.Format("\"_parentId\": \"{0}\" ,", parentid));
                    sb.Append("\"fatherid\": \"" + parentid + "\" ,");
                    //sb.Append("\"fathername\": \"" + GetFatherNameByFatherID(dt, parentid) + "\" ,");
                    sb.Append("\"pagetypename\": \"" + row[i]["pagetypename"].ToString().Replace("\"", "\\\"") + "\" ,");
                    sb.Append("\"pagetypeid\": \"" + pagetypeid + "\" ,");
                    if (isreloadid == 1)
                    {
                        sb.Append("\"isreloadid\": \"否\" ,");
                    }
                    else
                    {
                        sb.Append("\"isreloadid\": \"是\" ,");
                    }
                    sb.Append("\"state\": \"closed\" ");
                    sb.Append("},");
                    sb.Append(SetMenu(row[i]["ID"].ToString(), dt));
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 将DataTable转换为JSON字符串
        /// </summary>
        /// <param name="dt">数据表</param>
        ///   /// <param name="total">总记录数</param>
        /// <returns>JSON字符串</returns>
        public static string GetJsonFromDataTable(DataTable dt, int total)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt==null||dt.Rows.Count == 0)
            {
                JsonString.Append("{ ");
                JsonString.Append("\"rows\":[");
                JsonString.Append("]");
                JsonString.Append(",");
                JsonString.Append("\"total\":");
                JsonString.Append(total);
                JsonString.Append("}");
                return JsonString.ToString().Replace("\n", "");
            }
            JsonString.Append("{ ");
            JsonString.Append("\"rows\":[ ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JsonString.Append("{ ");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + JsonCharFilter(dt.Rows[i][j].ToString()) + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + JsonCharFilter(dt.Rows[i][j].ToString()) + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    JsonString.Append("} ");
                }
                else
                {
                    JsonString.Append("}, ");
                }
            }
            JsonString.Append("]");
            JsonString.Append(",");
            JsonString.Append("\"total\":");
            JsonString.Append(total);
            JsonString.Append("}");
            return JsonString.ToString().Replace("\n", "").Replace(" 0:00:00","");
        }
        /// <summary>
        /// 将DataTable转换为JSON字符串
        /// </summary>
        /// <param name="dt">数据表</param>
        ///   /// <param name="total">总记录数</param>
        /// <returns>JSON字符串</returns>
        public static string GetJsonFromDataSet(DataSet ds, int total)
        {
            StringBuilder JsonString = new StringBuilder();
            if (ds != null && ds.Tables.Count > 0)
            {
                return GetJsonFromDataTable(ds.Tables[0], total);
            }
            else
            {
                return GetJsonFromDataTable(null, total);
            }
            
        }
        /// <summary>
        /// 将DataTable转换为JSON字符串
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns>JSON字符串</returns>
        public static string GetJsonFromDataTable(DataTable dt)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt == null || dt.Rows.Count == 0)
            {
                JsonString.Append("[]");
                return JsonString.ToString().Replace("\n", "");
            }
            JsonString.Append("[ ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JsonString.Append("{ ");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + JsonCharFilter(dt.Rows[i][j].ToString()) + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + JsonCharFilter(dt.Rows[i][j].ToString()) + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    JsonString.Append("} ");
                }
                else
                {
                    JsonString.Append("}, ");
                }
            }
            JsonString.Append("]");
            return JsonString.ToString().Replace("\n", "");
        }

        /// <summary>
        /// json 字符过滤
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }
        /// <summary>
        /// 适用于新增、更新，把返回的结果值放入json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToFomater(DataTable dt)
        {
            sb.Clear();
            sb.Append("[{");
            if (dt == null || dt.Rows.Count > 0)
            {
                string str = dt.Rows[0][0].ToString();
                if (str == "修改成功" || str == "取消成功" || str == "设置成功" || str == "操作成功" || str.IndexOf("新增成功") != -1 || str.IndexOf("保存成功") != -1)
                {
                    sb.Append("\"success\":");
                    sb.Append("true,");
                }
                else
                {
                    sb.Append("\"success\":");
                    sb.Append("false,");
                }
                sb.Append("\"msg\":");
                sb.Append("\"" + str + "\"");
            }
            sb.Append("}]");
            return sb.ToString();
        }
        public static string CheckLogin()
        {
            sb.Append("[{");
            sb.Append("\"success\":");
            sb.Append("false,");
            sb.Append("\"reload\":");
            sb.Append("true,");
            sb.Append("\"url\":");
            sb.Append("\"/login.html\",");
            sb.Append("\"msg\":");
            sb.Append("\"非法操作，请重新登录\"");
            sb.Append("}]");
            return sb.ToString();
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="dt">dt</param>
        /// <param name="total">总条数</param>
        /// <param name="ShowFooter">是否显示footer</param>
        /// <param name="fields">那些字段求和</param>
        /// <param name="inputfiled">showmessage放在那个字段上</param>
        /// <param name="ShowMessage">默认合计</param>
        /// <returns></returns>
        public static string GetJsonFromDataTable(DataTable dt, int total, bool ShowFooter, string fields, string inputfiled, string ShowMessage = "合计:")
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt==null||dt.Rows.Count == 0)
            {
                JsonString.Append("{ ");
                JsonString.Append("\"rows\":[ ");
                JsonString.Append("]");
                JsonString.Append(",");
                JsonString.Append("\"total\":");
                JsonString.Append(total);
                JsonString.Append(",\"footer\":[");
                JsonString.Append("]");
                JsonString.Append("}");
                return JsonString.ToString().Replace("\n", "");
            }
            JsonString.Append("{ ");
            JsonString.Append("\"rows\":[ ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JsonString.Append("{ ");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + JsonCharFilter(dt.Rows[i][j].ToString()) + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + JsonCharFilter(dt.Rows[i][j].ToString()) + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    JsonString.Append("} ");
                }
                else
                {
                    JsonString.Append("}, ");
                }
            }
            JsonString.Append("]");
            JsonString.Append(",");
            JsonString.Append("\"total\":");
            JsonString.Append(total);
            if (ShowFooter == true && fields.Length > 0 && inputfiled.Length > 0)
            {
                JsonString.Append(",\"footer\":[{");
                JsonString.Append("\"" + inputfiled + "\":\"<span style='color:red;  font-weight:bold'>" + ShowMessage + "</span>\",");
                string[] arr = fields.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i < arr.Length - 1)
                    {
                        JsonString.Append("\"" + arr[i] + "\":\"" + dt.Compute("sum(" + arr[i] + ")", "") + "\",");
                    }
                    else
                    {
                        JsonString.Append("\"" + arr[i] + "\":\"" + dt.Compute("sum(" + arr[i] + ")", "") + "\"");
                    }
                }
                JsonString.Append("}]");
            }
            JsonString.Append("}");
            return JsonString.ToString().Replace("\n", "");
        }

        /// <summary>
        /// 把对象转成json字符串
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string ObjToJson(object o)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.Web.Script.Serialization.JavaScriptSerializer json = new System.Web.Script.Serialization.JavaScriptSerializer();
            json.Serialize(o, sb);
            return sb.ToString();
        }
    }
}