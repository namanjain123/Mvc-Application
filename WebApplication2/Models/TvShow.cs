using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TvShow
    {
        [Key]
        public byte Show_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}