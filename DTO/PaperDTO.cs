using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Functional.DTO;
using Shared.Infrastructure.DTO;

namespace DTO
{
    public class PaperDTO:DTOBase,IPaperDTO
    {
        public int PaperId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
        public int Duration
        {
            get;
            set;
        }

        //public ICollection<IQuestionDTO> Questions
        //{
        //    get;
        //    set;
        //}

        public int QuestionCount
        {
            get;
            set;
        }
    }
}
