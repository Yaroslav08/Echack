using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Application.ViewModels.User;
namespace Ereceipt.Application.ViewModels.Notification.Types
{
    public class NotificationReceiptInGroupViewModel
    {
        public UserViewModel User { get; set; }
        public GroupViewModel Group { get; set; }
        public ReceiptViewModel Receipt { get; set; }
    }
}