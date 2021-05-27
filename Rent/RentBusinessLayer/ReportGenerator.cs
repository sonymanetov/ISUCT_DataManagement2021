using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Rent_Dto;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace RentBusinessLayer
{
    public class ReportGenerator : IReportGenerator
    {
        public void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile)
        {
            if (grid != null)
            {
                //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage pck = new ExcelPackage(xlsxFile);
                var excel = pck.Workbook.Worksheets.Add(status);
                int x = 1;
                int y = 1;
               
            CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                excel.Cells["A1: Z1"].Style.Font.Bold = true;
                excel.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                excel.Cells.Style.Numberformat.Format = "General";

                 Object dtObj = new Object();
                                switch (status)
                                {
                                    case "Client":
                                    dtObj = new ClientDto();
                                        break;
                                    case "Room":
                                    dtObj = new RoomDto();
                                        break;

                                }

                foreach (var prop in dtObj.GetType().GetProperties())
                {
                    excel.Cells[y, x].Value = prop.Name.Trim();
                    x++;
                }
                // Генерация строк-записей таблицы.
                foreach (var item in grid)
                {
                    y++;
                    // Объект-контейнер для текущего читаемого элемента.
                    Object itemObj = item;
                    x = 1;
                    foreach (var prop in itemObj.GetType().GetProperties())
                    {
                        object t = prop.GetValue(itemObj, null);
                        object val;
                        if (t == null)
                            val = " ";
                        else
                        {
                            val = t.ToString();
                        }

                            excel.Cells[y, x].Value = val;
                        x++;
                    }
                }
                // Устанавливаем размер колонок по ширине содержимого.
                excel.Cells.AutoFitColumns();
                // Сохраняем файл.
                pck.Save();
            }
            else MessageBox.Show("Данные не загружены");
        }
    }
}
