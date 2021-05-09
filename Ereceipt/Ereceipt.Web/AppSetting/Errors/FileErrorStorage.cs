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
            DownloadErrorsAsync().GetAwaiter().GetResult();
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
            _errors = GetSortedErrors(errors);
        }

        public async Task UploadErrorsAsync()
        {
            var contentToFile = JsonSerializer.Serialize(GetSortedErrors(ErrorSortBy.CodeAsc));
            await File.WriteAllTextAsync(_pathFile, contentToFile);
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
            var errorsByCategory = _errors
                .Where(x => x.Category == category)
                .ToList();
            return GetSortedErrors(errorsByCategory);
        }

        public List<ErrorViewModel> GetAllErrors() => GetSortedErrors();


        private bool IsExist(ErrorViewModel errorModel)
        {
            var error = _errors.FirstOrDefault(x => x.Code == errorModel.Code);
            if (error is null)
                return false;
            return true;
        }
        private List<ErrorViewModel> GetSortedErrors(ErrorSortBy sortBy = ErrorSortBy.CodeAsc) =>
            sortBy switch
            {
                ErrorSortBy.CodeAsc => _errors.OrderBy(x => x.Code).ToList(),
                ErrorSortBy.IdAsc => _errors.OrderBy(x=>x.Id).ToList(),
                ErrorSortBy.DateAsc => _errors.OrderBy(x => x.CreatedAt).ToList(),
                ErrorSortBy.CategoryAsc => _errors.OrderBy(x => x.Category).ToList(),
                ErrorSortBy.IdDesc => _errors.OrderByDescending(x => x.Id).ToList(),
                ErrorSortBy.DateDesc => _errors.OrderByDescending(x => x.CreatedAt).ToList(),
                ErrorSortBy.CodeDesc => _errors.OrderByDescending(x => x.Code).ToList(),
                ErrorSortBy.CategoryDesc => _errors.OrderByDescending(x => x.Category).ToList(),
                _=> _errors.OrderBy(x => x.Code).ToList()
            };

        private List<ErrorViewModel> GetSortedErrors(List<ErrorViewModel> errors, ErrorSortBy sortBy = ErrorSortBy.CodeAsc) =>
            sortBy switch
            {
                ErrorSortBy.CodeAsc => errors.OrderBy(x => x.Code).ToList(),
                ErrorSortBy.IdAsc => errors.OrderBy(x => x.Id).ToList(),
                ErrorSortBy.DateAsc => errors.OrderBy(x => x.CreatedAt).ToList(),
                ErrorSortBy.CategoryAsc => errors.OrderBy(x => x.Category).ToList(),
                ErrorSortBy.IdDesc => errors.OrderByDescending(x => x.Id).ToList(),
                ErrorSortBy.DateDesc => errors.OrderByDescending(x => x.CreatedAt).ToList(),
                ErrorSortBy.CodeDesc => errors.OrderByDescending(x => x.Code).ToList(),
                ErrorSortBy.CategoryDesc => errors.OrderByDescending(x => x.Category).ToList(),
                _ => errors.OrderBy(x => x.Code).ToList()
            };
    }

    public enum ErrorSortBy
    {
        IdAsc,
        DateAsc,
        CodeAsc,
        CategoryAsc,
        IdDesc,
        DateDesc,
        CodeDesc,
        CategoryDesc
    }
}