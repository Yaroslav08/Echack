using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services
{
    public class ReceiptService : IReceiptService
    {
        private IReceiptRepository _ReceiptRepos;
        private IProductService _productService;
        private IMapper _mapper;
        public ReceiptService(IReceiptRepository ReceiptRepos, IMapper mapper, IProductService productService)
        {
            _ReceiptRepos = ReceiptRepos;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ReceiptResult> AddReceiptToGroup(ReceiptGroupCreateModel model)
        {
            var Receipt = await _ReceiptRepos.FindAsTrackingAsync(d => d.Id == model.ReceiptId);
            if (Receipt == null)
                return new ReceiptResult("Receipt not found");
            if (Receipt.UserId != model.UserId)
                return new ReceiptResult("Access Denited");
            if (Receipt.GroupId != null)
                return new ReceiptResult("Already in group");
            Receipt.GroupId = model.GroupId;
            Receipt.UpdatedAt = DateTime.UtcNow;
            Receipt.UpdatedBy = model.UserId.ToString();
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _ReceiptRepos.UpdateAsync(Receipt)));
        }

        public async Task<ReceiptResult> CreateReceipt(ReceiptCreateViewModel model)
        {
            var Receipt = new Receipt
            {
                ShopName = model.ShopName,
                IsImportant = model.IsImportant,
                UserId = model.UserId,
                GroupId = model.GroupId,
                ReceiptType = ReceiptType.Internal,
                Products = JsonSerializer.Serialize(model.Products),
                CreatedBy = model.UserId.ToString()
            };
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _ReceiptRepos.CreateAsync(Receipt)));
        }

        public async Task<ReceiptResult> EditReceipt(ReceiptEditViewModel model)
        {
            var Receipt = await _ReceiptRepos.FindAsTrackingAsync(d => d.Id == model.Id);
            if (Receipt == null)
                return new ReceiptResult("Receipt not found");
            if (Receipt.UserId != model.UserId)
                return new ReceiptResult("Access Denited");
            if (!Receipt.CanEdit)
                return new ReceiptResult("This receipt can`t be edit");
            Receipt.ShopName = model.ShopName;
            Receipt.IsImportant = model.IsImportant;
            Receipt.Products = JsonSerializer.Serialize(model.Products);
            Receipt.UpdatedAt = DateTime.Now;
            Receipt.UpdatedBy = model.UserId.ToString();
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _ReceiptRepos.UpdateAsync(Receipt)));
        }

        public async Task<ListReceiptResult> GetAllReceipts(int skip)
        {
            return new ListReceiptResult(_mapper.Map<List<ReceiptViewModel>>(await _ReceiptRepos.GetAllAsync(20, skip)));
        }

        public async Task<int> GetAllReceiptsCount()
        {
            return await _ReceiptRepos.CountAsync();
        }

        public async Task<ReceiptResult> GetReceipt(Guid id)
        {
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _ReceiptRepos.GetReceiptByIdAsync(id)));
        }

        public async Task<ListReceiptResult> GetUserReceiptsByUserId(int ownerId, int skip)
        {
            return new ListReceiptResult(_mapper.Map<List<ReceiptViewModel>>(await _ReceiptRepos.GetReceiptsByUserIdAsync(ownerId, skip)));
        }

        public async Task<int> GetUserReceiptsCount(int ownerId)
        {
            return await _ReceiptRepos.CountAsync(d => d.UserId == ownerId);
        }

        public async Task<ReceiptResult> RemoveReceipt(Guid id, int userId)
        {
            var receiptToDelete = await _ReceiptRepos.FindAsTrackingAsync(d => d.Id == id);
            if (receiptToDelete == null)
                return new ReceiptResult("Receipt not found");
            if (userId == 0)
            {
                return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _ReceiptRepos.RemoveAsync(receiptToDelete)));
            }
            if (receiptToDelete.UserId != userId)
                return null;
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _ReceiptRepos.RemoveAsync(receiptToDelete)));
        }

        public async Task<ReceiptResult> RemoveReceiptFromGroup(ReceiptGroupCreateModel model)
        {
            var Receipt = await _ReceiptRepos.FindAsTrackingAsync(d => d.Id == model.ReceiptId);
            if (Receipt == null)
                return new ReceiptResult("Receipt not found");
            if (Receipt.UserId != model.UserId)
                return new ReceiptResult("Access Denited");
            if (Receipt.GroupId != model.GroupId)
                return new ReceiptResult("GroupId not valid");
            Receipt.GroupId = null;
            Receipt.UpdatedAt = DateTime.Now;
            Receipt.UpdatedBy = model.UserId.ToString();
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _ReceiptRepos.UpdateAsync(Receipt)));
        }
    }
}