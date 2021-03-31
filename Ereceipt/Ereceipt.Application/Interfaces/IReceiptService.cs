using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IReceiptService
    {
        Task<ReceiptResult> CreateReceipt(ReceiptCreateViewModel model);
        Task<ReceiptResult> EditReceipt(ReceiptEditViewModel model);
        Task<ReceiptResult> GetReceipt(Guid id);
        Task<ListReceiptResult> GetUserReceiptsByUserId(int ownerId, int skip);
        Task<int> GetUserReceiptsCount(int ownerId);
        Task<ReceiptResult> AddReceiptToGroup(ReceiptGroupCreateModel model);
        Task<ReceiptResult> RemoveReceiptFromGroup(ReceiptGroupCreateModel model);
        Task<ListReceiptResult> GetAllReceipts(int skip);
        Task<int> GetAllReceiptsCount();
        Task<ReceiptResult> RemoveReceipt(Guid id, int userId);
    }
}