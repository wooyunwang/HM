using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace HM.Utils_
{
    public class ExcelHelper
    {

        public static void Export(DataTable dt, string filename, string title, string[] colums, string[] alias)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(title);
            IRow headrow = sheet.CreateRow(0);
            int j = 0;
            foreach (string col in colums)
            {
                headrow.CreateCell(j++, CellType.String).SetCellValue(col);
            }


            int i = 1;

            foreach (DataRow datarow in dt.Rows)
            {
                IRow row = sheet.CreateRow(i++);
                j = 0;
                foreach (string alia in alias)
                {
                    row.CreateCell(j++, CellType.String).SetCellValue(datarow[alia].ToString());
                }
            }

            FileStream filestream = new FileStream(filename, FileMode.Create);
            workbook.Write(filestream);
            filestream.Close();
            workbook.Dispose();

            Process.Start(filename);

        }




        public static string ReadStringCell(int ix, IRow row)
        {
            try
            {
                ICell cell = row.GetCell(ix, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                if (cell == null) return "";

                if (cell.CellType == CellType.Numeric)
                {
                    return cell.NumericCellValue.ToString();
                }
                else if (cell.CellType == CellType.String)
                {
                    return cell.StringCellValue;
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        public static string ReadStrDateCell(int ix, IRow row)
        {
            DateTime? dt = ReadDateCell(ix, row);
            if (dt != null && dt.HasValue)
            {
                return string.Format("{0:yyyy-MM-dd}", dt.Value);
            }
            return "";
        }

        public static DateTime? ReadDateCell(int ix, IRow row)
        {
            try
            {
                ICell cell = row.GetCell(ix, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                if (cell != null)
                {
                    if (cell.CellType == CellType.Numeric)
                    {
                        return cell.DateCellValue;
                    }
                    else if (cell.CellType == CellType.String)
                    {
                        DateTime dt;
                        if (DateTime.TryParse(cell.StringCellValue, out dt))
                        {
                            return dt;
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        public static decimal ReadDecimalCell(int ix, IRow row)
        {
            try
            {
                ICell cell = row.GetCell(ix, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                if (cell != null)
                {
                    if (cell.CellType == CellType.Numeric)
                    {
                        return Convert.ToDecimal(cell.NumericCellValue);
                    }
                    else if (cell.CellType == CellType.String)
                    {
                        return Convert.ToDecimal(cell.StringCellValue);
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public static int ReadIntCell(int ix, IRow row)
        {
            try
            {
                ICell cell = row.GetCell(ix, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                if (cell != null)
                {
                    if (cell.CellType == CellType.Numeric)
                    {
                        return Convert.ToInt32(cell.NumericCellValue);
                    }
                    else if (cell.CellType == CellType.String)
                    {
                        return Convert.ToInt32(cell.StringCellValue);
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public static long ReadLongCell(int ix, IRow row)
        {
            try
            {
                ICell cell = row.GetCell(ix, MissingCellPolicy.RETURN_NULL_AND_BLANK);
                if (cell != null)
                {
                    if (cell.CellType == CellType.Numeric)
                    {
                        return Convert.ToInt64(cell.NumericCellValue);
                    }
                    else if (cell.CellType == CellType.String)
                    {
                        return Convert.ToInt64(cell.StringCellValue);
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }



    }
}
