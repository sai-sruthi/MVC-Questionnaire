using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Functional.DTO;
using Shared.Infrastructure.DTO;

namespace DTO
{
    public class QuestionDTO : DTOBase, IQuestionDTO
    {
        public int QuestionId
        {
            get;

            set;
        }

        public string Text
        {
            get;

            set;

        }

        public int Marks
        {
            get;

            set;

        }

        public int QuestionPaperNo
        {
            get;

            set;

        }
    }
}
