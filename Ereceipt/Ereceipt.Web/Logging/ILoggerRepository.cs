using System.Collections.Generic;
using System.Linq;
namespace Ereceipt.Web.Logging
{
    public interface ILoggerRepository
    {
        void AddToLogs(Log log);
        Log GetLogById(string id);
        List<Log> GetAllLogsByUserId(string userId);
        List<Log> GetAllLogsByUsername(string username);
        List<Log> GetAllLogs();
    }
    public class LoggerRepository : ILoggerRepository
    {
        private readonly ILoggerStore _loggerStore;
        public LoggerRepository(ILoggerStore loggerStore)
        {
            _loggerStore = loggerStore;
        }

        public void AddToLogs(Log log) => _loggerStore.Logs.Add(log);
        public List<Log> GetAllLogs() => _loggerStore.Logs.OrderByDescending(x => x.RespondedOn).ToList();
        public List<Log> GetAllLogsByUserId(string userId)
            =>
            _loggerStore.Logs
            .Where(x => x.User != null)
            .Where(x => x.User.Id == userId)
            .OrderByDescending(x => x.RespondedOn)
            .ToList();
        public List<Log> GetAllLogsByUsername(string username)
            =>
            _loggerStore.Logs
            .Where(x => x.User != null)
            .Where(x => x.User.Username == username)
            .OrderByDescending(x => x.RespondedOn)
            .ToList();
        public Log GetLogById(string id) => _loggerStore.Logs.FirstOrDefault(x => x.Id == id);
    }
    public interface ILoggerStore
    {
        List<Log> Logs { get; }
    }
    public class LoggerStore : ILoggerStore
    {
        private readonly List<Log> _logs;
        public LoggerStore()
        {
            _logs = new List<Log>();
        }
        public List<Log> Logs { get => _logs; }
    }
}