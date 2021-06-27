using System.Collections.Generic;
namespace Ereceipt.Web.Logging
{
    public interface ILoggerStore
    {
        void AddLog(Log log);
        List<Log> GetAllLogs(int skip = 0, int count = 20);
    }
}