using Ereceipt.Application.ViewModels.Comment;
namespace Ereceipt.Application.Results.Comments
{
    public class CommentResult : Result
    {
        public CommentResult(CommentViewModel comment) : base(comment) { }
        public CommentResult(string error) : base(error) { }
    }
}