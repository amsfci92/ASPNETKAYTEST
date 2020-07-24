using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_TestKay.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public int ContactId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ContactModel Contact { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}