using Ereceipt.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetUnreadNotificationsAsync(int userId);
        Task<List<Notification>> GetAllNotificationsAsync(int userId, int afterId);
    }
}