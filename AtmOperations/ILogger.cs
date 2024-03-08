using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmOperations
{
    public interface ILogger
    {
        void Log(string message, Customer customer);
    }
}
