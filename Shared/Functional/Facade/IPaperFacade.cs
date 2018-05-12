using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Infrastructure.Facade;
using Shared.Infrastructure.OperationResult;
using Shared.Functional.DTO;

namespace Shared.Functional.Facade
{
    public interface IPaperFacade:IFacade
    {
        OperationResult<IList<IPaperDTO>> GetAllPapers();

        OperationResult<IPaperDTO> GetPaperById(int paperId);

        OperationResult<bool> SavePaper(IPaperDTO paperDTO);

        OperationResult<bool> DeletePaper(int paperId);

        OperationResult<IList<IQuestionDTO>> GetQuestionsOfPaper(int paperId);
    }
}
