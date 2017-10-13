using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WTCJ
{
    public class ExcelHelper
    {//Excel数据转List<T>
        //public static IList<T> ReadExcelToEntityList<T>(string filePath) where T : class, new()
        //{
        //    DataTable tbl = ReadExcelToDataTable(filePath);//读取Excel数据到DataTable

        //    IList<T> list = DataTableToList<T>(tbl);

        //    return list;

        //}

        //Excel数据转DataTable 使用的oledb读取方式
        private static DataTable ReadExcelToDataTable2007(string filePath)
        {

            String sheetName = getExcelSheetFirstName2007(filePath);
            return ReadExcelToDataTable(filePath, sheetName);
        }
        //Excel数据转DataTable 使用的oledb读取方式
        private static DataTable ReadExcelToDataTable2003(string filePath)
        {

            String sheetName = getExcelSheetFirstName2003(filePath);
            return ReadExcelToDataTable(filePath, sheetName);
        }
        private static DataTable ReadExcelToDataTable(string filePath, string sheetName)
        {
            if (filePath == string.Empty) throw new ArgumentNullException("路径参数不能为空");
            string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source=" + filePath + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * From[" + sheetName + "$]", ConnectionString); //默认读取的Sheet1,你也可以把它封装变量,动态读取你的Sheet工作表
            DataTable table = new DataTable("TempTable");
            adapter.Fill(table);
            return table;
        }
        //DataTable转List<T>
        private static List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {

            if (dt == null) return null;

            List<T> list = new List<T>();

            //遍历DataTable中所有的数据行 
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();

                PropertyInfo[] propertys = t.GetType().GetProperties();

                foreach (PropertyInfo pro in propertys)
                {
                    //检查DataTable是否包含此列（列名==对象的属性名）   
                    if (dt.Columns.Contains(pro.Name))
                    {
                        object value = dr[pro.Name];

                        value = Convert.ChangeType(value, pro.PropertyType);//强制转换类型

                        //如果非空，则赋给对象的属性  PropertyInfo
                        if (value != DBNull.Value)
                        {
                            pro.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中 
                list.Add(t);
            }

            return list;

        }


        //获取全部Sheet名
        private static List<string> getExcelSheetNames(string filePath)
        {

            string strConn = "";
            List<string> SheetNamesList = new List<string>();
            string fileType = System.IO.Path.GetExtension(filePath); //获取文件的后缀类型
            if (string.IsNullOrEmpty(fileType)) return null;

            if (fileType == ".xls")
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            }
            else
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            }

            OleDbConnection conn = null;

            try
            {
                conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable sheetNames = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow dr in sheetNames.Rows)
                {
                    string SheetName = dr["TABLE_NAME"].ToString();   //这个就是其中一个Sheet
                    if (!"$".Equals(SheetName.Substring(SheetName.Length - 1, 1)))
                    {
                        continue;
                    }
                    //截取$ 取真实sheet名
                    /*  if ("$".Equals(SheetName.Substring(SheetName.Length - 1, 1)) || SheetName.IndexOf("$") > -1)
                      {
                          SheetName = SheetName.Substring(0, SheetName.LastIndexOf("$"));
                      }*/
                    SheetNamesList.Add(SheetName);
                }
            }
            catch (Exception err)
            {

            }
            finally
            {
                conn.Close();
            }
            return SheetNamesList;
        }



        private static String getExcelSheetFirstName2007(string excelFilePath)
        {
            String sheetName = null;
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                try
                {
                    ISheet sheet = workbook.GetSheetAt(0);

                    sheetName = workbook.GetSheetName(0);

                }
                catch (Exception ex)
                {

                }
            }
            return sheetName;
        }
        private static String getExcelSheetFirstName2003(string excelFilePath)
        {
            String sheetName = null;
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                IWorkbook workbook = new HSSFWorkbook(stream);
                try
                {
                    ISheet sheet = workbook.GetSheetAt(0);

                    sheetName = workbook.GetSheetName(0);

                }
                catch (Exception ex)
                {

                }
            }
            return sheetName;
        }


        public static DataTable ReadExcelToDataTable(String severPath,HttpPostedFileBase file,String fileEx){
            String filePath = Path.Combine(severPath, DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString() + fileEx);
            DataTable dt = new DataTable("Table1");
            try
            {
                file.SaveAs(filePath);
                String sheetName = null;

                if (string.Equals(".xls", fileEx.ToLower()))
                {
                    sheetName = getExcelSheetFirstName2003(filePath);

                }
                else if (string.Equals(".xlsx", fileEx.ToLower()))
                {
                    sheetName = getExcelSheetFirstName2007(filePath);
                }

                if (sheetName == null)
                {
                    return null;
                }
                string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Data Source=" + filePath + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                OleDbDataAdapter adapter = new OleDbDataAdapter("select * From[" + sheetName + "$]", ConnectionString); //默认读取的Sheet1,你也可以把它封装变量,动态读取你的Sheet工作表               
                adapter.Fill(dt);
                //RemoveEmpty(dt);
            }
            finally
            {
                System.IO.File.Delete(filePath);//每次上传完毕删除文件
            }
            return dt;
        }

        protected static void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                        break;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }

    }
}