using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmOperations
{
    public class ConsoleLogger : ILogger
    {
    public void Log(string message, Customer c) => Console.WriteLine(message);
    }
}
