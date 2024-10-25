using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    using System;
    using System.IO;

    public class LoggerProvider
    {
        private static readonly Lazy<LoggerProvider> _instance = new Lazy<LoggerProvider>(() => new LoggerProvider());
        private readonly string _logFilePath;

        private LoggerProvider()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");
            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Dispose();
            }
        }
        public static void Information(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }
        public static LoggerProvider Instance => _instance.Value;
        public static void Fatal(string message)
        {
            Instance.Log($"FATAL: {message}");
        }
        public void Log(string message)
        {
            try
            {
                using (var writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el log: {ex.Message}");
            }
        }
        public void Error(string message)
        {
            Log($"ERROR: {message}");
        }

        public void Warn(string message)
        {
            Log($"WARN: {message}");
        }

        public void Info(string message)
        {
            Log($"INFO: {message}");
        }
    }

}
