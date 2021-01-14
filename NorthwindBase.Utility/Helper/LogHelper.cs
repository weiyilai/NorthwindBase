using Dapper;
using Newtonsoft.Json;
using NLog;
using NorthwindBase.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBase.Utility.Helper
{
    public class LogHelper
    {
        /// <summary>
        /// 寫入log for Dapper
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        public static void Write(string sql, DynamicParameters param, string account)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            var list = new Dictionary<string, string>();

            foreach (var paramName in param.ParameterNames)
            {
                var value = Convert.ToString(param.Get<dynamic>(paramName));
                list.Add(paramName, value);
            }

            var content = string.Concat(new object[]
            {
                Environment.NewLine,
                "Sql：", Environment.NewLine, sql, Environment.NewLine,
                Environment.NewLine, "Parameters：", Environment.NewLine, 
                JsonConvert.SerializeObject(list), Environment.NewLine
            });

            // logger.Info(content);
            logger.LogExt(LogLevel.Info, content, account);
        }
    }
}
