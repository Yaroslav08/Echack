using Ereceipt.Application.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.Results.Comments
{
    public class ListCommentResult : Result
    {
        public ListCommentResult(List<CommentViewModel> comments) : base(comments) { }
    }
}
