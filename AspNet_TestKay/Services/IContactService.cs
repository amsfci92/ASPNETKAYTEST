using AspNet_TestKay.Models;
using AspNet_TestKay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_TestKay.Services
{
    public interface IContactService
    {
        ICollection<ContactModel> GetAllContact(PaginationModel paginationModel, UserType userType, string userId);
        void AddContact(ContactModel contact);
        bool Exists(int contactId);
    }
}