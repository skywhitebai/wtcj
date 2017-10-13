
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.IO.Compression;
using System.Data;
using NPOI.HSSF.Util;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.XSSF.UserModel;
namespace WTCJ
{
    public class NOPI_ExcelHelp
    {
        #region 公共函数
        /// <summary>
        /// 将datatable转为内存流
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>5
        public MemoryStream RenderToExcel(System.Data.DataTable table)
        {
            MemoryStream ms = new MemoryStream();

            using (table)
            {
                IWorkbook workbook = new HSSFWorkbook();
                {
                    ISheet sheet = workbook.CreateSheet();
                    {
                        IRow headerRow = sheet.CreateRow(0);

                        // handling header.
                        //- 这里是创建一个标题的样式
                        var cellFont = workbook.CreateFont();
                        var cellStyle = workbook.CreateCellStyle();

                        //- 加粗
                        cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                        cellStyle.VerticalAlignment = VerticalAlignment.Center;
                        cellStyle.Alignment = HorizontalAlignment.Center;
                        cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                        cellStyle.FillPattern = FillPattern.SolidForeground;
                        int columnIndex = 0;
                        foreach (DataColumn column in table.Columns)
                        {
                            ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                            cell.SetCellValue(column.Caption);
                            cell.CellStyle = cellStyle;
                            sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256
                            columnIndex++;
                        }
                        // handling value.
                        int rowIndex = 1;

                        foreach (DataRow row in table.Rows)
                        {
                            IRow dataRow = sheet.CreateRow(rowIndex);

                            foreach (DataColumn column in table.Columns)
                            {
                                ICell cell = dataRow.CreateCell(column.Ordinal);
                                switch (column.DataType.ToString())
                                {
                                    case "System.Int16"://整型
                                    case "System.Int32":
                                    case "System.Int64":
                                        if (row[column].ToString() != "")//如果单元格不为空
                                        {
                                            int intV;
                                            int.TryParse(row[column].ToString(), out intV);
                                            cell.SetCellValue(intV);
                                        }
                                        break;
                                    case "System.Decimal"://浮点型
                                    case "System.Double":
                                        if (row[column].ToString() != "")//如果单元格不为空
                                        {
                                            double doubV;
                                            double.TryParse(row[column].ToString(), out doubV);
                                            cell.SetCellValue(doubV);
                                        }
                                        break;

                                    default:
                                        cell.SetCellValue(row[column].ToString());
                                        break;

                                }

                                cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                cell.CellStyle.Alignment = HorizontalAlignment.Center;
                            }

                            rowIndex++;
                        }

                        workbook.Write(ms);
                        ms.Flush();
                        ms.Position = 0;
                    }
                }
            }
            return ms;
        }


        public MemoryStream RenderToExcel_New(System.Data.DataTable table)
        {
            MemoryStream ms = new MemoryStream();

            using (table)
            {
                IWorkbook workbook = new HSSFWorkbook();
                {
                    ISheet sheet = workbook.CreateSheet();
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.Height = 25 * 20;

                        // handling header.
                        //- 这里是创建一个标题的样式
                        var cellFont = workbook.CreateFont();
                        var cellStyle = workbook.CreateCellStyle();
                        //- 加粗
                        cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                        cellStyle.VerticalAlignment = VerticalAlignment.Center;
                        cellStyle.Alignment = HorizontalAlignment.Center;
                        cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;

                        cellStyle.FillPattern = FillPattern.SolidForeground;

                        cellStyle.BorderBottom = BorderStyle.Thin;
                        cellStyle.BottomBorderColor = HSSFColor.Black.Index;
                        cellStyle.BorderLeft = BorderStyle.Thin;
                        cellStyle.LeftBorderColor = HSSFColor.Black.Index;
                        cellStyle.BorderRight = BorderStyle.Thin;
                        cellStyle.RightBorderColor = HSSFColor.Black.Index;
                        cellStyle.BorderTop = BorderStyle.Thin;
                        cellStyle.TopBorderColor = HSSFColor.Black.Index;

                        var newcellStyle = workbook.CreateCellStyle();
                        newcellStyle.VerticalAlignment = VerticalAlignment.Center;
                        newcellStyle.Alignment = HorizontalAlignment.Center;
                        newcellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                        newcellStyle.FillPattern = FillPattern.SolidForeground;
                        newcellStyle.BorderBottom = BorderStyle.Thin;
                        newcellStyle.BottomBorderColor = HSSFColor.Black.Index;
                        newcellStyle.BorderLeft = BorderStyle.Thin;
                        newcellStyle.LeftBorderColor = HSSFColor.Black.Index;
                        newcellStyle.BorderRight = BorderStyle.Thin;
                        newcellStyle.RightBorderColor = HSSFColor.Black.Index;
                        newcellStyle.BorderTop = BorderStyle.Thin;
                        newcellStyle.TopBorderColor = HSSFColor.Black.Index;

                        string strColumn = "流水号,受理号码,受理地市,业务类型,服务请求类别,问题发生地,区/县,区域归属,投诉地点,楼层,经度,纬度,距离基站(主覆盖)距离,基站(主覆盖)名称,故障原因,ICD定性,原因分析,解决措施,是否解决,未解决(已有规划),未解决(无规划),入网时间,终端类型";
                        string[] str = strColumn.Split(',');
                        int columnIndex = 0;
                        foreach (DataColumn column in table.Columns)
                        {
                            ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                            cell.SetCellValue(column.Caption);

                            int j = 0;
                            //必填字段设置为红色标头
                            for (int i = 0; i < str.Length; i++)
                            {
                                if (str[i] != "")
                                {
                                    j++;
                                    if (column.ColumnName == str[i])
                                    {
                                        cell.CellStyle = newcellStyle;
                                        break;
                                    }
                                }
                            }
                            //非必填字段为无底色
                            if (j == str.Length)
                            {
                                cell.CellStyle = cellStyle;
                            }
                            sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256

                            columnIndex++;
                        }
                        // handling value.
                        int rowIndex = 1;

                        foreach (DataRow row in table.Rows)
                        {
                            IRow dataRow = sheet.CreateRow(rowIndex);

                            foreach (DataColumn column in table.Columns)
                            {
                                ICell cell = dataRow.CreateCell(column.Ordinal);
                                cell.CellStyle = cellStyle;
                                switch (column.DataType.ToString())
                                {
                                    case "System.Int16"://整型
                                    case "System.Int32":
                                    case "System.Int64":
                                        if (row[column].ToString() != "")//如果单元格不为空
                                        {
                                            int intV;
                                            int.TryParse(row[column].ToString(), out intV);
                                            cell.SetCellValue(intV);
                                        }
                                        break;
                                    case "System.Decimal"://浮点型
                                    case "System.Double":
                                        if (row[column].ToString() != "")//如果单元格不为空
                                        {
                                            double doubV;
                                            double.TryParse(row[column].ToString(), out doubV);
                                            cell.SetCellValue(doubV);
                                        }
                                        break;

                                    default:
                                        cell.SetCellValue(row[column].ToString());
                                        break;

                                }

                                cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                cell.CellStyle.Alignment = HorizontalAlignment.Left;
                            }

                            rowIndex++;
                        }

                        workbook.Write(ms);
                        ms.Flush();
                        ms.Position = 0;
                    }
                }
            }
            return ms;
        }

        /// <summary>
        /// datatable 转excel 输出（NPOI）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="context"></param>
        /// <param name="fileName"></param>
        public void OutputExcel(System.Data.DataTable dt, HttpContext context, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = RenderToExcel(dt);
            //if (context.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }


        public void OutputExcel_New(System.Data.DataTable dt, HttpContext context, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = RenderToExcel_New(dt);
            //if (context.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }
        /// <summary>
        /// 根据文件FileStream读取Excel到DataTable
        /// </summary>
        /// <param name="fs"></param>
        /// <returns></returns>
        public System.Data.DataTable[] ExcelToDataTableArr(FileStream fs)
        {
            List<DataTable> lst = new List<DataTable>();
            using (fs)
            {
                IWorkbook workbook = new HSSFWorkbook(fs);
                {
                    for (int f = 0; f < workbook.NumberOfSheets; f++)
                    {
                        ISheet sheet = workbook.GetSheetAt(f);//取第一个表
                        {
                            System.Data.DataTable table = new System.Data.DataTable();

                            IRow headerRow = sheet.GetRow(0);//第一行为标题行
                            int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
                            int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1
                            table.TableName = sheet.SheetName;
                            //handling header.
                            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                            {
                                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                table.Columns.Add(column);
                            }

                            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                            {
                                IRow row = sheet.GetRow(i);
                                DataRow dataRow = table.NewRow();

                                if (row != null)
                                {
                                    for (int j = row.FirstCellNum; j < cellCount; j++)
                                    {
                                        if (row.GetCell(j) != null)
                                            dataRow[j] = row.GetCell(j).ToString().Trim();
                                    }
                                }

                                table.Rows.Add(dataRow);
                            }
                            lst.Add(table);
                        }

                    } return lst.ToArray();
                }
            }
        }

        /// <summary>
        /// 根据文件FileStream读取Excel到DataTable
        /// </summary>
        /// <param name="fs"></param>
        /// <returns></returns>
        public System.Data.DataTable ExcelToDataTable(FileStream fs)
        {
            using (fs)
            {
                IWorkbook workbook = new HSSFWorkbook(fs);
                {
                    ISheet sheet = workbook.GetSheetAt(0);//取第一个表
                    {
                        System.Data.DataTable table = new System.Data.DataTable();

                        IRow headerRow = sheet.GetRow(0);//第一行为标题行
                        int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
                        int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

                        //handling header.
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                            table.Columns.Add(column);
                        }

                        for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = table.NewRow();

                            if (row != null)
                            {
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    if (row.GetCell(j) != null)
                                        dataRow[j] = row.GetCell(j).ToString().Trim();
                                }
                            }

                            table.Rows.Add(dataRow);
                        }
                        return table;

                    }
                }
            }

        }


        /// <summary>
        /// excel文件转datatable（NPOI）
        /// </summary>
        /// <param name="excelFileStream"></param>
        /// <returns></returns>
        public System.Data.DataTable ExcelToDataTable(Stream excelFileStream)
        {
            using (excelFileStream)
            {
                try
                {
                    IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                    {
                        ISheet sheet = workbook.GetSheetAt(0);//取第一个表
                        {
                            System.Data.DataTable table = new System.Data.DataTable();

                            IRow headerRow = sheet.GetRow(0);//第一行为标题行
                            int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
                            int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

                            //handling header.
                            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                            {
                                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                table.Columns.Add(column);
                            }

                            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                            {
                                IRow row = sheet.GetRow(i);
                                DataRow dataRow = table.NewRow();

                                if (row != null)
                                {
                                    for (int j = row.FirstCellNum; j < cellCount; j++)
                                    {
                                        if (row.GetCell(j) != null)
                                            dataRow[j] = row.GetCell(j).ToString().Trim().Trim('_');
                                    }
                                }

                                table.Rows.Add(dataRow);
                            }
                            return table;

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }
        /// <summary>
        /// excel文件转datatable（NPOI）
        /// </summary>
        /// <param name="excelFileStream"></param>
        /// <returns></returns>
        public System.Data.DataTable ExcelToDataTable1(Stream excelFileStream)
        {
            using (excelFileStream)
            {
                try
                {
                    IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                    {
                        ISheet sheet = workbook.GetSheetAt(0);//取第一个表
                        {
                            System.Data.DataTable table = new System.Data.DataTable();

                            IRow headerRow = sheet.GetRow(0);//第一行为标题行
                            int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
                            int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

                            //handling header.
                            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                            {
                                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                table.Columns.Add(column);
                            }

                            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                            {
                                IRow row = sheet.GetRow(i);
                                DataRow dataRow = table.NewRow();

                                if (row != null)
                                {
                                    for (int j = row.FirstCellNum; j < cellCount; j++)
                                    {
                                        if (row.GetCell(j) != null)
                                            dataRow[j] = row.GetCell(j).ToString().Trim().Trim('_');
                                    }
                                }

                                table.Rows.Add(dataRow);
                            }
                            return table;

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }

        /// <summary>
        /// excel文件转datatable（NPOI）
        /// </summary>
        /// <param name="excelFileStream"></param>
        /// <returns></returns>
        public System.Data.DataTable[] ExcelToDataTableArray(Stream excelFileStream)
        {
            List<DataTable> lst = new List<DataTable>();
            if (excelFileStream.Length > 0)
            {

                IWorkbook workbook = new HSSFWorkbook(excelFileStream);

                for (int f = 0; f < workbook.NumberOfSheets; f++)
                {
                    ISheet sheet = workbook.GetSheetAt(f);//取第一个表

                    System.Data.DataTable table = new System.Data.DataTable();
                    table.TableName = sheet.SheetName;
                    IRow headerRow = sheet.GetRow(0);//第一行为标题行
                    if (headerRow != null)
                    {
                        int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
                        int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

                        //handling header.
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                            table.Columns.Add(column);
                        }

                        for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = table.NewRow();

                            if (row != null)
                            {
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    if (row.GetCell(j) != null)
                                        dataRow[j] = row.GetCell(j).ToString().Trim().Trim('_');
                                }
                            }

                            table.Rows.Add(dataRow);
                        }
                        lst.Add(table);
                    }

                } return lst.ToArray();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// excel文件转dataset（NPOI）
        /// </summary>
        /// <param name="excelFileStream"></param>
        /// <returns></returns>
        public System.Data.DataSet ExcelToDataSet(Stream excelFileStream)
        {
            DataSet lst = new DataSet();
            if (excelFileStream.Length > 0)
            {
                using (excelFileStream)
                {
                    IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                    {
                        for (int f = 0; f < workbook.NumberOfSheets; f++)
                        {
                            ISheet sheet = workbook.GetSheetAt(f);//取第一个表
                            {
                                System.Data.DataTable table = new System.Data.DataTable();
                                table.TableName = sheet.SheetName;
                                IRow headerRow = sheet.GetRow(0);//第一行为标题行
                                if (headerRow != null)
                                {
                                    int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
                                    int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

                                    //handling header.
                                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                                    {
                                        DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                        table.Columns.Add(column);
                                    }

                                    for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                                    {
                                        IRow row = sheet.GetRow(i);
                                        DataRow dataRow = table.NewRow();

                                        if (row != null)
                                        {
                                            for (int j = row.FirstCellNum; j < cellCount; j++)
                                            {
                                                if (row.GetCell(j) != null)
                                                    dataRow[j] = row.GetCell(j).ToString().Trim().Trim('_');
                                            }
                                        }

                                        table.Rows.Add(dataRow);
                                    }
                                    lst.Tables.Add(table.Copy());
                                }
                            }
                        } return lst;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 将DataTable集合转换成流
        /// <summary>
        /// 将DataTable集合转换成流
        /// </summary>
        /// <param name="dt">table集合</param>
        /// <param name="context">上下文</param>
        /// <param name="fileName">路径</param>
        public void OutputArrExcel(List<DataTable> dt, HttpContext context, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = RenderArrToExcel(dt);
            //if (context.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }

        /// <summary>
        /// 将DataTable集合转换成流
        /// </summary>
        /// <param name="tarr">table集合</param>
        /// <returns>流</returns>
        public MemoryStream RenderArrToExcel(List<DataTable> tarr)
        {
            MemoryStream ms = new MemoryStream();


            IWorkbook workbook = new HSSFWorkbook();
            {
                for (int j = 0; j < tarr.Count; j++)
                {
                    DataTable table = tarr[j];
                    ISheet sheet = workbook.CreateSheet(table.TableName);
                    IRow headerRow = sheet.CreateRow(0);

                    // handling header.
                    //- 这里是创建一个标题的样式
                    var cellFont = workbook.CreateFont();
                    var cellStyle = workbook.CreateCellStyle();

                    //- 加粗
                    cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

                    cellStyle.VerticalAlignment = VerticalAlignment.Center;
                    cellStyle.Alignment = HorizontalAlignment.Center;
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                    cellStyle.FillPattern = FillPattern.SolidForeground;
                    int columnIndex = 0;
                    foreach (DataColumn column in table.Columns)
                    {
                        ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                        cell.SetCellValue(column.Caption);
                        cell.CellStyle = cellStyle;
                        sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256
                        columnIndex++;
                    }
                    // handling value.
                    int rowIndex = 1;

                    foreach (DataRow row in table.Rows)
                    {
                        IRow dataRow = sheet.CreateRow(rowIndex);

                        foreach (DataColumn column in table.Columns)
                        {
                            ICell cell = dataRow.CreateCell(column.Ordinal);

                            switch (column.DataType.ToString())
                            {
                                case "System.Int16"://整型
                                case "System.Int32":
                                case "System.Int64":
                                    if (row[column].ToString() != "")//如果单元格不为空
                                    {
                                        int intV;
                                        int.TryParse(row[column].ToString(), out intV);
                                        cell.SetCellValue(intV);
                                    }
                                    break;
                                case "System.Decimal"://浮点型
                                case "System.Double":
                                    if (row[column].ToString() != "")//如果单元格不为空
                                    {
                                        double doubV;
                                        double.TryParse(row[column].ToString(), out doubV);
                                        cell.SetCellValue(doubV);
                                    }
                                    break;

                                default:
                                    cell.SetCellValue(row[column].ToString());
                                    break;

                            }


                            cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                            cell.CellStyle.Alignment = HorizontalAlignment.Center;
                        }

                        rowIndex++;
                    }
                }
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
            }

            return ms;
        }

        #endregion

        #region 将DataTable集合转换成流
        /// <summary>
        /// 将内存流转化为Excel
        /// </summary>
        /// <param name="ds">dataset对象</param>
        /// <param name="context">上下文报文</param>
        /// <param name="fileName">EXCAL文件名称</param>
        public void OutputExcel(DataSet ds, HttpContext context, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = RenderArrToExcel(ds);
            //if (context.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }

        public void OutputExcel(DataSet ds, HttpContext context, string fileName, string[] str)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = RenderArrToExcel(ds, str);
            //if (context.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }
        /// <summary>
        /// EXCAL多SHEET导出
        /// </summary>
        /// <param name="ds">dataset 对象</param>
        /// <returns> MemoryStream 对象</returns>
        public MemoryStream RenderArrToExcel(DataSet ds)
        {
            MemoryStream ms = new MemoryStream();


            IWorkbook workbook = new HSSFWorkbook();
            {
                for (int j = 0; j < ds.Tables.Count; j++)
                {
                    DataTable table = ds.Tables[j];
                    string sheetname = "";
                    switch (j)
                    {
                        case 0:
                            sheetname = "协维数据汇总";
                            break;
                        case 1:
                            sheetname = "CQT测试";
                            break;
                        case 2:
                            sheetname = "DT测试";
                            break;
                        case 3:
                            sheetname = "车辆使用情况";
                            break;
                        case 4:
                            sheetname = "解决问题";
                            break;
                        case 5:
                            sheetname = "处理投诉";
                            break;
                        default:
                            sheetname = "1";
                            break;

                    }
                    ISheet sheet = workbook.CreateSheet(sheetname);
                    IRow headerRow = sheet.CreateRow(0);



                    // handling header.
                    //- 这里是创建一个标题的样式
                    var cellFont = workbook.CreateFont();
                    var cellStyle = workbook.CreateCellStyle();

                    //- 加粗
                    cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

                    cellStyle.VerticalAlignment = VerticalAlignment.Center;
                    cellStyle.Alignment = HorizontalAlignment.Center;
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                    cellStyle.FillPattern = FillPattern.SolidForeground;
                    int columnIndex = 0;
                    foreach (DataColumn column in table.Columns)
                    {
                        ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                        cell.SetCellValue(column.Caption);
                        cell.CellStyle = cellStyle;
                        sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256
                        columnIndex++;
                    }
                    // handling value.
                    int rowIndex = 1;

                    foreach (DataRow row in table.Rows)
                    {
                        IRow dataRow = sheet.CreateRow(rowIndex);

                        foreach (DataColumn column in table.Columns)
                        {
                            ICell cell = dataRow.CreateCell(column.Ordinal);
                            cell.SetCellValue(row[column].ToString());
                            cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                            cell.CellStyle.Alignment = HorizontalAlignment.Center;
                        }

                        rowIndex++;
                    }
                }
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
            }

            return ms;
        }


        /// <summary>
        /// EXCAL多SHEET导出
        /// </summary>
        /// <param name="ds">dataset 对象</param>
        /// <returns> MemoryStream 对象</returns>
        public MemoryStream RenderArrToExcel(DataSet ds, string[] str)
        {
            MemoryStream ms = new MemoryStream();


            IWorkbook workbook = new HSSFWorkbook();
            {
                for (int j = 0; j < ds.Tables.Count; j++)
                {
                    DataTable table = ds.Tables[j];
                    string sheetname = str[j];

                    ISheet sheet = workbook.CreateSheet(sheetname);
                    IRow headerRow = sheet.CreateRow(0);



                    // handling header.
                    //- 这里是创建一个标题的样式
                    var cellFont = workbook.CreateFont();
                    var cellStyle = workbook.CreateCellStyle();

                    //- 加粗
                    cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

                    cellStyle.VerticalAlignment = VerticalAlignment.Center;
                    cellStyle.Alignment = HorizontalAlignment.Center;
                    cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                    cellStyle.FillPattern = FillPattern.SolidForeground;
                    int columnIndex = 0;
                    foreach (DataColumn column in table.Columns)
                    {
                        ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                        cell.SetCellValue(column.Caption);
                        cell.CellStyle = cellStyle;
                        sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256
                        columnIndex++;
                    }
                    // handling value.
                    int rowIndex = 1;

                    foreach (DataRow row in table.Rows)
                    {
                        IRow dataRow = sheet.CreateRow(rowIndex);

                        foreach (DataColumn column in table.Columns)
                        {
                            ICell cell = dataRow.CreateCell(column.Ordinal);
                            cell.SetCellValue(row[column].ToString());
                            cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                            cell.CellStyle.Alignment = HorizontalAlignment.Center;
                        }

                        rowIndex++;
                    }
                }
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
            }

            return ms;
        }

        #endregion


        #region 将DataTable转换成服务器的成excel
        public void CreateAndDownExcel(System.Data.DataTable table, string filename)
        {
            //string filepath = Server.MapPath(@"~\rcudownload\" + filename + ".xlsx");
            string dirpath = System.Configuration.ConfigurationManager.AppSettings["DownDirPath"];
            string days = DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(dirpath + days))
            {
                Directory.CreateDirectory(dirpath + days);
            }
            string filepath = dirpath + days + "/" + filename + ".xls";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            if (!File.Exists(filepath))
            {
                using (table)
                {
                    IWorkbook workbook = new HSSFWorkbook();
                    {
                        ISheet sheet = workbook.CreateSheet();
                        {
                            IRow headerRow = sheet.CreateRow(0);
                            headerRow.Height = 25 * 20;
                            // handling header.
                            //- 这里是创建一个标题的样式
                            var cellFont = workbook.CreateFont();
                            var cellStyle = workbook.CreateCellStyle();
                            //- 加粗
                            cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                            cellStyle.VerticalAlignment = VerticalAlignment.Center;
                            cellStyle.Alignment = HorizontalAlignment.Center;
                            cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;

                            cellStyle.FillPattern = FillPattern.SolidForeground;

                            cellStyle.BorderBottom = BorderStyle.Thin;
                            cellStyle.BottomBorderColor = HSSFColor.Black.Index;
                            cellStyle.BorderLeft = BorderStyle.Thin;
                            cellStyle.LeftBorderColor = HSSFColor.Black.Index;
                            cellStyle.BorderRight = BorderStyle.Thin;
                            cellStyle.RightBorderColor = HSSFColor.Black.Index;
                            cellStyle.BorderTop = BorderStyle.Thin;
                            cellStyle.TopBorderColor = HSSFColor.Black.Index;

                            var newcellStyle = workbook.CreateCellStyle();
                            newcellStyle.VerticalAlignment = VerticalAlignment.Center;
                            newcellStyle.Alignment = HorizontalAlignment.Center;
                            newcellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                            newcellStyle.FillPattern = FillPattern.SolidForeground;
                            newcellStyle.BorderBottom = BorderStyle.Thin;
                            newcellStyle.BottomBorderColor = HSSFColor.Black.Index;
                            newcellStyle.BorderLeft = BorderStyle.Thin;
                            newcellStyle.LeftBorderColor = HSSFColor.Black.Index;
                            newcellStyle.BorderRight = BorderStyle.Thin;
                            newcellStyle.RightBorderColor = HSSFColor.Black.Index;
                            newcellStyle.BorderTop = BorderStyle.Thin;
                            newcellStyle.TopBorderColor = HSSFColor.Black.Index;
                            string strColumn = "流水号,受理号码,受理地市,业务类型,服务请求类别,问题发生地,区/县,区域归属,投诉地点,楼层,经度,纬度,距离基站(主覆盖)距离,基站(主覆盖)名称,故障原因,ICD定性,原因分析,解决措施,是否解决,未解决(已有规划),未解决(无规划),入网时间,终端类型";
                            string[] str = strColumn.Split(',');
                            int columnIndex = 0;
                            foreach (DataColumn column in table.Columns)
                            {
                                ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                                string columnname = column.Caption;
                                switch (column.Caption)
                                {
                                    case "TLU_1":
                                        columnname = "RxAGC";
                                        break;
                                    case "TLU_2":
                                        columnname = "TxAGC";
                                        break;
                                    case "TLU_3":
                                        columnname = "totalecio";
                                        break;
                                    case "TLU_4":
                                        columnname = "TotalEc";
                                        break;
                                    case "TLU_5":
                                        columnname = "ffer";
                                        break;
                                }
                                cell.SetCellValue(columnname);

                                int j = 0;
                                //必填字段设置为红色标头
                                for (int i = 0; i < str.Length; i++)
                                {
                                    if (str[i] != "")
                                    {
                                        j++;
                                        if (column.ColumnName == str[i])
                                        {
                                            cell.CellStyle = newcellStyle;
                                            break;
                                        }
                                    }
                                }
                                //非必填字段为无底色
                                if (j == str.Length)
                                {
                                    cell.CellStyle = cellStyle;
                                }
                                sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256

                                columnIndex++;
                            }
                            // handling value.
                            int rowIndex = 1;

                            foreach (DataRow row in table.Rows)
                            {
                                IRow dataRow = sheet.CreateRow(rowIndex);

                                foreach (DataColumn column in table.Columns)
                                {
                                    ICell cell = dataRow.CreateCell(column.Ordinal);
                                    cell.CellStyle = cellStyle;
                                    switch (column.DataType.ToString())
                                    {
                                        case "System.Int16"://整型
                                        case "System.Int32":
                                        case "System.Int64":
                                            if (row[column].ToString() != "")//如果单元格不为空
                                            {
                                                int intV;
                                                int.TryParse(row[column].ToString(), out intV);
                                                cell.SetCellValue(intV);
                                            }
                                            break;
                                        case "System.Decimal"://浮点型
                                        case "System.Double":
                                            if (row[column].ToString() != "")//如果单元格不为空
                                            {
                                                double doubV;
                                                double.TryParse(row[column].ToString(), out doubV);
                                                cell.SetCellValue(doubV);
                                            }
                                            break;

                                        default:
                                            cell.SetCellValue(row[column].ToString());
                                            break;

                                    }
                                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                    cell.CellStyle.Alignment = HorizontalAlignment.Left;
                                }
                                rowIndex++;
                            }
                        }
                        using (FileStream fs = File.OpenWrite(filepath))
                        {
                            workbook.Write(fs);
                        }
                    }
                    //  HttpResponse contextResponse = HttpContext.Current.Response;
                    //   contextResponse.AddHeader("Content-Disposition", "attachment;fileName=" + filepath);
                    //   contextResponse.BinaryWrite(ms.ToArray());
                }
            }
            FileInfo fi = new FileInfo(filepath);//excelFile为文件在服务器上的地址
            HttpResponse contextResponse = HttpContext.Current.Response;
            contextResponse.Clear();
            contextResponse.Buffer = true;
            contextResponse.Charset = "utf-8"; //设置了类型为中文防止乱码的出现 
            contextResponse.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}", HttpUtility.UrlEncode(filename) + ".xls")); //定义输出文件和文件名 
            contextResponse.AppendHeader("Content-Length", fi.Length.ToString());
            contextResponse.ContentEncoding = Encoding.Default;
            contextResponse.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
            contextResponse.WriteFile(fi.FullName);
            contextResponse.Flush();
            contextResponse.End();
        }
        #endregion


        #region 将DateSet 转成成多sheet的excel
        public void CreateAndDownExcel(System.Data.DataSet ds, string filename)
        {
            string strColumn = "流水号,受理号码,受理地市,业务类型,服务请求类别,问题发生地,区/县,区域归属,投诉地点,楼层,经度,纬度,距离基站(主覆盖)距离,基站(主覆盖)名称,故障原因,ICD定性,原因分析,解决措施,是否解决,未解决(已有规划),未解决(无规划),入网时间,终端类型";
            string[] str = strColumn.Split(',');
            //string filepath = Server.MapPath(@"~\rcudownload\" + filename + ".xlsx");
            string dirpath = System.Configuration.ConfigurationManager.AppSettings["DownDirPath"];
            string days = DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(dirpath + days))
            {
                Directory.CreateDirectory(dirpath + days);
            }

            string filepath = dirpath + days + "/" + filename + ".xls";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            if (!File.Exists(filepath))
            {
                using (ds)
                {
                    IWorkbook workbook = new HSSFWorkbook();
                    {
                        for (int j = 0; j < ds.Tables.Count; j++)
                        {
                            DataTable table = ds.Tables[j];
                            string sheetname = str[j];
                            ISheet sheet = workbook.CreateSheet(sheetname);
                            {
                                IRow headerRow = sheet.CreateRow(0);
                                headerRow.Height = 25 * 20;
                                // handling header.
                                //- 这里是创建一个标题的样式
                                var cellFont = workbook.CreateFont();
                                var cellStyle = workbook.CreateCellStyle();
                                //- 加粗
                                cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                                cellStyle.VerticalAlignment = VerticalAlignment.Center;
                                cellStyle.Alignment = HorizontalAlignment.Center;
                                cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;

                                cellStyle.FillPattern = FillPattern.SolidForeground;

                                cellStyle.BorderBottom = BorderStyle.Thin;
                                cellStyle.BottomBorderColor = HSSFColor.Black.Index;
                                cellStyle.BorderLeft = BorderStyle.Thin;
                                cellStyle.LeftBorderColor = HSSFColor.Black.Index;
                                cellStyle.BorderRight = BorderStyle.Thin;
                                cellStyle.RightBorderColor = HSSFColor.Black.Index;
                                cellStyle.BorderTop = BorderStyle.Thin;
                                cellStyle.TopBorderColor = HSSFColor.Black.Index;

                                var newcellStyle = workbook.CreateCellStyle();
                                newcellStyle.VerticalAlignment = VerticalAlignment.Center;
                                newcellStyle.Alignment = HorizontalAlignment.Center;
                                newcellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                                newcellStyle.FillPattern = FillPattern.SolidForeground;
                                newcellStyle.BorderBottom = BorderStyle.Thin;
                                newcellStyle.BottomBorderColor = HSSFColor.Black.Index;
                                newcellStyle.BorderLeft = BorderStyle.Thin;
                                newcellStyle.LeftBorderColor = HSSFColor.Black.Index;
                                newcellStyle.BorderRight = BorderStyle.Thin;
                                newcellStyle.RightBorderColor = HSSFColor.Black.Index;
                                newcellStyle.BorderTop = BorderStyle.Thin;
                                newcellStyle.TopBorderColor = HSSFColor.Black.Index;

                                int columnIndex = 0;
                                foreach (DataColumn column in table.Columns)
                                {
                                    ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                                    string columnname = column.Caption;
                                    switch (column.Caption)
                                    {
                                        case "TLU_1":
                                            columnname = "RxAGC";
                                            break;
                                        case "TLU_2":
                                            columnname = "TxAGC";
                                            break;
                                        case "TLU_3":
                                            columnname = "totalecio";
                                            break;
                                        case "TLU_4":
                                            columnname = "TotalEc";
                                            break;
                                        case "TLU_5":
                                            columnname = "ffer";
                                            break;
                                    }
                                    cell.SetCellValue(columnname);

                                    int wj = 0;
                                    //必填字段设置为红色标头
                                    for (int i = 0; i < str.Length; i++)
                                    {
                                        if (str[i] != "")
                                        {
                                            wj++;
                                            if (column.ColumnName == str[i])
                                            {
                                                cell.CellStyle = newcellStyle;
                                                break;
                                            }
                                        }
                                    }
                                    //非必填字段为无底色
                                    if (wj == str.Length)
                                    {
                                        cell.CellStyle = cellStyle;
                                    }
                                    sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256

                                    columnIndex++;
                                }
                                // handling value.
                                int rowIndex = 1;

                                foreach (DataRow row in table.Rows)
                                {
                                    IRow dataRow = sheet.CreateRow(rowIndex);

                                    foreach (DataColumn column in table.Columns)
                                    {
                                        ICell cell = dataRow.CreateCell(column.Ordinal);
                                        cell.CellStyle = cellStyle;
                                        switch (column.DataType.ToString())
                                        {
                                            case "System.Int16"://整型
                                            case "System.Int32":
                                            case "System.Int64":
                                                if (row[column].ToString() != "")//如果单元格不为空
                                                {
                                                    int intV;
                                                    int.TryParse(row[column].ToString(), out intV);
                                                    cell.SetCellValue(intV);
                                                }
                                                break;
                                            case "System.Decimal"://浮点型
                                            case "System.Double":
                                                if (row[column].ToString() != "")//如果单元格不为空
                                                {
                                                    double doubV;
                                                    double.TryParse(row[column].ToString(), out doubV);
                                                    cell.SetCellValue(doubV);
                                                }
                                                break;

                                            default:
                                                cell.SetCellValue(row[column].ToString());
                                                break;

                                        }
                                        cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                        cell.CellStyle.Alignment = HorizontalAlignment.Center;
                                    }
                                    rowIndex++;
                                }
                            }
                            using (FileStream fs = File.OpenWrite(filepath))
                            {
                                workbook.Write(fs);
                            }
                        }
                    }
                    //  HttpResponse contextResponse = HttpContext.Current.Response;
                    //   contextResponse.AddHeader("Content-Disposition", "attachment;fileName=" + filepath);
                    //   contextResponse.BinaryWrite(ms.ToArray());
                }
            }
            FileInfo fi = new FileInfo(filepath);//excelFile为文件在服务器上的地址
            HttpResponse contextResponse = HttpContext.Current.Response;
            contextResponse.Clear();
            contextResponse.Buffer = true;
            contextResponse.Charset = "utf-8"; //设置了类型为中文防止乱码的出现 
            contextResponse.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}", HttpUtility.UrlEncode(filename) + ".xls")); //定义输出文件和文件名 
            contextResponse.AppendHeader("Content-Length", fi.Length.ToString());
            contextResponse.ContentEncoding = Encoding.Default;
            contextResponse.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
            contextResponse.WriteFile(fi.FullName);
            contextResponse.Flush();
            contextResponse.End();
        }
        #endregion


        #region 将List<Datatsble>转换成excel
        /// <summary>
        /// 将List<Datatsble>转换成excel
        /// </summary>
        /// <param name="arryta"></param>
        /// <param name="filename"></param>
        public void CreateAndDownExcel(List<System.Data.DataTable> arryta, string filename)
        {
            string strColumn = "流水号,受理号码,受理地市,业务类型,服务请求类别,问题发生地,区/县,区域归属,投诉地点,楼层,经度,纬度,距离基站(主覆盖)距离,基站(主覆盖)名称,故障原因,ICD定性,原因分析,解决措施,是否解决,未解决(已有规划),未解决(无规划),入网时间,终端类型";
            string[] str = strColumn.Split(',');
            //string filepath = Server.MapPath(@"~\rcudownload\" + filename + ".xlsx");
            string dirpath = System.Configuration.ConfigurationManager.AppSettings["DownDirPath"];
            string days = DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(dirpath + days))
            {
                Directory.CreateDirectory(dirpath + days);
            }
            string filepath = dirpath + days + "/" + filename + ".xls";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            //filepath
            if (!File.Exists(filepath))
            {
                IWorkbook workbook = new HSSFWorkbook();
                {
                    for (int j = 0; j < arryta.Count; j++)
                    {
                        DataTable table = arryta[j];
                        ISheet sheet = workbook.CreateSheet(table.TableName);
                        {
                            IRow headerRow = sheet.CreateRow(0);
                            headerRow.Height = 25 * 20;
                            // handling header.
                            //- 这里是创建一个标题的样式
                            var cellFont = workbook.CreateFont();
                            var cellStyle = workbook.CreateCellStyle();
                            //- 加粗
                            cellFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                            cellStyle.VerticalAlignment = VerticalAlignment.Center;
                            cellStyle.Alignment = HorizontalAlignment.Center;
                            cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.White.Index;

                            cellStyle.FillPattern = FillPattern.SolidForeground;

                            cellStyle.BorderBottom = BorderStyle.Thin;
                            cellStyle.BottomBorderColor = HSSFColor.Black.Index;
                            cellStyle.BorderLeft = BorderStyle.Thin;
                            cellStyle.LeftBorderColor = HSSFColor.Black.Index;
                            cellStyle.BorderRight = BorderStyle.Thin;
                            cellStyle.RightBorderColor = HSSFColor.Black.Index;
                            cellStyle.BorderTop = BorderStyle.Thin;
                            cellStyle.TopBorderColor = HSSFColor.Black.Index;

                            var newcellStyle = workbook.CreateCellStyle();
                            newcellStyle.VerticalAlignment = VerticalAlignment.Center;
                            newcellStyle.Alignment = HorizontalAlignment.Center;
                            newcellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                            newcellStyle.FillPattern = FillPattern.SolidForeground;
                            newcellStyle.BorderBottom = BorderStyle.Thin;
                            newcellStyle.BottomBorderColor = HSSFColor.Black.Index;
                            newcellStyle.BorderLeft = BorderStyle.Thin;
                            newcellStyle.LeftBorderColor = HSSFColor.Black.Index;
                            newcellStyle.BorderRight = BorderStyle.Thin;
                            newcellStyle.RightBorderColor = HSSFColor.Black.Index;
                            newcellStyle.BorderTop = BorderStyle.Thin;
                            newcellStyle.TopBorderColor = HSSFColor.Black.Index;

                            int columnIndex = 0;
                            foreach (DataColumn column in table.Columns)
                            {
                                ICell cell = headerRow.CreateCell(column.Ordinal); //If Caption not set, returns the ColumnName value
                                string columnname = column.Caption;
                                switch (column.Caption)
                                {
                                    case "TLU_1":
                                        columnname = "RxAGC";
                                        break;
                                    case "TLU_2":
                                        columnname = "TxAGC";
                                        break;
                                    case "TLU_3":
                                        columnname = "totalecio";
                                        break;
                                    case "TLU_4":
                                        columnname = "TotalEc";
                                        break;
                                    case "TLU_5":
                                        columnname = "ffer";
                                        break;
                                }
                                cell.SetCellValue(columnname);

                                int wj = 0;
                                //必填字段设置为红色标头
                                for (int i = 0; i < str.Length; i++)
                                {
                                    if (str[i] != "")
                                    {
                                        wj++;
                                        if (column.ColumnName == str[i])
                                        {
                                            cell.CellStyle = newcellStyle;
                                            break;
                                        }
                                    }
                                }
                                //非必填字段为无底色
                                if (wj == str.Length)
                                {
                                    cell.CellStyle = cellStyle;
                                }
                                sheet.SetColumnWidth(columnIndex, 20 * 256);//- 设置列宽，需要 乘以 256

                                columnIndex++;
                            }
                            // handling value.
                            int rowIndex = 1;

                            foreach (DataRow row in table.Rows)
                            {
                                IRow dataRow = sheet.CreateRow(rowIndex);

                                foreach (DataColumn column in table.Columns)
                                {
                                    ICell cell = dataRow.CreateCell(column.Ordinal);
                                    cell.CellStyle = cellStyle;
                                    switch (column.DataType.ToString())
                                    {
                                        case "System.Int16"://整型
                                        case "System.Int32":
                                        case "System.Int64":
                                            if (row[column].ToString() != "")//如果单元格不为空
                                            {
                                                int intV;
                                                int.TryParse(row[column].ToString(), out intV);
                                                cell.SetCellValue(intV);
                                            }
                                            break;
                                        case "System.Decimal"://浮点型
                                        case "System.Double":
                                            if (row[column].ToString() != "")//如果单元格不为空
                                            {
                                                double doubV;
                                                double.TryParse(row[column].ToString(), out doubV);
                                                cell.SetCellValue(doubV);
                                            }
                                            break;

                                        default:
                                            cell.SetCellValue(row[column].ToString());
                                            break;

                                    }
                                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                    cell.CellStyle.Alignment = HorizontalAlignment.Left;
                                }
                                rowIndex++;
                            }
                        }
                        using (FileStream fs = File.OpenWrite(filepath))
                        {
                            workbook.Write(fs);
                        }
                    }
                }
            }
            FileInfo fi = new FileInfo(filepath);//excelFile为文件在服务器上的地址
            HttpResponse contextResponse = HttpContext.Current.Response;
            contextResponse.Clear();
            contextResponse.Buffer = true;
            contextResponse.Charset = "utf-8"; //设置了类型为中文防止乱码的出现 
            contextResponse.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}", HttpUtility.UrlEncode(filename) + ".xls")); //定义输出文件和文件名 
            contextResponse.AppendHeader("Content-Length", fi.Length.ToString());
            contextResponse.ContentEncoding = Encoding.Default;
            contextResponse.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
            contextResponse.WriteFile(fi.FullName);
            contextResponse.Flush();
            contextResponse.End();
        }
        #endregion

        #region 创建ZIP压缩包
        //public void CreateZip(string filenam)
        //{ 

        //  using(ZipFile zip = new ZipFile(System.Text.Encoding.Default)))
        //    {

        //    }
        //}
        #endregion




        /// <summary>
        /// 由Excel导入DataSet，如果有多个工作表，则导入多个DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataSet</returns>
        public static DataSet ImportDataSetFromExcel2007(Stream stream)
        {
            DataSet ds = new DataSet();
            XSSFWorkbook workbook = new XSSFWorkbook(stream);
            try
            {
                for (int a = 0, b = workbook.NumberOfSheets; a < b; a++)
                {
                    DataTable table = new DataTable();
                    try
                    {
                        #region 标题
                        string sheetName = string.Empty;
                        ISheet sheet = workbook.GetSheetAt(a);

                        table.TableName = workbook.GetSheetName(a);
                        IRow headerRow = sheet.GetRow(0);
                        if (headerRow == null)
                        {
                            break;
                        }
                        int cellCount = headerRow.LastCellNum;


                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            string strCellValue = string.Empty;
                            if (headerRow.GetCell(i) == null)
                            {
                                // 如果遇到第一个空列，则不再继续向后读取
                                cellCount = i + 1;
                                break;
                            }
                            if (headerRow.GetCell(i).CellType == CellType.String)
                            {
                                strCellValue = headerRow.GetCell(i).StringCellValue;

                            }
                            else if (headerRow.GetCell(i).CellType == CellType.Boolean)
                            {
                                strCellValue = headerRow.GetCell(i).BooleanCellValue.ToString();
                            }
                            else if (headerRow.GetCell(i).CellType == CellType.Error)
                            {
                                strCellValue = headerRow.GetCell(i).ErrorCellValue.ToString();
                            }
                            else if (headerRow.GetCell(i).CellType == CellType.Numeric)
                            {
                                strCellValue = headerRow.GetCell(i).NumericCellValue.ToString();
                            }
                            else
                            {
                                // 如果遇到第一个空列，则不再继续向后读取
                                cellCount = i + 1;
                                break;
                            }
                            if (strCellValue.Trim().Length < 1)
                            {
                                // 如果遇到第一个空列，则不再继续向后读取
                                cellCount = i + 1;
                                break;
                            }
                            DataColumn column = null;
                            //string columnName = headerRow.GetCell(i).StringCellValue;
                            if (table.Columns.Contains(strCellValue))
                            {
                                column = new DataColumn(strCellValue + i.ToString());
                            }
                            else
                            {
                                column = new DataColumn(strCellValue);
                            }
                            // DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                            table.Columns.Add(column);
                        }
                        #endregion
                        #region 内容
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null || row.GetCell(0) == null || row.GetCell(0).ToString().Trim() == "")
                            {
                                // 如果遇到第一个空行，则不再继续向后读取
                                break;
                            }
                            DataRow dataRow = table.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }
                            table.Rows.Add(dataRow);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {

                    }
                    ds.Tables.Add(table);
                }
            }
            catch (Exception ex)
            {
            }
            return ds;

        }
        /// <summary>
        /// 由Excel导入DataSet，如果有多个工作表，则导入多个DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataSet</returns>
        public static DataSet ImportDataSetFromExcel2007(string excelFilePath, int headerRowIndex)
        {
            DataSet ds = new DataSet();
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                try
                {
                    for (int a = 0, b = workbook.NumberOfSheets; a < b; a++)
                    {
                        DataTable table = new DataTable();
                        try
                        {
                            #region 标题
                            string sheetName = string.Empty;
                            ISheet sheet = workbook.GetSheetAt(a);

                            table.TableName = workbook.GetSheetName(a);
                            IRow headerRow = sheet.GetRow(headerRowIndex);
                            if (headerRow == null)
                            {
                                break;
                            }
                            int cellCount = headerRow.LastCellNum;


                            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                            {
                                string strCellValue = string.Empty;
                                if (headerRow.GetCell(i) == null)
                                {
                                    // 如果遇到第一个空列，则不再继续向后读取
                                    cellCount = i + 1;
                                    break;
                                }
                                if (headerRow.GetCell(i).CellType == CellType.String)
                                {
                                    strCellValue = headerRow.GetCell(i).StringCellValue;

                                }
                                else if (headerRow.GetCell(i).CellType == CellType.Boolean)
                                {
                                    strCellValue = headerRow.GetCell(i).BooleanCellValue.ToString();
                                }
                                else if (headerRow.GetCell(i).CellType == CellType.Error)
                                {
                                    strCellValue = headerRow.GetCell(i).ErrorCellValue.ToString();
                                }
                                else if (headerRow.GetCell(i).CellType == CellType.Numeric)
                                {
                                    strCellValue = headerRow.GetCell(i).NumericCellValue.ToString();
                                }
                                else
                                {
                                    // 如果遇到第一个空列，则不再继续向后读取
                                    cellCount = i + 1;
                                    break;
                                }
                                if (strCellValue.Trim().Length < 1)
                                {
                                    // 如果遇到第一个空列，则不再继续向后读取
                                    cellCount = i + 1;
                                    break;
                                }
                                DataColumn column = null;
                                //string columnName = headerRow.GetCell(i).StringCellValue;
                                if (table.Columns.Contains(strCellValue))
                                {
                                    column = new DataColumn(strCellValue + i.ToString());
                                }
                                else
                                {
                                    column = new DataColumn(strCellValue);
                                }
                                // DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                table.Columns.Add(column);
                            }
                            #endregion
                            #region 内容
                            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                            {
                                IRow row = sheet.GetRow(i);
                                if (row == null || row.GetCell(0) == null || row.GetCell(0).ToString().Trim() == "")
                                {
                                    // 如果遇到第一个空行，则不再继续向后读取
                                    break;
                                }
                                DataRow dataRow = table.NewRow();
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    if (row.GetCell(j) != null)
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                                }
                                table.Rows.Add(dataRow);
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {

                        }
                        ds.Tables.Add(table);
                    }
                }
                catch (Exception ex)
                {
                }
                workbook = null;
                stream.Close();
            }
            return ds;

        }
        /// <summary>
        /// 由Excel导入DataSet，如果有多个工作表，则导入多个DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataSet</returns>
        public static DataTable ImportDataTableFromExcel2007(string excelFilePath)
        {
            DataTable table = new DataTable();
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                try
                {
                    #region 标题
                    string sheetName = string.Empty;
                    ISheet sheet = workbook.GetSheetAt(0);

                    table.TableName = workbook.GetSheetName(0);
                    IRow headerRow = sheet.GetRow(0);
                    if (headerRow == null)
                    {
                        return null;
                    }
                    int cellCount = headerRow.LastCellNum;


                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        string strCellValue = string.Empty;
                        if (headerRow.GetCell(i) == null)
                        {
                            // 如果遇到空列，则给默认字段名
                            strCellValue = "Columns" + i.ToString();
                        }
                        else if (headerRow.GetCell(i).CellType == CellType.String)
                        {
                            strCellValue = headerRow.GetCell(i).StringCellValue;

                        }
                        else if (headerRow.GetCell(i).CellType == CellType.Boolean)
                        {
                            strCellValue = headerRow.GetCell(i).BooleanCellValue.ToString();
                        }
                        else if (headerRow.GetCell(i).CellType == CellType.Error)
                        {
                            strCellValue = headerRow.GetCell(i).ErrorCellValue.ToString();
                        }
                        else if (headerRow.GetCell(i).CellType == CellType.Numeric)
                        {
                            strCellValue = headerRow.GetCell(i).NumericCellValue.ToString();
                        }
                        DataColumn column = null;

                        while (table.Columns.Contains(strCellValue))
                        {
                            strCellValue = strCellValue + i.ToString();
                        }
                        column = new DataColumn(strCellValue);
                        table.Columns.Add(column);
                    }
                    #endregion
                    #region 内容
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row != null)
                        {
                            DataRow dataRow = table.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }
                            table.Rows.Add(dataRow);
                        }
                    }
                    #endregion
                }
                catch (Exception ex)
                {

                }
            }
            return table;
        }

        /// <summary>
        /// 由Excel导入DataSet，如果有多个工作表，则导入多个DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataSet</returns>
        public static DataTable ImportDataTableFromExcel2007(Stream stream)
        {
            XSSFWorkbook workbook = new XSSFWorkbook(stream);

            DataTable table = new DataTable();
            try
            {
                #region 标题
                string sheetName = string.Empty;
                ISheet sheet = workbook.GetSheetAt(0);

                table.TableName = workbook.GetSheetName(0);
                IRow headerRow = sheet.GetRow(0);
                if (headerRow == null)
                {
                    return null;
                }
                int cellCount = headerRow.LastCellNum;


                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    string strCellValue = string.Empty;
                    if (headerRow.GetCell(i) == null)
                    {
                        // 如果遇到空列，则给默认字段名
                        strCellValue = "Columns" + i.ToString();
                    }
                    else if (headerRow.GetCell(i).CellType == CellType.String)
                    {
                        strCellValue = headerRow.GetCell(i).StringCellValue;

                    }
                    else if (headerRow.GetCell(i).CellType == CellType.Boolean)
                    {
                        strCellValue = headerRow.GetCell(i).BooleanCellValue.ToString();
                    }
                    else if (headerRow.GetCell(i).CellType == CellType.Error)
                    {
                        strCellValue = headerRow.GetCell(i).ErrorCellValue.ToString();
                    }
                    else if (headerRow.GetCell(i).CellType == CellType.Numeric)
                    {
                        strCellValue = headerRow.GetCell(i).NumericCellValue.ToString();
                    }
                    DataColumn column = null;

                    while (table.Columns.Contains(strCellValue))
                    {
                        strCellValue = strCellValue + i.ToString();
                    }
                    column = new DataColumn(strCellValue);
                    table.Columns.Add(column);
                }
                #endregion
                #region 内容
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row != null)
                    {
                        DataRow dataRow = table.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                            }
                        }
                        table.Rows.Add(dataRow);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
            return table;
        }

        /// <summary>
        /// 由Excel 2003 导入DataSet，如果有多个工作表，则导入多个DataTable
        /// </summary>
        /// <param name="excelFileStream">Excel文件流</param>
        /// <param name="headerRowIndex">Excel表头行索引</param>
        /// <returns>DataSet</returns>
        public static DataSet ImportDataSetFromExcel2003(string excelFilePath, int headerRowIndex)
        {
            DataSet ds = new DataSet();
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(stream);
                try
                {
                    for (int a = 0, b = workbook.NumberOfSheets; a < b; a++)
                    {
                        DataTable table = new DataTable();
                        try
                        {
                            #region 标题
                            string sheetName = string.Empty;
                            ISheet sheet = workbook.GetSheetAt(a);

                            table.TableName = workbook.GetSheetName(a);
                            IRow headerRow = sheet.GetRow(headerRowIndex);
                            int cellCount = headerRow.LastCellNum;


                            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                            {
                                string strCellValue = string.Empty;
                                if (headerRow.GetCell(i) == null)
                                {
                                    // 如果遇到第一个空列，则不再继续向后读取
                                    cellCount = i + 1;
                                    break;
                                }
                                if (headerRow.GetCell(i).CellType == CellType.String)
                                {
                                    strCellValue = headerRow.GetCell(i).StringCellValue;

                                }
                                else if (headerRow.GetCell(i).CellType == CellType.Boolean)
                                {
                                    strCellValue = headerRow.GetCell(i).BooleanCellValue.ToString();
                                }
                                else if (headerRow.GetCell(i).CellType == CellType.Error)
                                {
                                    strCellValue = headerRow.GetCell(i).ErrorCellValue.ToString();
                                }
                                else if (headerRow.GetCell(i).CellType == CellType.Numeric)
                                {
                                    strCellValue = headerRow.GetCell(i).NumericCellValue.ToString();
                                }
                                else
                                {
                                    // 如果遇到第一个空列，则不再继续向后读取
                                    cellCount = i + 1;
                                    break;
                                }
                                if (strCellValue.Trim().Length < 1)
                                {
                                    // 如果遇到第一个空列，则不再继续向后读取
                                    cellCount = i + 1;
                                    break;
                                }
                                DataColumn column = null;
                                //string columnName = headerRow.GetCell(i).StringCellValue;
                                if (table.Columns.Contains(strCellValue))
                                {
                                    column = new DataColumn(strCellValue + i.ToString());
                                }
                                else
                                {
                                    column = new DataColumn(strCellValue);
                                }
                                // DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                table.Columns.Add(column);
                            }
                            #endregion
                            #region 内容
                            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                            {
                                IRow row = sheet.GetRow(i);
                                if (row == null || row.GetCell(0) == null || row.GetCell(0).ToString().Trim() == "")
                                {
                                    // 如果遇到第一个空行，则不再继续向后读取
                                    break;
                                }
                                DataRow dataRow = table.NewRow();
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    if (row.GetCell(j) != null)
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                                }
                                table.Rows.Add(dataRow);
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {

                        }
                        ds.Tables.Add(table);
                    }
                }
                catch (Exception ex)
                {

                }
                workbook = null;
                stream.Close();
            }
            return ds;

        }
        /// <summary>
        /// excel文件转datatable（NPOI）
        /// </summary>
        /// <param name="excelFileStream"></param>
        /// <returns></returns>
        public static System.Data.DataTable ImportDataTableFromExcel2003(Stream excelFileStream)
        {
            using (excelFileStream)
            {
                try
                {
                    IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                    {
                        ISheet sheet = workbook.GetSheetAt(0);//取第一个表
                        {
                            System.Data.DataTable table = new System.Data.DataTable();

                            IRow headerRow = sheet.GetRow(0);//第一行为标题行
                            int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells
                            int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1

                            //handling header.
                            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                            {
                                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                table.Columns.Add(column);
                            }

                            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
                            {
                                IRow row = sheet.GetRow(i);
                                DataRow dataRow = table.NewRow();

                                if (row != null)
                                {
                                    for (int j = row.FirstCellNum; j < cellCount; j++)
                                    {
                                        if (row.GetCell(j) != null)
                                            dataRow[j] = row.GetCell(j).ToString().Trim().Trim('_');
                                    }
                                }

                                table.Rows.Add(dataRow);
                            }
                            return table;

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }

        /// <summary>
        /// NPOI简单Demo，快速入门代码
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strFileName"></param>
        /// <remarks>NPOI认为Excel的第一个单元格是：(0，0)</remarks>
        public static void Export(DataTable dtSource, string strFileName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            //填充表头
            IRow dataRow = sheet.CreateRow(0);
            foreach (DataColumn column in dtSource.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }


            //填充内容
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    if (dtSource.Rows[i][j] != null)
                    {
                        dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                    }
                    else
                    {
                        dataRow.CreateCell(j).SetCellValue("");
                    }
                }
            }


            //保存
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }
        /// <summary>
        /// datatable 转excel 输出（NPOI）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="context"></param>
        /// <param name="fileName"></param>
        public void OutputExcel(System.Data.DataTable dt, HttpContextBase context, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = RenderToExcel(dt);
            //if (context.Request.Browser.Browser == "IE")
            fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }

        internal void OutputExcel(DataTable dt, string filePathTemplate, HttpContextBase context, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = new MemoryStream();
            if (string.IsNullOrEmpty(filePathTemplate))
            {
                ms = RenderToExcel(dt);
                fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            }
            else
            {
                ms = RenderToExcelByTemplate(dt, filePathTemplate);
                fileName = HttpUtility.UrlEncode(fileName) + ".xlsx";
            }
            //if (context.Request.Browser.Browser == "IE")
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }
        internal void OutputExcel(DataTable dt, string filePathTemplate, HttpContextBase context, string fileName, List<int> hideIndex)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = new MemoryStream();
            if (string.IsNullOrEmpty(filePathTemplate))
            {
                ms = RenderToExcel(dt);
                fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            }
            else
            {
                ms = RenderToExcelByTemplate(dt, filePathTemplate, hideIndex);
                fileName = HttpUtility.UrlEncode(fileName) + ".xlsx";
            }
            //if (context.Request.Browser.Browser == "IE")
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }
        /// <summary>
        /// 将datatable转为内存流
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>5
        public MemoryStream RenderToExcelByTemplate(System.Data.DataTable table, string filePathTemplate)
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream stream = System.IO.File.OpenRead(filePathTemplate))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                {
                    ISheet sheet = workbook.GetSheetAt(0);
                    {
                        //使用模板的标题
                        int rowIndex = sheet.LastRowNum + 1;
                        IRow titleRow = sheet.GetRow(0);
                        foreach (DataRow row in table.Rows)
                        {
                            IRow dataRow = sheet.CreateRow(rowIndex);
                            foreach (ICell titleCell in titleRow)
                            {
                                foreach (DataColumn column in table.Columns)
                                {
                                    if (column.ColumnName == titleCell.StringCellValue.Replace("\\n", ""))
                                    {
                                        ICell cell = dataRow.CreateCell(titleCell.ColumnIndex);
                                        switch (column.DataType.ToString())
                                        {
                                            case "System.Int16"://整型
                                            case "System.Int32":
                                            case "System.Int64":
                                                if (row[column].ToString() != "")//如果单元格不为空
                                                {
                                                    int intV;
                                                    int.TryParse(row[column].ToString(), out intV);
                                                    cell.SetCellValue(intV);
                                                }
                                                cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                                                break;
                                            case "System.Decimal"://浮点型
                                            case "System.Double":
                                                if (row[column].ToString() != "")//如果单元格不为空
                                                {
                                                    double doubV;
                                                    double.TryParse(row[column].ToString(), out doubV);
                                                    cell.SetCellValue(doubV);
                                                }
                                                break;
                                            case "System.DateTime":
                                                if (row[column] != null)//如果单元格不为空
                                                {
                                                    cell.SetCellValue(row[column].ToString().Replace(" 0:00:00", ""));
                                                }
                                                break;
                                            default:
                                                cell.SetCellValue(row[column].ToString());
                                                break;

                                        }

                                        cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                        cell.CellStyle.Alignment = HorizontalAlignment.Center;

                                    }
                                }
                            }
                            rowIndex++;
                        }

                        workbook.Write(ms);
                        ms.Flush();
                        ms.Position = 0;
                    }
                }
            }
            return ms;
        }

        public MemoryStream RenderToExcelByTemplate(System.Data.DataTable table, string filePathTemplate, List<int> hideIndexs)
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream stream = System.IO.File.OpenRead(filePathTemplate))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                {
                    ISheet sheet = workbook.GetSheetAt(0);
                    foreach (int i in hideIndexs.Where(o => o > -1))
                    {
                        sheet.SetColumnHidden(i, true);
                    }
                    {
                        //使用模板的标题
                        int rowIndex = sheet.LastRowNum + 1;
                        IRow titleRow = sheet.GetRow(0);
                        foreach (DataRow row in table.Rows)
                        {
                            IRow dataRow = sheet.CreateRow(rowIndex);
                            foreach (ICell titleCell in titleRow)
                            {
                                foreach (DataColumn column in table.Columns)
                                {
                                    if (column.ColumnName == titleCell.StringCellValue.Replace("\\n", ""))
                                    {
                                        ICell cell = dataRow.CreateCell(titleCell.ColumnIndex);
                                        switch (column.DataType.ToString())
                                        {
                                            case "System.Int16"://整型
                                            case "System.Int32":
                                            case "System.Int64":
                                                if (row[column].ToString() != "")//如果单元格不为空
                                                {
                                                    int intV;
                                                    int.TryParse(row[column].ToString(), out intV);
                                                    cell.SetCellValue(intV);
                                                }
                                                cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                                                break;
                                            case "System.Decimal"://浮点型
                                            case "System.Double":
                                                if (row[column].ToString() != "")//如果单元格不为空
                                                {
                                                    double doubV;
                                                    double.TryParse(row[column].ToString(), out doubV);
                                                    cell.SetCellValue(doubV);
                                                }
                                                break;
                                            case "System.DateTime":
                                                if (row[column] != null)//如果单元格不为空
                                                {
                                                    cell.SetCellValue(row[column].ToString().Replace(" 0:00:00", ""));
                                                }
                                                break;
                                            default:
                                                cell.SetCellValue(row[column].ToString());
                                                break;

                                        }

                                        cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                        cell.CellStyle.Alignment = HorizontalAlignment.Center;

                                    }
                                }
                            }
                            rowIndex++;
                        }
                        workbook.Write(ms);
                        ms.Flush();
                        ms.Position = 0;
                    }
                }
            }
            return ms;
        }

        public void OutputExcel(DataTable dt, string filePathTemplate, HttpContextBase context, string fileName, string hideColumns)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssff");
            }

            MemoryStream ms = new MemoryStream();
            string[] hideColumnsArry = hideColumns.Replace("Text","").Trim(',').Split(',');
            if (string.IsNullOrEmpty(filePathTemplate))
            {
                ms = RenderToExcel(dt);
                fileName = HttpUtility.UrlEncode(fileName) + ".xls";
            }
            else
            {
                ms = RenderToExcelByTemplate(dt, filePathTemplate, hideColumnsArry);
                fileName = HttpUtility.UrlEncode(fileName) + ".xlsx";
            }
            //if (context.Request.Browser.Browser == "IE")
            context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            context.Response.BinaryWrite(ms.ToArray());
        }

        public MemoryStream RenderToExcelByTemplate(System.Data.DataTable table, string filePathTemplate, string[] hideColumnsArry)
        {
            MemoryStream ms = new MemoryStream();
            using (FileStream stream = System.IO.File.OpenRead(filePathTemplate))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                {
                    ISheet sheet = workbook.GetSheetAt(0);
                    //使用模板的标题
                    int rowIndex = sheet.LastRowNum + 1;
                    IRow titleRow = sheet.GetRow(0);

                    foreach (string hideColumn in hideColumnsArry)
                    {
                        string hideColumnRes = hideColumn;
                        if (!string.IsNullOrEmpty(hideColumnRes) && string.Equals(hideColumnRes.Substring(0, 1), "_"))
                        {
                            hideColumnRes = hideColumnRes.Substring(1);
                        }
                        
                        foreach (ICell titleCell in titleRow)
                        {

                            if (hideColumnRes == titleCell.StringCellValue.Replace("\\n", ""))
                            {
                                sheet.SetColumnHidden(titleCell.ColumnIndex, true);
                            }
                        }
                    }
                    titleRow = sheet.GetRow(0);
                    foreach (DataRow row in table.Rows)
                    {
                        IRow dataRow = sheet.CreateRow(rowIndex);
                        foreach (ICell titleCell in titleRow)
                        {
                            foreach (DataColumn column in table.Columns)
                            {
                                if (column.ColumnName == titleCell.StringCellValue.Replace("\\n", ""))
                                {
                                    ICell cell = dataRow.CreateCell(titleCell.ColumnIndex);
                                    ICellStyle style11 = workbook.CreateCellStyle();
                                    switch (column.DataType.ToString())
                                    {
                                        case "System.Int16"://整型
                                        case "System.Int32":
                                        case "System.Int64":
                                            if (row[column].ToString() != "" && row[column] != DBNull.Value)//如果单元格不为空
                                            {
                                                int intV;
                                                int.TryParse(row[column].ToString(), out intV);
                                                cell.SetCellValue(intV);
                                            }
                                            //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
                                            break;
                                        case "System.Decimal"://浮点型
                                        case "System.Double":
                                            if (row[column].ToString() != "" && row[column] != DBNull.Value)//如果单元格不为空
                                            {
                                                double doubV;
                                                double.TryParse(row[column].ToString(), out doubV);
                                                cell.SetCellValue(doubV);
                                            }
                                            break;
                                        case "System.DateTime":
                                            if (row[column] != null && row[column]!=DBNull.Value)//如果单元格不为空
                                            {
                                                //ICellStyle cellStyle = workbook.CreateCellStyle();
                                                //IDataFormat format = workbook.CreateDataFormat();
                                                //cellStyle.DataFormat = format.GetFormat("yyyy-MM-dd");
                                                //cell.CellStyle = cellStyle;
                                                //style11.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy-MM-dd");
                                                DateTime dt = DateTime.Parse(row[column].ToString());
                                                cell.SetCellValue(dt.ToString("yyyy-MM-dd"));
                                            }
                                            break;
                                        default:
                                            cell.SetCellValue(row[column].ToString());
                                            break;

                                    }
                                    style11.BorderBottom = BorderStyle.Thin;
                                    style11.BorderLeft = BorderStyle.Thin;
                                    style11.BorderRight = BorderStyle.Thin;
                                    style11.BorderTop = BorderStyle.Thin;
                                    cell.CellStyle = style11;   
                                    cell.CellStyle.VerticalAlignment = VerticalAlignment.Center;
                                    cell.CellStyle.Alignment = HorizontalAlignment.Center;
                                }
                            }
                        }
                        rowIndex++;
                    }
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;
                }

            }
            return ms;
        }
    }
}
