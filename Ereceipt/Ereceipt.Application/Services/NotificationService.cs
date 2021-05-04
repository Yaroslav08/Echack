using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Notifications;
using Ereceipt.Application.ViewModels.Notification;
using Ereceipt.Application.ViewModels.Notification.Types;
using Ereceipt.Application.Wrappers;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly INotificationWrapper _notificationWrapper;
        private readonly IJsonConverter _jsonConverter;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper, INotificationWrapper notificationWrapper, IJsonConverter jsonConverter)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _notificationWrapper = notificationWrapper;
            _jsonConverter = jsonConverter;
        }

        public async Task CreateNotificationAsync(NotificationViewModel model, string content)
        {
            var notify = _mapper.Map<Notification>(model);
            notify.Content = content;
            await _notificationRepository.CreateAsync(notify);
        }

        public async Task CreateNotificationAsync(NotificationViewModel model, NotificationLoginViewModel content)
        {
            var notify = _mapper.Map<Notification>(model);
            notify.Content = _jsonConverter.GetStringAsJson(content);
            await _notificationRepository.CreateAsync(notify);
        }

        public async Task CreateNotificationAsync(NotificationViewModel model, NotificationReceiptInGroupViewModel content)
        {
            var notify = _mapper.Map<Notification>(model);
            notify.Content = _jsonConverter.GetStringAsJson(content);
            await _notificationRepository.CreateAsync(notify);
        }

        public async Task CreateNotificationAsync(NotificationViewModel model, NotificationMemberGroupViewModel content)
        {
            var notify = _mapper.Map<Notification>(model);
            notify.Content = _jsonConverter.GetStringAsJson(content);
            await _notificationRepository.CreateAsync(notify);
        }

        public async Task CreateNotificationAsync(NotificationViewModel model, NotificationCommentReceiptViewModel content)
        {
            var notify = _mapper.Map<Notification>(model);
            notify.Content = _jsonConverter.GetStringAsJson(content);
            await _notificationRepository.CreateAsync(notify);
        }

        public async Task<ListNotificationResult> GetAllNotificationsAsync(int userId, int afterId)
        {
            var notificationsFromDb = await _notificationRepository.GetAllNotificationsAsync(userId, afterId);
            var notificationsToView = _notificationWrapper.MapNotificationsToView(notificationsFromDb);
            return new ListNotificationResult(notificationsToView);
        }

        public async Task<NotificationResult> GetNotificationByIdAsync(long id, int userId)
        {
            var notifyById = await _notificationRepository.FindAsync(d => d.Id == id);
            if (notifyById is null)
                return new NotificationResult(model: null);
            if (notifyById.UserId != userId)
            {
                if (userId != 0)
                    return new NotificationResult("Access denited");
            }
            var notifyToReturn = _notificationWrapper.MapNotificationToView(notifyById);
            return new NotificationResult(notifyToReturn);
        }

        public async Task<ListNotificationResult> GetUnreadNotificationsAsync(int userId)
        {
            var notificationsFromDb = await _notificationRepository.GetUnreadNotificationsAsync(userId);
            var notificationsToView = _notificationWrapper.MapNotificationsToView(notificationsFromDb);
            return new ListNotificationResult(notificationsToView);
        }

        public async Task MarkAllNotificationsAsReadAsync(int userId)
        {
            var notificationToSetRead = await _notificationRepository.FindListAsTrackingAsync(x => !x.IsRead && x.UserId == userId);
            if (notificationToSetRead is null)
                return;
            foreach (var notify in notificationToSetRead)
            {
                notify.IsRead = true;
                notify.ReadedAt = DateTime.UtcNow;
            }
            await _notificationRepository.UpdateRangeAsync(notificationToSetRead);
        }

        public async Task MarkNotificationAsReadAsync(long id, int userId)
        {
            var notifyForRead = await _notificationRepository.FindAsTrackingAsync(x => x.Id == id);
            if (notifyForRead is null)
                return;
            if (notifyForRead.UserId != userId || notifyForRead.UserId != 0)
                return;
            notifyForRead.IsRead = true;
            notifyForRead.ReadedAt = DateTime.UtcNow;
            await _notificationRepository.UpdateAsync(notifyForRead);
        }
    }
}