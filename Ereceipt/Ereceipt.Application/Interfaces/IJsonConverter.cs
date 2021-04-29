using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IJsonConverter
    {
        string GetStringAsJson<T>(T model);
        string GetStringAsJson(object model);
        T GetModelFromJson<T>(string json);
    }
}