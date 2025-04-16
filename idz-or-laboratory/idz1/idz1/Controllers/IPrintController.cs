using System;

namespace idz1.Controllers
{
    public delegate void Out(string message);

    public delegate void Clear();

    public interface IPrintController : IDisposable
    {

        public Clear ClearHandler { get; set; }

        public Out PrintHandler { get; set; }

        public string LogFilePath { get; set; }

        public void Logger(string message);

        public event Clear? ClearAll;

        public event Out? Print;
    }
}
