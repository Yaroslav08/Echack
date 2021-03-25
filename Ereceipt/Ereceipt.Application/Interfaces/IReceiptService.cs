using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IReceiptService
    {
        Task<ReceiptViewModel> CreateReceipt(ReceiptCreateViewModel model);
        Task<ReceiptViewModel> EditReceipt(ReceiptEditViewModel model);
        Task<ReceiptViewModel> GetReceipt(Guid id);
        Task<List<ReceiptViewModel>> GetUserReceiptsByUserId(int ownerId, int skip);
        Task<int> GetUserReceiptsCount(int ownerId);
        Task<ReceiptViewModel> AddReceiptToGroup(ReceiptGroupCreateModel model);
        Task<ReceiptViewModel> RemoveReceiptFromGroup(ReceiptGroupCreateModel model);
        Task<List<ReceiptViewModel>> GetAllReceipts(int skip);
        Task<int> GetAllReceiptsCount();
    }
}