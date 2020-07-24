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
    public class ContactController : Controller
    {
        private IContactService contactService;
        public ContactController()
        {
            contactService = new ContactService();
        }
        public ActionResult Index(int pageSize = 10, int pageNo = 1)
        {
            var pagination = new PaginationModel
            {
                PageSize = pageSize,
                Current = pageNo
            };
            var userType = User.IsInRole("Admin") ? UserType.Admin : UserType.User;
            var userId = User.Identity.GetUserId();

            var contacts = contactService.GetAllContact(pagination, userType, userId);
            ViewBag.Pagination = pagination;

            return View(contacts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Contact(ContactModel contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            contact.UserId = User.Identity.GetUserId();
            
            contactService.AddContact(contact);

            return RedirectToAction("Index", new { pageNo = 1, pageSize = 10 });
        }

    }
}