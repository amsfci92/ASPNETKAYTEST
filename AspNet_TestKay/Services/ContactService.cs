using AspNet_TestKay.Models;
using AspNet_TestKay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_TestKay.Services
{
    public class ContactService : IContactService
    {
        #region Fields 
        private ApplicationDbContext _context;
        #endregion
        #region Ctor
        public ContactService()
        {
            _context = new ApplicationDbContext();
        }
        #endregion
        #region Methods
        public ICollection<ContactModel> GetAllContact(PaginationModel paginationModel, UserType userType, string userId)
        {

            var contacts = _context.Contacts.AsQueryable();

            if (userType == UserType.User)
            {
                contacts = contacts.Where(m => m.UserId == userId);
            }

            // pagination 
            contacts = contacts.OrderBy(m => m.Id).Skip(paginationModel.PageSize * paginationModel.Current).Take(paginationModel.PageSize);
            
            paginationModel.Total = contacts.Count();
            // result 
            return contacts.ToList();
        }

        public void AddContact(ContactModel conatct)
        {
            // add th e conact
            _context.Contacts.Add(conatct);
        }

        public bool Exists(int contactId)
        {
            // add th e conact
            return _context.Contacts.Any(m => m.Id == contactId);
        }
        #endregion
    }
}