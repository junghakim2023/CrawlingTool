using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using OpenQA.Selenium;

namespace CrawlingTool
{
    class ExcelManager{
        IXLWorksheet worksheet;
        public ExcelManager(String fileName, int sheetNumber){
            var workbook = new XLWorkbook(fileName);
            worksheet = workbook.Worksheet(sheetNumber);
        }

        public String ReadExcel(int row, int column){
            var rowData = worksheet.Row(row);
            var cell = rowData.Cell(column);
            String value = cell.GetValue<String>();
            return value;
        }

        public int GetRowCount(){
            return worksheet.LastRowUsed().RowNumber();
        }

        public void ExcelDataToList(FileInfo file){
            List<String> list = new List<String>();
            String fileName = file.FullName;              
            var excel = new ExcelManager(fileName, 1);

            int rowCount = excel.GetRowCount();
            for (int i = 2; i <= rowCount; i++){
                for (int j = 1; j < 2; j++) {
                    var info = excel.ReadExcel(i, 1);
                    list.Add(info);
                }
               
            }
        }
    }
}
