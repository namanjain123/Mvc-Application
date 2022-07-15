using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Emp
    {
        [Range(100,9999,ErrorMessage ="Enter a Valid Id")]
        [Display(Name ="Your Id")]
        public int EmployeId { get; set; }
        
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        public string EmailAddress { get; set; }
        
        [DataType(DataType.Password)]//To have non viewable
        [StringLength(100,MinimumLength =8,ErrorMessage ="Enter A valid password of max 100 and min 8 characters")]
        [Required]
        public string password { get; set; }
        
        [Required]
        [Compare("password",ErrorMessage="Enter Same as original password")]//We used to compare
        [DataType(DataType.Password)]//To have non viewable
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Enter A valid password of max 100 and min 8 characters")]
        public string confirmpassword { get; set; }

    }
}