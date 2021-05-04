using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Infrastructure.Data.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(EreceiptContext db) : base(db) { }

        public async Task<List<Notification>> GetAllNotificationsAsync(int userId, int afterId)
        {
            return await db.Notifications
                .AsNoTracking()
                .Where(d => d.UserId == userId && d.Id > afterId)
                .Take(20)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetUnreadNotificationsAsync(int userId)
        {
            return await db.Notifications
                .AsNoTracking()
                .Where(x => !x.IsRead)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}