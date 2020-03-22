using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epplus
{
    public class Leitura
    {
        public void Processar()
        {
            string path = ConfigurationManager.AppSettings["diretorioExcel"].ToString();
            FileInfo fileInfo = new FileInfo(path);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            // get number of rows and columns in the sheet
            int rows = worksheet.Dimension.Rows; // 20
            int columns = worksheet.Dimension.Columns; // 7

            // loop through the worksheet rows and columns
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    string content = worksheet.Cells[i, j].Value.ToString();
                    Console.Write(content + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
