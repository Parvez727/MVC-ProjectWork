using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ProjectWork.Models
{
    [Table("Students")]
    public class Mystudent
    {
        [Key]
        [Required(ErrorMessage = "Please enter Your ID")]
        [Display(Name = "Student ID")]
        public int studentid { get; set; }


        [Required(ErrorMessage = "Please enter Your Student Name")]
        [Display(Name = "Student Name")]
        //[CustomNameValidator]
         public string studentname { get; set; }

        [Required(ErrorMessage = "Please enter Class")]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Class")]
        public string @class { get; set; }

        [Required(ErrorMessage = "Please enter Your Gender")]
        [Display(Name = "Gender")]
        [MaxLength(50)]
        public string gender { get; set; }

        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> date { get; set; }

        [Display(Name = "Student Image")]
        public string image_path { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> Courses { get; set; }

    }
}