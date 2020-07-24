using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_TestKay.ViewModels
{
    public class PaginationModel
    {
        public int PageSize { get; set; }
        public int Current { get; set; }
        public int Total { get; set; }
    }
}