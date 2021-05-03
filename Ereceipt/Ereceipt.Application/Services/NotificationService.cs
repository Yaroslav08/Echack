using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Notifications;
using Ereceipt.Application.ViewModels.Notification;
using Ereceipt.Application.ViewModels.Notification.Types;
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
        private IMapper _mapper;
        private IJsonConverter _jsonConverter;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper, IJsonConverter jsonConverter)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _jsonConverter = jsonConverter;
        }

        public async Task<NotificationResult> CreateNotificationAsync(NotificationViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<NotificationResult> GetNotificationByIdAsync(long id, int userId)
        {
            var notifyById = await _notificationRepository.FindAsync(d => d.Id == id);
            if (notifyById is null)
                return new NotificationResult(model: null);
            if (notifyById.UserId != userId || userId != 0)
                return new NotificationResult("Access denited");
            NotificationViewModel notifyToReturn = null;
            notifyToReturn = notifyById.NotificationType switch
            {
                NotificationType.System => new NotificationViewModel<string>(notifyById.Content),
                NotificationType.Login => new NotificationViewModel<NotificationLoginViewModel>(_jsonConverter.GetModelFromJson<NotificationLoginViewModel>(notifyById.Content)),
                NotificationType.NewReceiptInGroup => new NotificationViewModel<NotificationReceiptInGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationReceiptInGroupViewModel>(notifyById.Content)),
                NotificationType.RemoveReceiptFromGroup => new NotificationViewModel<NotificationReceiptInGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationReceiptInGroupViewModel>(notifyById.Content)),
                NotificationType.AddMemberToGroup => new NotificationViewModel<NotificationMemberGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationMemberGroupViewModel>(notifyById.Content)),
                NotificationType.RemoveMemberFromGroup => new NotificationViewModel<NotificationMemberGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationMemberGroupViewModel>(notifyById.Content)),
                NotificationType.NewCommentInReceipt => new NotificationViewModel<NotificationCommentReceiptViewModel>(_jsonConverter.GetModelFromJson<NotificationCommentReceiptViewModel>(notifyById.Content)),
                NotificationType.RemoveCommentInReceipt => new NotificationViewModel<NotificationCommentReceiptViewModel>(_jsonConverter.GetModelFromJson<NotificationCommentReceiptViewModel>(notifyById.Content)),
            };
            notifyToReturn = _mapper.Map<NotificationViewModel>(notifyById);
            return new NotificationResult(notifyToReturn);
        }

        public async Task<ListNotificationResult> GetUnreadNotificationsAsync(int userId)
        {
            var notificationsFromDb = await _notificationRepository.GetUnreadNotificationsAsync(userId);
            if (notificationsFromDb is null || notificationsFromDb.Count == 0)
            {
                return new ListNotificationResult(null);
            }
            var notificationsToView = new List<NotificationViewModel>();
            foreach (var notify in notificationsFromDb)
            {
                NotificationViewModel notifyToReturn = null;
                notifyToReturn = notify.NotificationType switch
                {
                    NotificationType.System => new NotificationViewModel<string>(notify.Content),
                    NotificationType.Login => new NotificationViewModel<NotificationLoginViewModel>(_jsonConverter.GetModelFromJson<NotificationLoginViewModel>(notify.Content)),
                    NotificationType.NewReceiptInGroup => new NotificationViewModel<NotificationReceiptInGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationReceiptInGroupViewModel>(notify.Content)),
                    NotificationType.RemoveReceiptFromGroup => new NotificationViewModel<NotificationReceiptInGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationReceiptInGroupViewModel>(notify.Content)),
                    NotificationType.AddMemberToGroup => new NotificationViewModel<NotificationMemberGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationMemberGroupViewModel>(notify.Content)),
                    NotificationType.RemoveMemberFromGroup => new NotificationViewModel<NotificationMemberGroupViewModel>(_jsonConverter.GetModelFromJson<NotificationMemberGroupViewModel>(notify.Content)),
                    NotificationType.NewCommentInReceipt => new NotificationViewModel<NotificationCommentReceiptViewModel>(_jsonConverter.GetModelFromJson<NotificationCommentReceiptViewModel>(notify.Content)),
                    NotificationType.RemoveCommentInReceipt => new NotificationViewModel<NotificationCommentReceiptViewModel>(_jsonConverter.GetModelFromJson<NotificationCommentReceiptViewModel>(notify.Content)),
                };
                notifyToReturn = _mapper.Map<NotificationViewModel>(notify);
                notificationsToView.Add(notifyToReturn);
            }
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
            notifyForRead.IsRead = true;
            notifyForRead.ReadedAt = DateTime.UtcNow;
            await _notificationRepository.UpdateAsync(notifyForRead);
        }
    }
}