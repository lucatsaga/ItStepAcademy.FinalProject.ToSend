using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmOperations
{
    public class FileLogger

    {

        private const string _filePath = @"../../../FileLogger.txt";

        public static void Log(string message, Customer customer)
        {
            string logEntry = $"{DateTime.Now}: {message}";

           
            using (StreamWriter sw = new StreamWriter(_filePath, true, Encoding.UTF8))
            {
                sw.WriteLine(logEntry);
                sw.Write("\n"); 
            }
        }

    }
}
