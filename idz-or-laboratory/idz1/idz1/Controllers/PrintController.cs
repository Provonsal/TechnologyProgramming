using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace idz1.Controllers
{
    public class PrintController : IPrintController, IDisposable
    {
        private bool disposed = false;
        public Out PrintHandler { get; set; }

        public Clear ClearHandler { get; set; }

        public string LogFilePath { get; set; }

        public PrintController(Out handler, Clear cleaner)
        {
            PrintHandler = handler;
            ClearHandler = cleaner;
            InitLoggerFile();
        }

        public event Clear? ClearAll;
        public event Out? Print;

        public void ArchiveLogFile()
        {
            const string LogExtension = "txt";
            const string ZipExtension = "zip";

            string? fileName = Path.GetFileNameWithoutExtension(LogFilePath);

            string zipArchiveName = $"{fileName}.{ZipExtension}";

            using (ZipArchive archive = ZipFile.Open(zipArchiveName, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(LogFilePath, $"{fileName}.{LogExtension}");
            }
        }

        public void InitLoggerFile()
        {
            const string extension = "txt";
            Regex regex = new(@"\s(\d+).");

            var test = Directory.GetFiles(".", "log *.txt");


            int maxLogNum = 1;

            foreach (var logFile in test)
            {
                Match match = regex.Match(logFile);

                if (!int.TryParse(match.Groups?[1].Value, out int logNum))
                {
                    continue;
                }

                if (match.Success && logNum > maxLogNum)
                {
                    maxLogNum = logNum;
                }
                else
                {
                    continue;
                }
            }
            LogFilePath = $"log {maxLogNum}.{extension}";

            FileInfo fileInfo = new(LogFilePath);
            if (fileInfo.Exists)
            {

                fileInfo.Delete();
                LogFilePath = $"log {maxLogNum+1}.{extension}";
                using var _ = File.Create(LogFilePath);
            }
            else
            {
                using var _ = fileInfo.Create();
            }
        }

        public void Logger(string message)
        {
            if (File.Exists(LogFilePath))
            {
                using (StreamWriter writer = File.AppendText(LogFilePath))
                {
                    writer.WriteLine(message + $" | {DateTime.Now}");
                }
            }
            else
            {
                throw new FileNotFoundException("Log file not found");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
                ArchiveLogFile();
            }
            // освобождаем неуправляемые объекты
            disposed = true;
        }

        ~PrintController(){
            Dispose(false);
        }
    }
}
