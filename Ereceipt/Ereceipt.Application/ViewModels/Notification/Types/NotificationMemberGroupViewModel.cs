using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.User;
namespace Ereceipt.Application.ViewModels.Notification.Types
{
    public class NotificationMemberGroupViewModel
    {
        public UserViewModel User { get; set; }
        public GroupViewModel Group { get; set; }
    }
}