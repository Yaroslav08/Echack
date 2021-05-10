using Ereceipt.Application.Results;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<ReceiptResult> CreateReceiptAsync(ReceiptCreateModel model);
        Task<ReceiptResult> EditReceiptAsync(ReceiptEditModel model);
        Task<ReceiptResult> GetReceiptAsync(Guid id);
        Task<ListReceiptResult> GetUserReceiptsByUserIdAsync(int ownerId, int skip);
        Task<CountResult> GetUserReceiptsCountAsync(int ownerId);
        Task<ReceiptResult> AddReceiptToGroupAsync(ReceiptGroupCreateModel model);
        Task<ReceiptResult> RemoveReceiptFromGroupAsync(ReceiptGroupCreateModel model);
        Task<ListReceiptResult> GetAllReceiptsAsync(int skip);
        Task<CountResult> GetAllReceiptsCountAsync();
        Task<ReceiptResult> RemoveReceiptAsync(Guid id, int userId);
    }
}