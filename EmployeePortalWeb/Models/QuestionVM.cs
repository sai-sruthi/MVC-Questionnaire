using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortalWeb.Models
{
    public class QuestionVM
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        public String Text { get; set; }


        public int Marks { get; set; }

        [Required(ErrorMessage = "Question Paper No. required.")]
        public int QuestionPaperNo { get; set; }
    }
}