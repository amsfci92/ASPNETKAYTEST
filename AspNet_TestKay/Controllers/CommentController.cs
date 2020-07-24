using AspNet_TestKay.Models;
using AspNet_TestKay.Services;
using AspNet_TestKay.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNet_TestKay.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService commentService;
        private IContactService contactService;
        public CommentController()
        {
            commentService = new CommentService();
            contactService = new ContactService();
        }
        public ActionResult Index(int contactId)
        {
            if (contactId == 0)
            {
                return HttpNotFound();
            }

            var userId = User.Identity.GetUserId();

            var comments = commentService.GetAllComments(contactId);
            
            return View(comments);
        }

        [Authorize]
        public ActionResult Comment(int contactId)
        {
            if (contactId == 0 || !contactService.Exists(contactId)) 
            {
                return HttpNotFound();
            }
            
            return View(new Comment
            {
                ContactId = contactId
            });
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Comment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            comment.UserId = User.Identity.GetUserId();
            commentService.AddComment(comment);

            return RedirectToAction($"CommentList/{comment.ContactId}");
        }

        [HttpGet]
        [Authorize]
        public ActionResult CommentList(int contactId)
        {
            if (contactId == 0 || !contactService.Exists(contactId))
            {
                return HttpNotFound();
            }

            return View(commentService.GetAllComments(contactId));
        }

    }
}