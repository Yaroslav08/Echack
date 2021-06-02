using AutoMapper;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.Results;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Currency;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepos;
        private readonly IProductService _productService;
        private readonly IJsonConverter _jsonConverter;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IEntityService _entityService;
        private readonly IMapper _mapper;
        public ReceiptService(IReceiptRepository ReceiptRepos, IMapper mapper, IProductService productService, ICurrencyRepository currencyRepository, IJsonConverter jsonConverter, IEntityService entityService, ICommentRepository commentRepository)
        {
            _receiptRepos = ReceiptRepos;
            _mapper = mapper;
            _productService = productService;
            _currencyRepository = currencyRepository;
            _jsonConverter = jsonConverter;
            _entityService = entityService;
            _commentRepository = commentRepository;
        }

        public async Task<ReceiptResult> AddReceiptToGroupAsync(ReceiptGroupCreateModel model)
        {
            if (!await _entityService.IsExistAsync<Group>(x => x.Id == model.GroupId))
                return new ReceiptResult("Group not found");
            var receiptForEdit = await _receiptRepos.FindAsTrackingAsync(d => d.Id == model.ReceiptId);
            if (receiptForEdit == null)
                return new ReceiptResult("Receipt not found");
            if (receiptForEdit.UserId != model.UserId)
                return new ReceiptResult("Access Denited");
            if (receiptForEdit.GroupId != null)
                return new ReceiptResult("Already in group");
            receiptForEdit.GroupId = model.GroupId;
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _receiptRepos.UpdateAsync(receiptForEdit)));
        }

        public async Task<ReceiptResult> CreateReceiptAsync(ReceiptCreateModel model)
        {
            if (model.GroupId is not null)
                if (!await _entityService.IsExistAsync<Group>(x => x.Id == model.GroupId))
                    return new ReceiptResult("Group not found");
            CurrencyViewModel currency;
            if (model.CurrencyId == null)
                currency = _mapper.Map<CurrencyViewModel>(await _currencyRepository.FindAsync(d => d.Code == "UAH"));
            else
            {
                currency = _mapper.Map<CurrencyViewModel>(await _currencyRepository.FindAsync(d => d.Id == model.CurrencyId));
            }
            var receiptToCreate = new Receipt
            {
                ShopName = model.ShopName,
                AddressShop = model.AddressShop,
                IsImportant = model.IsImportant,
                UserId = model.UserId,
                GroupId = model.GroupId,
                Currency = _jsonConverter.GetStringAsJson(currency),
                ReceiptType = ReceiptType.Internal,
                TotalPrice = model.TotalPrice == default ? model.Products.Sum(x => x.Price) : default,
                Products = _jsonConverter.GetStringAsJson(model.Products)
            };
            receiptToCreate.SetInitData(model);
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _receiptRepos.CreateAsync(receiptToCreate)));
        }

        public async Task<ReceiptResult> EditReceiptAsync(ReceiptEditModel model)
        {
            var receiptForEdit = await _receiptRepos.FindAsTrackingAsync(d => d.Id == model.Id);
            if (receiptForEdit == null)
                return new ReceiptResult("Receipt not found");
            if (receiptForEdit.UserId != model.UserId)
                return new ReceiptResult("Access Denited");
            if (!receiptForEdit.CanEdit)
                return new ReceiptResult("This receipt can't be edit");
            if (model.CurrencyId is not null)
            {
                var currentCurrency = _jsonConverter.GetModelFromJson<Currency>(receiptForEdit.Currency);
                if(model.CurrencyId != currentCurrency.Id)
                {
                    var newCurrency = await _currencyRepository.FindAsync(d => d.Id == model.CurrencyId);
                    if (newCurrency is null)
                        return new ReceiptResult("Currency not found");
                    receiptForEdit.Currency = _jsonConverter.GetStringAsJson(newCurrency);
                }
            }
            receiptForEdit.ShopName = model.ShopName;
            receiptForEdit.AddressShop = model.AddressShop;
            receiptForEdit.IsImportant = model.IsImportant;
            receiptForEdit.Products = _jsonConverter.GetStringAsJson(model.Products);
            receiptForEdit.TotalPrice = model.Products != null ? model.Products.Sum(x => x.Price) : receiptForEdit.TotalPrice;
            receiptForEdit.SetUpdateData(model);
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _receiptRepos.UpdateAsync(receiptForEdit)));
        }

        public async Task<ListReceiptResult> GetAllReceiptsAsync(int skip)
        {
            return new ListReceiptResult(_mapper.Map<List<ReceiptViewModel>>(await _receiptRepos.GetAllAsync(20, skip)));
        }

        public async Task<CountResult> GetAllReceiptsCountAsync()
        {
            return new CountResult(await _receiptRepos.CountAsync());
        }

        public async Task<ReceiptResult> GetReceiptAsync(Guid id)
        {
            var receipt = _mapper.Map<ReceiptViewModel>(await _receiptRepos.GetReceiptByIdAsync(id));
            if (receipt != null)
                receipt.CommentsCount = await _receiptRepos.GetCountCommentsByReceiptIdAsync(id);
            return new ReceiptResult(receipt);
        }

        public async Task<ListReceiptResult> GetReceiptsByShopNameAsync(int userId, string shopName, int skip)
        {
            return new ListReceiptResult(_mapper.Map<List<ReceiptViewModel>>(await _receiptRepos.GetReceiptsByShopNameAsync(userId, shopName, skip)));
        }

        public async Task<ListReceiptResult> GetUserReceiptsByUserIdAsync(int ownerId, int skip)
        {
            return new ListReceiptResult(_mapper.Map<List<ReceiptViewModel>>(await _receiptRepos.GetReceiptsByUserIdAsync(ownerId, skip)));
        }

        public async Task<CountResult> GetUserReceiptsCountAsync(int ownerId)
        {
            return new CountResult(await _receiptRepos.CountAsync(d => d.UserId == ownerId));
        }

        public async Task<ReceiptResult> RemoveReceiptAsync(Guid id, int userId)
        {
            var receiptToDelete = await _receiptRepos.FindAsTrackingAsync(d => d.Id == id);
            if (receiptToDelete == null)
                return new ReceiptResult("Receipt not found");
            if (receiptToDelete.UserId != userId)
                return new ReceiptResult("Access denited");
            var commentsToRemove = await _commentRepository.FindListAsTrackingAsync(x => x.ReceiptId == id);
            if (commentsToRemove != null && commentsToRemove.Count > 0)
                await _commentRepository.RemoveRangeAsync(commentsToRemove);
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _receiptRepos.RemoveAsync(receiptToDelete)));
        }

        public async Task<ReceiptResult> RemoveReceiptFromGroupAsync(ReceiptGroupCreateModel model)
        {
            var Receipt = await _receiptRepos.FindAsTrackingAsync(d => d.Id == model.ReceiptId);
            if (Receipt == null)
                return new ReceiptResult("Receipt not found");
            if (Receipt.UserId != model.UserId)
                return new ReceiptResult("Access Denited");
            if (Receipt.GroupId is null)
                return new ReceiptResult("The receipt isn't tied to a group");
            if (Receipt.GroupId != model.GroupId)
                return new ReceiptResult("The receipt isn't tied to this group");
            Receipt.GroupId = null;
            return new ReceiptResult(_mapper.Map<ReceiptViewModel>(await _receiptRepos.UpdateAsync(Receipt)));
        }
    }
}