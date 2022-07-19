using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<TvShow> Watching { get; set; }
        public IEnumerable<TvShow> Watched { get; set; }
        public Customer Customer { get; set; }
        
    }
}