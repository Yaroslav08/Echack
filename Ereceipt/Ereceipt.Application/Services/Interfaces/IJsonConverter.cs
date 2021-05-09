namespace Ereceipt.Application.Services.Interfaces
{
    public interface IJsonConverter
    {
        string GetStringAsJson<T>(T model);
        string GetStringAsJson(object model);
        T GetModelFromJson<T>(string json);
    }
}