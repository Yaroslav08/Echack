using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ereceipt.Web.AppSetting.Errors
{
    public interface IErrorStorage
    {
        Task DownloadErrorsAsync();
        Task UploadErrorsAsync();
        void AddNewError(ErrorViewModel error);
        void UpdateError(ErrorViewModel error);
        ErrorViewModel GetErrorById(string id);
        ErrorViewModel GetErrorByCode(string code);
        List<ErrorViewModel> GetErrorsByCategory(string category);
    }
}