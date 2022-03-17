using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ProjectWork.Models
{
    [Table("student2")]
    public class Mystudent2
    {
        [Key]
        [Required(ErrorMessage = "Please enter id")]
        [Display(Name = "Identity")]
        public int id { get; set; }

        [Display(Name = "Student Name")]
        [MaxLength(50)]
        [CustomNameValidator]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter Class")]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        public string @class { get; set; }

        [Required(ErrorMessage = "Please enter Fee")]
        [Range(0, 10000, ErrorMessage = "Enter number between 0 to 1000")]
        public Nullable<decimal> fee { get; set; }

        public string picturepath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        



    }
}