using System.Collections.Generic;
using System.Linq;
namespace Ereceipt.Web.Logging
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly ILoggerStore _loggerStore;
        public LoggerRepository(ILoggerStore loggerStore)
        {
            _loggerStore = loggerStore;
        }
        public void AddToLogs(Log log) => _loggerStore.AddLog(log);
        public List<Log> GetAllLogs() => _loggerStore.GetAllLogs().OrderByDescending(x => x.RespondedOn).ToList();
        public List<Log> GetAllLogsByUserId(string userId)
            =>
            _loggerStore.GetAllLogs()
            .Where(x => x.User != null)
            .Where(x => x.User.Id == userId)
            .OrderByDescending(x => x.RespondedOn)
            .ToList();
        public List<Log> GetAllLogsByUsername(string username)
            =>
            _loggerStore.GetAllLogs()
            .Where(x => x.User != null)
            .Where(x => x.User.Username == username)
            .OrderByDescending(x => x.RespondedOn)
            .ToList();
        public Log GetLogById(string id) => _loggerStore.GetAllLogs().FirstOrDefault(x => x.Id == id);
    }
}