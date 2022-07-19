using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Customer
    {
        [Key]
        public byte Customer_Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name="You Have Watched")]
        public Watched Watch { get; set; }

        [Display(Name = "You Are Watching")]
        public Watching Watching { get; set; }
        
        [Display(Name = "You WishList/WatchList")]
        public WhishList WishList { get; set; }


    }
}