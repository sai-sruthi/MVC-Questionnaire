using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Infrastructure.DTO;

namespace Shared.Functional.DTO
{
    public interface IQuestionDTO : IDTO
    {
        int QuestionId { get; set; }

        string Text { get; set; }

        int Marks { get; set; }

        int QuestionPaperNo { get; set; }
    }
}
