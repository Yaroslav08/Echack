using Ereceipt.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Web.Controllers
{
    public class NotificationsController : ApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyNotifies(int afterId = 0)
        {
            var notifies = await _notificationService.GetAllNotificationsAsync(GetId(), afterId);
            return Result(notifies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotifiById(int id)
        {
            var notifies = await _notificationService.GetNotificationByIdAsync(id, GetId());
            return Result(notifies);
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnreadNotifications()
        {
            var notifies = await _notificationService.GetUnreadNotificationsAsync(GetId());
            return Result(notifies);
        }

    }
}
