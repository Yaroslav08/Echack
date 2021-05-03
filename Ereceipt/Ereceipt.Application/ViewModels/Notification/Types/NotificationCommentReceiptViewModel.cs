using Ereceipt.Application.ViewModels.Comment;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Application.ViewModels.User;
namespace Ereceipt.Application.ViewModels.Notification.Types
{
    public class NotificationCommentReceiptViewModel
    {
        public UserViewModel User { get; set; }
        public CommentViewModel Comment { get; set; }
        public ReceiptViewModel Receipt { get; set; }
    }
}