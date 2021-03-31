using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Results.Comments;
using Ereceipt.Application.ViewModels.Comment;
using Ereceipt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services
{
    public class CommentService : ICommentService
    {
        ICommentRepository _commentRepository;
        IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }


        public async Task<ListCommentResult> GetCommentsByReceiptId(Guid id)
        {
            return new ListCommentResult(_mapper.Map<List<CommentViewModel>>(await _commentRepository.GetReceiptCommentsAsync(id)));
        }
    }
}