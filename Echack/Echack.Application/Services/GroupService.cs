using AutoMapper;
using Echack.Application.Interfaces;
using Echack.Application.ViewModels.Group;
using Echack.Domain.Models;
using Echack.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.Services
{
    public class GroupService : IGroupService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GroupViewModel> CreateGroup(GroupCreateViewModel model)
        {
            var group = new Group
            {
                Name = model.Name,
                Desc = model.Desc,
                Color = model.Color,
                CreatedBy = model.UserId.ToString()
            };
            var groupToResult = await _unitOfWork.GroupRepository.CreateAsync(group);
            await _unitOfWork.GroupMemberRepository.CreateAsync(new GroupMember
            {
                GroupId = groupToResult.Id,
                UserId = model.UserId,
                Title = "Creator",
                CreatedBy = model.UserId.ToString()
            });
            return _mapper.Map<GroupViewModel>(groupToResult);
        }

        public async Task<GroupViewModel> GetGroupById(Guid id)
        {
            return _mapper.Map<GroupViewModel>(await _unitOfWork.GroupRepository.FindAsync(d => d.Id == id));
        }
    }
}