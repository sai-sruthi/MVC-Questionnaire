using Shared.Infrastructure.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Functional.DTO;

namespace Shared.Functional.DAC
{
    public interface IPaperDAC : IDAC
    {
        IList<IPaperDTO> GetAllPapers();

        IPaperDTO GetPaperById(int paperId);

        void SavePaper(IPaperDTO paperDTO);

        bool DeletePaper(int paperId);

        IPaperDTO GetPaperByTitle(string p);

        IList<IQuestionDTO> GetQuestionsOfPaper(int paperId);
    }
}
