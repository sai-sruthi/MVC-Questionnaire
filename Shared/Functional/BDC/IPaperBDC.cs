using Shared.Infrastructure.BDC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Functional.DTO;
using Shared.Infrastructure.OperationResult;

namespace Shared.Functional.BDC
{
    public interface IPaperBDC:IBDC
    {
        OperationResult<IList<IPaperDTO>> GetAllPapers();

        OperationResult<IPaperDTO> GetPaperById(int paperId);

        OperationResult<bool> SavePaper(IPaperDTO paperDTO);

        OperationResult<bool> DeletePaper(int paperId);

        OperationResult<IList<IQuestionDTO>> GetQuestionsOfPaper(int paperId);
    }
}
