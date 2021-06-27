using System.Collections.Generic;
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
}