using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_TestKay.Models
{
    public class ContactModel
    { 
        #region Ctor
        public ContactModel()
        {
            Comments = new HashSet<Comment>();
        }
        #endregion
        #region Fields
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }

        public string UserId { get; set; }
        #endregion 
        #region Navigation Property
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        #endregion
    }
}