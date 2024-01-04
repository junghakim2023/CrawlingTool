using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace CrawlingTool
{
    class ExcelManager
    {
        IXLWorksheet worksheet;
        public ExcelManager(String fileName, int sheetNumber)
        {
            var workbook = new XLWorkbook(fileName);
            worksheet = workbook.Worksheet(sheetNumber);
        }

        public String ReadExcel(int row, int column)
        {
            var rowData = worksheet.Row(row);
            var cell = rowData.Cell(column);
            String value = cell.GetValue<String>();
            return value;
        }

        public int GetRowCount()
        {
            return worksheet.LastRowUsed().RowNumber();
        }
    }
}
