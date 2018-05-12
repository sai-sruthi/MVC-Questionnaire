using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortalWeb.Models
{
    public class PaperVM
    {
        public int PaperId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public String Name { get; set; }


        public String Description { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        public int Duration { get; set; }

        public int QuestionCount { get; set; }
}
}