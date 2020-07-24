using AspNet_TestKay.Models;
using AspNet_TestKay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_TestKay.Services
{
    public class CommentService : ICommentService
    {
        #region Fields 
        private ApplicationDbContext _context;
        #endregion
        #region Ctor
        public CommentService()
        {
            _context = new ApplicationDbContext();
        }
        #endregion
        #region Methods
        public ICollection<Comment> GetAllComments(int contactId)
        {

            var comments = _context.Comments.AsQueryable();

            comments = comments.Where(m => m.ContactId == contactId);
            
            // result 
            return comments.ToList();
        }

        public void AddComment(Comment m)
        { 
            // add th e conact
            _context.Comments.Add(m);
        }
        #endregion
    }
}