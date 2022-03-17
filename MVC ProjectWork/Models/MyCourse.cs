using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_ProjectWork.Models
{
    [Table("Course")]
    public class MyCourse
    {
        [Key]
        [Display(Name ="Course Id")]
        [Required(ErrorMessage ="Please enter Your Course Id")]
        public int courseid { get; set; }
        public string coursename { get; set; }
        public Nullable<int> studentid { get; set; }
        public Nullable<int> teacherid { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}