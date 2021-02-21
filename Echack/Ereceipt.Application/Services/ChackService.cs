using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Chack;
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
    public class ChackService : IChackService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ChackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ChackViewModel> AddChackToGroup(ChackGroupCreateModel model)
        {
            var chack = await _unitOfWork.ChackRepository.FindAsTrackingAsync(d => d.Id == model.ChackId);
            if (chack == null)
                return null;
            if (chack.UserId != model.UserId)
                return null;
            if (chack.GroupId != null)
                return null;
            chack.GroupId = model.GroupId;
            chack.UpdatedAt = DateTime.Now;
            chack.UpdatedBy = model.UserId.ToString();
            return _mapper.Map<ChackViewModel>(await _unitOfWork.ChackRepository.UpdateAsync(chack));
        }

        public async Task<ChackViewModel> CreateCheck(ChackCreateViewModel model)
        {
            var chack = new Chack
            {
                ShopName = model.ShopName,
                IsImportant = model.IsImportant,
                UserId = model.UserId,
                GroupId = model.GroupId,
                ChackType = ChackType.Internal,
                Products = JsonSerializer.Serialize(model.Products),
                TotalPrice = model.Products.Sum(d => d.Price),
                CreatedBy = model.UserId.ToString()
            };
            return _mapper.Map<ChackViewModel>(await _unitOfWork.ChackRepository.CreateAsync(chack));
        }

        public async Task<ChackViewModel> EditChack(ChackEditViewModel model)
        {
            var chack = await _unitOfWork.ChackRepository.FindAsTrackingAsync(d => d.Id == model.Id);
            if (chack == null)
                return null;
            if (chack.UserId != model.UserId)
                return null;
            if (!chack.CanEdit)
                return null;
            chack.ShopName = model.ShopName;
            chack.IsImportant = model.IsImportant;
            chack.TotalPrice = model.GetTotalPrice();
            chack.Products = JsonSerializer.Serialize(model.Products);
            chack.UpdatedAt = DateTime.Now;
            chack.UpdatedBy = model.UserId.ToString();
            return _mapper.Map<ChackViewModel>(await _unitOfWork.ChackRepository.UpdateAsync(chack));
        }

        public async Task<List<ChackViewModel>> GetAllChacks(int skip)
        {
            return _mapper.Map<List<ChackViewModel>>(await _unitOfWork.ChackRepository.GetAllAsync());
        }

        public async Task<ChackViewModel> GetChack(Guid id)
        {
            return _mapper.Map<ChackViewModel>(await _unitOfWork.ChackRepository.GetChackByIdAsync(id));
        }

        public async Task<List<ChackViewModel>> GetUserChacksByUserId(int ownerId, int skip)
        {
            return _mapper.Map<List<ChackViewModel>>(await _unitOfWork.ChackRepository.GetChacksByUserIdAsync(ownerId, skip));
        }

        public async Task<ChackViewModel> RemovEreceiptFromGroup(ChackGroupCreateModel model)
        {
            var chack = await _unitOfWork.ChackRepository.FindAsTrackingAsync(d => d.Id == model.ChackId);
            if (chack == null)
                return null;
            if (chack.UserId != model.UserId)
                return null;
            if (chack.GroupId != model.GroupId)
                return null;
            chack.GroupId = null;
            chack.UpdatedAt = DateTime.Now;
            chack.UpdatedBy = model.UserId.ToString();
            return _mapper.Map<ChackViewModel>(await _unitOfWork.ChackRepository.UpdateAsync(chack));
        }
    }
}