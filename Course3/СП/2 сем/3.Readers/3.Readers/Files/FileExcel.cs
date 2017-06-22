using System;
using System.Data;
using System.IO;
using GemBox.Spreadsheet;

namespace _3.Readers.Files
{
    public class FileExcel : FileBase
    {
        private readonly int maxTableRank;
        
        public FileExcel(int maxTableRank)
        {
            this.maxTableRank = maxTableRank;
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        }
        
        public override string[, ] Open(string fileName)
        {
            var dataTable = new string[maxTableRank, maxTableRank];
            ExcelWorksheet worksheet = GetExcelWorksheet(fileName);
            if (worksheet != null)
            {
                CurrentFileName = fileName;
                for (int row = 0; row < maxTableRank; row++)
                {
                    for (int column = 0; column < maxTableRank; column++)
                    {
                        dataTable[row, column] = Convert.ToString(worksheet.Cells[row, column].Value);
                    }
                }
            }
            return dataTable;
        }

        public override void Save(string[,] collection, string fileName)
        {
            var excelFile = new ExcelFile();
            if (excelFile.Worksheets.Count == 0)
            {
                excelFile.Worksheets.Add("Sheet1");
            }
            ExcelWorksheet worksheet = excelFile.Worksheets[0];
            if (worksheet != null)
            {
                for (int i = 0; i < collection.GetLength(0); i++)
                {
                    for (int j = 0; j < collection.GetLength(1); j++)
                    {
                        worksheet.Cells[i, j].Value = collection[i, j];
                    }
                }
                base.Save(collection, fileName);
                excelFile.Save(fileName);
            }
        }

        private ExcelWorksheet GetExcelWorksheet(string fileName)
        {
            if (File.Exists(fileName))
            {
                var excelFile = ExcelFile.Load(fileName);
                if (excelFile.Worksheets.Count == 0)
                {
                    excelFile.Worksheets.Add("Sheet1");
                }
                return excelFile.Worksheets[0];
            }
            return null;
        }

        public DataView ToDataView(string[,] table)
        {
            var dataTable = GetDataTable();
            for (int row = 0; row < maxTableRank; row++)
            {
                for (int column = 0; column < maxTableRank; column++)
                {
                    dataTable.Rows[row][column] = table[row, column];
                }
                dataTable.AcceptChanges();
            }
            return dataTable.DefaultView;
        }

        /// <summary>
        /// Возвращает DataTable, который будет затем использован в DataGrid
        /// Здесь добавляется количество строк и столбцов равное значению MaxTableRank
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTable()
        {
            var dataTable = new DataTable();
            const char firstColumnName = 'A';
            var lastColumnName = (char)(firstColumnName + maxTableRank);
            for (char columnHeader = firstColumnName; columnHeader < lastColumnName; columnHeader++)
            {
                dataTable.Columns.Add(columnHeader.ToString());
            }

            while (dataTable.Rows.Count < maxTableRank)
            {
                dataTable.Rows.Add("");
            }
            return dataTable;
        }
    }
}
