using AutoMapper;
using Echack.Application.Interfaces;
using Echack.Application.ViewModels.Chack;
using Echack.Domain.Models;
using Echack.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Echack.Application.Services
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
    }
}