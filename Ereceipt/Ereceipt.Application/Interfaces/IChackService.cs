﻿using Ereceipt.Application.ViewModels.Chack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IChackService
    {
        Task<ChackViewModel> CreateCheck(ChackCreateViewModel model);
        Task<ChackViewModel> EditChack(ChackEditViewModel model);
        Task<ChackViewModel> GetChack(Guid id);
        Task<List<ChackViewModel>> GetUserChacksByUserId(int ownerId, int skip);
        Task<int> GetUserChacksCount(int ownerId);
        Task<ChackViewModel> AddChackToGroup(ChackGroupCreateModel model);
        Task<ChackViewModel> RemoveChackFromGroup(ChackGroupCreateModel model);
        Task<List<ChackViewModel>> GetAllChacks(int skip);
        Task<int> GetAllChacksCount();
    }
}