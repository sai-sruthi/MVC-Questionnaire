using Shared.Functional.BDC;
using Shared.Functional.DTO;
using Shared.Functional.Facade;
using Shared.Infrastructure.Facade;
using Shared.Infrastructure.OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFacade
{
    public class PaperFacade:FacadeBase, IPaperFacade
    {
        public OperationResult<IList<IPaperDTO>> GetAllPapers()
        {
            IPaperBDC paperBDC = BDCFactory.Create<IPaperBDC>();
            return paperBDC.GetAllPapers();
        }

        public OperationResult<IPaperDTO> GetPaperById(int paperId)
        {
            IPaperBDC paperBDC = BDCFactory.Create<IPaperBDC>();
            return paperBDC.GetPaperById(paperId);
        }

        public OperationResult<bool> SavePaper(IPaperDTO noticeDTO)
        {
            IPaperBDC paperBDC = BDCFactory.Create<IPaperBDC>();
            return paperBDC.SavePaper(noticeDTO);
        }

        public OperationResult<bool> DeletePaper(int paperId)
        {
            IPaperBDC paperBDC = BDCFactory.Create<IPaperBDC>();
            return paperBDC.DeletePaper(paperId);
        }

        public OperationResult<IList<IQuestionDTO>> GetQuestionsOfPaper(int paperId)
        {
            IPaperBDC paperBDC = BDCFactory.Create<IPaperBDC>();
            return paperBDC.GetQuestionsOfPaper(paperId);
        }
    }
}
