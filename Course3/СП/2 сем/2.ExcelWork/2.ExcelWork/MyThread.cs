using System.IO;
using System.Threading;
using OfficeOpenXml;

namespace _2.ExcelWork
{
    class MyThread
    {
        protected Thread thread;

        public MyThread(string name)
        {
            thread = new Thread(SaveFile) { Name = name };
        }

        public void SaveFile()
        {
            var newFile = new FileInfo(Program.fileNameEpPlus);
            var excelPackage = new ExcelPackage(newFile);
            var worksheet = excelPackage.Workbook.Worksheets["1"];
            worksheet.Cells["A1"].Value = Thread.CurrentThread.Name;
            excelPackage.Save();
        }

        public void Start()
        {
            if (thread.ThreadState == ThreadState.Unstarted)
            {
                thread.Start();
            }
        }

        public void Join()
        {
            thread.Join();
        }

    }
}
