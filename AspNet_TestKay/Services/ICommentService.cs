using AspNet_TestKay.Models;
using AspNet_TestKay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_TestKay.Services
{
    public interface ICommentService
    {
        ICollection<Comment> GetAllComments(int contactId);
        void AddComment(Comment comment);
    }
}