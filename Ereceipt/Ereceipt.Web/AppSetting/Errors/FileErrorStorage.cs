using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ereceipt.Web.AppSetting.Errors
{
    public class FileErrorStorage : IErrorStorage
    {
        private readonly string _pathFile = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Errors.json");
        private List<ErrorViewModel> _errors;
        public FileErrorStorage()
        {
            _errors = new List<ErrorViewModel>();
        }

        public void AddNewError(ErrorViewModel error)
        {
            if (IsExist(error))
                return;
            error.Id = Guid.NewGuid().ToString("N");
            _errors.Add(error);
        }

        public void UpdateError(ErrorViewModel error)
        {
            var errorToUpdate = _errors.FirstOrDefault(x => x.Id == error.Id || x.Code == error.Code);
            if(errorToUpdate is null)
            {
                AddNewError(error);
                return;
            }
            errorToUpdate.DescriptionEN = error.DescriptionEN;
            errorToUpdate.DescriptionRU = error.DescriptionRU;
            errorToUpdate.DescriptionUA = error.DescriptionUA;
            var indexOfError = _errors.IndexOf(errorToUpdate);
            _errors[indexOfError] = errorToUpdate;
        }

        public async Task DownloadErrorsAsync()
        {
            if (!File.Exists(_pathFile))
                File.Create(_pathFile);
            var contentFromFile = await File.ReadAllTextAsync(_pathFile);
            if (string.IsNullOrWhiteSpace(contentFromFile))
                return;
            var errors = JsonSerializer.Deserialize<List<ErrorViewModel>>(contentFromFile);
            _errors.Clear();
            _errors = errors.OrderBy(x => x.Code).ToList();
        }

        public async Task UploadErrorsAsync()
        {
            using var sw = new StreamWriter(_pathFile);
            var contentToFile = JsonSerializer.Serialize(_errors.OrderBy(x => x.Code).ToList());
            await sw.WriteLineAsync(contentToFile);
            sw.Dispose();
        }

        private bool IsExist(ErrorViewModel errorModel)
        {
            var error = _errors.FirstOrDefault(x => x.Code == errorModel.Code);
            if (error is null)
                return false;
            return true;
        }

        public ErrorViewModel GetErrorById(string id)
        {
            return _errors.FirstOrDefault(x => x.Id == id);
        }

        public ErrorViewModel GetErrorByCode(string code)
        {
            return _errors.FirstOrDefault(x => x.Code == code);
        }

        public List<ErrorViewModel> GetErrorsByCategory(string category)
        {
            return _errors
                .Where(x => x.Category == category)
                .OrderBy(x => x.Code)
                .ToList();
        }

        public List<ErrorViewModel> GetAllErrors() =>
            _errors.OrderBy(x => x.Code).ToList();
    }
}