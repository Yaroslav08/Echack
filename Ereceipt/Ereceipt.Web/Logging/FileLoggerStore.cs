using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace Ereceipt.Web.Logging
{
    public class FileLoggerStore : ILoggerStore
    {
        private readonly string FileName = "Logs.json";
        private readonly List<Log> _logs;
        private void CheckDirectory()
        {
            if (!File.Exists(FileName))
            {
                File.Create(FileName);
            }
        }
        public FileLoggerStore()
        {
            CheckDirectory();
            using var sr = new StreamReader(FileName);
            var content = sr.ReadToEnd();
            if (string.IsNullOrEmpty(content))
            {
                _logs = new List<Log>();
                return;
            }
            _logs = JsonSerializer.Deserialize<List<Log>>(content);
        }
        public void AddLog(Log log)
        {
            _logs.Add(log);
            CheckDirectory();
            using var sw = new StreamWriter(FileName);
            sw.Write(JsonSerializer.Serialize(_logs));
        }
        public List<Log> GetAllLogs(int skip = 0, int count = 20) =>
            _logs.OrderByDescending(x => x.RespondedOn).Skip(skip).Take(count).ToList();
    }
}