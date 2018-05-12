using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Infrastructure.DTO;

namespace Shared.Functional.DTO
{
    public interface IPaperDTO:IDTO
    {
        int PaperId { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        int Duration { get; set; }

        //ICollection<IQuestionDTO> Questions { get; set; }

        int QuestionCount { get; set; }
    }

}
