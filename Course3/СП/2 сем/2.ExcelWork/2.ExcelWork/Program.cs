using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using GemBox.Spreadsheet;
using OfficeOpenXml;//EPPlus
using Excel = Microsoft.Office.Interop.Excel;

namespace _2.ExcelWork
{
    class Program
    {
        private const string fileNameInterop = "fileInterop.xlsx";
        private const string fileNameGemBox = "fileGemBox.xls";
        public const string fileNameEpPlus = "fileEPPlus.xlsx";

        static void Main()
        {
            Console.Write("Что используем?\n1 - Excel Interop\n2 - GemBox.SpreadSheet\n3 - EPPlus\n4 - Сравнение\n5 - Потоки\n0 - Выход\nВведите номер операции: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddInterop();
                    break;
                case 2:
                    AddGemBox();
                    break;
                case 3:
                    AddEppPlus();
                    break;
                case 4:
                    Test();
                    break;
                case 5:
                    Threads();
                    break;
                case 0:
                    Environment.Exit(1);
                    break;

            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void Test()
        {
            var libraries = new Dictionary<string, long>();
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            AddInterop();
            stopwatch.Stop();
            libraries.Add("Excel Interop", stopwatch.ElapsedMilliseconds);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            AddEppPlus();
            stopwatch.Stop();
            libraries.Add("EPPlus", stopwatch.ElapsedMilliseconds);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            AddGemBox();
            stopwatch.Stop();
            libraries.Add("GemBox.SpreadSheet", stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\nРезультаты сравнения\n");
            KeyValuePair<string, long> value;
            for (int i = 0; i < 3; i++)
            {
                value = libraries.FirstOrDefault();
                foreach (var library in libraries)
                {
                    if (library.Value < value.Value)
                    {
                        value = library;
                    }
                }
                libraries.Remove(value.Key);
                Console.WriteLine("{0}. {1}. Время: {2}мс", i + 1, value.Key, value.Value);
            }
        }

        static void Threads()
        {
            var thread1 = new MyThread("Thread1");
            var thread2 = new MyThread("Thread2");

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        static void AddInterop()
        {
            RemoveFile(fileNameInterop);

            var excelApp = new Excel.Application { Visible = false };
            Excel.Workbook myBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            var mySheet = (Excel.Worksheet)myBook.Sheets[1];
            mySheet.Cells[1, 1] = 1;
            mySheet.Cells[1, 2] = 2;
            mySheet.Cells[1, 3] = "=A1+B1";

            myBook.SaveAs(Environment.CurrentDirectory + "\\" + fileNameInterop);
            myBook.Close();
        }

        static void AddEppPlus()
        {
            RemoveFile(fileNameEpPlus);
            var newFile = new FileInfo(fileNameEpPlus);
            var excelPackage = new ExcelPackage(newFile);
            var worksheet = excelPackage.Workbook.Worksheets.Add("1");
            worksheet.Cells["A1"].Value = 1;
            worksheet.Cells["B1"].Value = 2;
            worksheet.Cells["C1"].Formula = "=A1+B1";
            excelPackage.Save();
        }

        static void AddGemBox()
        {
            RemoveFile(fileNameGemBox);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var excelFile = new ExcelFile();
            var worksheet = excelFile.Worksheets.Add("Book1");

            worksheet.Cells[0, 0].Value = 1;
            worksheet.Cells[0, 1].Value = 2;
            worksheet.Cells[0, 2].Formula = "=A1+B1";

            excelFile.Save(fileNameGemBox);
        }

        static void RemoveFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
