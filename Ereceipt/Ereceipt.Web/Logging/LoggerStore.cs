using System.Collections.Generic;
using System.Linq;

namespace Ereceipt.Web.Logging
{
    public class LoggerStore : ILoggerStore
    {
        private readonly List<Log> _logs;
        public LoggerStore()
        {
            _logs = new List<Log>();
        }
        public void AddLog(Log log)
        {
            _logs.Add(log);
        }
        public List<Log> GetAllLogs(int skip = 0, int count = 20) =>
            _logs.OrderByDescending(x => x.RespondedOn).Skip(skip).Take(count).ToList();
    }
}