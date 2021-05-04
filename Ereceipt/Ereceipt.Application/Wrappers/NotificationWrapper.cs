using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Notification;
using Ereceipt.Application.ViewModels.Notification.Types;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Wrappers
{
    public class NotificationWrapper : INotificationWrapper
    {
        private IJsonConverter _jsonConverter;
        private readonly IMapper _mapper;

        public NotificationWrapper(IJsonConverter jsonConverter, IMapper mapper)
        {
            _jsonConverter = jsonConverter;
            _mapper = mapper;
        }


        public NotificationViewModel GetNewNotificationModel<T>(string content)
        {
            return new NotificationViewModel<T>(_jsonConverter.GetModelFromJson<T>(content));
        }

        public Notification MapToDb<T>(NotificationViewModel<T> model)
        {
            throw new NotImplementedException();
        }

        public NotificationViewModel MapNotificationToView(Notification notify)
        {
            NotificationViewModel notifyToReturn = _mapper.Map<NotificationViewModel>(notify);
            notifyToReturn.Content = notify.NotificationType switch
            {
                NotificationType.System => _jsonConverter.GetModelFromJson<string>(notify.Content),
                NotificationType.Login => _jsonConverter.GetModelFromJson<NotificationLoginViewModel>(notify.Content),
                NotificationType.NewReceiptInGroup => _jsonConverter.GetModelFromJson<NotificationReceiptInGroupViewModel>(notify.Content),
                NotificationType.RemoveReceiptFromGroup => _jsonConverter.GetModelFromJson<NotificationReceiptInGroupViewModel>(notify.Content),
                NotificationType.AddMemberToGroup => _jsonConverter.GetModelFromJson<NotificationMemberGroupViewModel>(notify.Content),
                NotificationType.RemoveMemberFromGroup => _jsonConverter.GetModelFromJson<NotificationMemberGroupViewModel>(notify.Content),
                NotificationType.NewCommentInReceipt => _jsonConverter.GetModelFromJson<NotificationCommentReceiptViewModel>(notify.Content),
                NotificationType.RemoveCommentInReceipt => _jsonConverter.GetModelFromJson<NotificationCommentReceiptViewModel>(notify.Content),
                _ => _jsonConverter.GetModelFromJson<string>(notify.Content)
            };
            return notifyToReturn;
        }

        public List<NotificationViewModel> MapNotificationsToView(List<Notification> notifications)
        {
            var listNotify = new List<NotificationViewModel>();
            if (notifications is null || notifications.Count == 0)
                return null;
            notifications.ForEach(x =>
            {
                listNotify.Add(MapNotificationToView(x));
            });
            return listNotify;
        }
    }
}