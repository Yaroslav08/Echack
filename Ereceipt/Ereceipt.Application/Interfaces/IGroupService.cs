﻿using Ereceipt.Application.ViewModels.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IGroupService
    {
        Task<GroupViewModel> GetGroupById(Guid id);
        Task<GroupViewModel> CreateGroup(GroupCreateViewModel model);
        Task<GroupViewModel> EditGroup(GroupEditViewModel model);
        Task<GroupViewModel> RemoveGroup(Guid id, int userId);
        Task<List<ChackGroupViewModel>> GetChacksByGroupId(Guid groupId, int skip);
        Task<List<GroupViewModel>> GetGroupsByUserId(int id);
        Task<bool> CanEditGroup(Guid groupId, int userId);
    }
}