﻿using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IReceiptService
    {
        Task<ReceiptResult> CreateReceiptAsync(ReceiptCreateViewModel model);
        Task<ReceiptResult> EditReceiptAsync(ReceiptEditViewModel model);
        Task<ReceiptResult> GetReceiptAsync(Guid id);
        Task<ListReceiptResult> GetUserReceiptsByUserIdAsync(int ownerId, int skip);
        Task<int> GetUserReceiptsCountAsync(int ownerId);
        Task<ReceiptResult> AddReceiptToGroupAsync(ReceiptGroupCreateModel model);
        Task<ReceiptResult> RemoveReceiptFromGroupAsync(ReceiptGroupCreateModel model);
        Task<ListReceiptResult> GetAllReceiptsAsync(int skip);
        Task<int> GetAllReceiptsCountAsync();
        Task<ReceiptResult> RemoveReceiptAsync(Guid id, int userId);
    }
}