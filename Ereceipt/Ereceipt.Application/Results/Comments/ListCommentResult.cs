using Ereceipt.Application.ViewModels.Comment;
using System.Collections.Generic;

namespace Ereceipt.Application.Results.Comments
{
    public class ListCommentResult : Result
    {
        public ListCommentResult(List<CommentViewModel> comments) : base(comments) { }
    }
}
