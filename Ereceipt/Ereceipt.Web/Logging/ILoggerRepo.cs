using System.Collections.Generic;
using System.Linq;
namespace Ereceipt.Web.Logging
{
    public interface ILoggerRepo
    {
        void AddToLogs(Log log);
        Log GetLogById(string id);
        List<Log> GetAllLogs();
    }
    public class LoggerRepo : ILoggerRepo
    {
        public void AddToLogs(Log log) => LoggerStore.Logs.Add(log);
        public List<Log> GetAllLogs() => LoggerStore.Logs.OrderByDescending(x => x.RespondedOn).ToList();
        public Log GetLogById(string id) => LoggerStore.Logs.FirstOrDefault(x => x.Id == id);
    }
    public class LoggerStore
    {
        public static List<Log> Logs = new List<Log>();
    }
}