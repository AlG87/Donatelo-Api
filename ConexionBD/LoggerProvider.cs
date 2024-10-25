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
        private static readonly Lazy<LoggerProvider> instance = new Lazy<LoggerProvider>(() => new LoggerProvider());
        private readonly string logFilePath;

        private LoggerProvider()
        {
            logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Dispose();
            }
        }
        public static void Information(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }
        public static LoggerProvider Instance => instance.Value;
        public static void Fatal(string message)
        {
            Instance.Log($"FATAL: {message}");
        }
        public void Log(string message)
        {
            try
            {
                using (var writer = new StreamWriter(logFilePath, true))
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
