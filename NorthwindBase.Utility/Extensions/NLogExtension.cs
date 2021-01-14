using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBase.Utility.Extensions
{
    public static class NLogExtension
    {
        public static void LogExt(this NLog.Logger logger, NLog.LogLevel level, string message, string userName, string functional)
        {
            NLog.LogEventInfo theEvent = new NLog.LogEventInfo(level, logger.Name, message);
            theEvent.Properties["UserName"] = userName;
            theEvent.Properties["Functional"] = functional;
            logger.Log(theEvent);
        }
    }
}
