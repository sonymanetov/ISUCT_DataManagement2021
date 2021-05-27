using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Rent_Dto;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;
using System.Windows.Forms;

namespace RentBusinessLayer
{
    public interface IReportGenerator
    {
       void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile);
    }
}
