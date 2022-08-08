using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Logger;

namespace UserAPITests.Fakes
{
    public class LoggerManagerFake : ILoggerManager
    {
        public void LogDebug(string message)
        {
        }

        public void LogError(string message)
        {
        }

        public void LogInfo(string message)
        {
        }

        public void LogWarning(string message)
        {
        }
    }
}
