using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortalWeb.Models
{
    public class PaperDetailsVM
    {
        public int PaperId { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public int Duration { get; set; }

        public IList<QuestionVM> Questions { get; set; }
    }
}