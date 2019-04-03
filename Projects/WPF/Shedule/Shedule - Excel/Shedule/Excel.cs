using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace Shedule
{
    public static class Excel
    {
        private static Application Excelapp = new Application();
        private static Worksheet excelworksheet;

        public static void OpenShedule(string fileName)
        {
            OpenExcel(fileName);
            string initialCell = FindStart();
            XML.Save(GetShedule(initialCell));
            CloseExcel();
        }

        private static void OpenExcel(string fileName)
        {
            excelworksheet =
                (Worksheet)
                    Excelapp.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
                        .Worksheets.Item[1];
        }

        /// <summary>
        /// Возвратит координаты стартовой ячейки
        /// </summary>
        /// <returns></returns>
        private static string FindStart()
        {
            const string sheduleStart = "пн";//с надписи "пн" начинается расписание
            for (char column = 'A'; column < 'Z'; column++)
            {
                for (int startingRowNumber = 1; startingRowNumber < Excelapp.Rows.Count; startingRowNumber++)
                {
                    string valueFromCell = excelworksheet.Range[String.Format("{0}{1}", column, startingRowNumber), Type.Missing].Value2;
                    if (valueFromCell == sheduleStart)
                    {
                        return (Convert.ToString(column) + Convert.ToString(startingRowNumber));
                    }
                    if(valueFromCell == null)
                    {
                        return null;
                    }
                }
            }
            return null;
        }
        private static List<Period> GetShedule(string initialCell)
        {
            var newShedule = new List<Period>();
            try
            {
                char column;
                for (int row = Convert.ToInt32(Convert.ToString(initialCell[1])); row < Excelapp.Rows.Count; row++)
                {
                    column = initialCell[0];
                    string day = GetInfoFromExcelCell(row, column++);
                    string weeks = GetInfoFromExcelCell(row, column++);
                    string time = GetInfoFromExcelCell(row, column++);
                    string subgroup = GetInfoFromExcelCell(row, column++);
                    string discipline = GetInfoFromExcelCell(row, column++);
                    string type = GetInfoFromExcelCell(row, column++);
                    string auditorium = GetInfoFromExcelCell(row, column++);
                    string teacher = GetInfoFromExcelCell(row, column);
                    if (IsAllNotNull(day, weeks, time, subgroup, discipline, type, auditorium, teacher))
                    {
                        newShedule.Add(new Period(day, weeks, time, subgroup, discipline, type, auditorium, teacher));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (NullReferenceException)
            {
                newShedule = new List<Period>();
            }
            return newShedule;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr processId);
        private static void CloseExcel()
        {
            var hwnd = new IntPtr(Excelapp.Hwnd);
            IntPtr processId;
            GetWindowThreadProcessId(hwnd, out processId);
            Process proc = Process.GetProcessById(processId.ToInt32());
            proc.Kill();

            Excelapp = new Application();
            excelworksheet = new Worksheet();
        }

        private static string GetInfoFromExcelCell(int row, char column)
        {
            return Convert.ToString(excelworksheet.Range[String.Format("{0}{1}", column, row), Type.Missing].Value2);
        }

        private static bool IsAllNotNull(params string[] array)
        {
            return array.All(str => str != null);
        }
    }
}
