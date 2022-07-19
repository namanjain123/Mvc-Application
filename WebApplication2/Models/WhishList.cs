using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class WhishList
    {
        [Key]
        public byte Show_Id { get; set; }

        public byte Customer_Id { get; set; }
        

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }

    }
}