using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<ReceiptViewModel> AddReceiptToGroup(ReceiptGroupCreateModel model)
        {
            var Receipt = await _ReceiptRepos.FindAsTrackingAsync(d => d.Id == model.ReceiptId);
            if (Receipt == null)
                return null;
            if (Receipt.UserId != model.UserId)
                return null;
            if (Receipt.GroupId != null)
                return null;
            Receipt.GroupId = model.GroupId;
            Receipt.UpdatedAt = DateTime.UtcNow;
            Receipt.UpdatedBy = model.UserId.ToString();
            return _mapper.Map<ReceiptViewModel>(await _ReceiptRepos.UpdateAsync(Receipt));
        }

        public async Task<ReceiptViewModel> CreateReceipt(ReceiptCreateViewModel model)
        {
            var Receipt = new Receipt
            {
                ShopName = model.ShopName,
                IsImportant = model.IsImportant,
                UserId = model.UserId,
                GroupId = model.GroupId,
                ReceiptType = ReceiptType.Internal,
                Products = JsonSerializer.Serialize(model.Products),
                TotalPrice = _productService.GetSum(model.Products),
                CreatedBy = model.UserId.ToString()
            };
            return _mapper.Map<ReceiptViewModel>(await _ReceiptRepos.CreateAsync(Receipt));
        }

        public async Task<ReceiptViewModel> EditReceipt(ReceiptEditViewModel model)
        {
            var Receipt = await _ReceiptRepos.FindAsTrackingAsync(d => d.Id == model.Id);
            if (Receipt == null)
                return null;
            if (Receipt.UserId != model.UserId)
                return null;
            if (!Receipt.CanEdit)
                return null;
            Receipt.ShopName = model.ShopName;
            Receipt.IsImportant = model.IsImportant;
            Receipt.TotalPrice = _productService.GetSum(model.Products);
            Receipt.Products = JsonSerializer.Serialize(model.Products);
            Receipt.UpdatedAt = DateTime.Now;
            Receipt.UpdatedBy = model.UserId.ToString();
            return _mapper.Map<ReceiptViewModel>(await _ReceiptRepos.UpdateAsync(Receipt));
        }

        public async Task<List<ReceiptViewModel>> GetAllReceipts(int skip)
        {
            return _mapper.Map<List<ReceiptViewModel>>(await _ReceiptRepos.GetAllAsync(20, skip));
        }

        public async Task<int> GetAllReceiptsCount()
        {
            return await _ReceiptRepos.CountAsync();
        }

        public async Task<ReceiptViewModel> GetReceipt(Guid id)
        {
            return _mapper.Map<ReceiptViewModel>(await _ReceiptRepos.GetReceiptByIdAsync(id));
        }

        public async Task<List<ReceiptViewModel>> GetUserReceiptsByUserId(int ownerId, int skip)
        {
            return _mapper.Map<List<ReceiptViewModel>>(await _ReceiptRepos.GetReceiptsByUserIdAsync(ownerId, skip));
        }

        public async Task<int> GetUserReceiptsCount(int ownerId)
        {
            return await _ReceiptRepos.CountAsync(d => d.UserId == ownerId);
        }

        public async Task<ReceiptViewModel> RemoveReceiptFromGroup(ReceiptGroupCreateModel model)
        {
            var Receipt = await _ReceiptRepos.FindAsTrackingAsync(d => d.Id == model.ReceiptId);
            if (Receipt == null)
                return null;
            if (Receipt.UserId != model.UserId)
                return null;
            if (Receipt.GroupId != model.GroupId)
                return null;
            Receipt.GroupId = null;
            Receipt.UpdatedAt = DateTime.Now;
            Receipt.UpdatedBy = model.UserId.ToString();
            return _mapper.Map<ReceiptViewModel>(await _ReceiptRepos.UpdateAsync(Receipt));
        }
    }
}