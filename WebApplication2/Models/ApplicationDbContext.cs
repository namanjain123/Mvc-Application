using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    //This is used as a data connection string
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<TvShow> TvShow { get; set; }
        public DbSet<Watched> Watched { get; set; }
        public DbSet<Watching> Watching { get; set; }
        public DbSet<WhishList> WhishList { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
    }
}