using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Infrastructure.BDC;
using Shared.Functional.DTO;
using Shared.Infrastructure.OperationResult;

namespace Shared.Functional.BDC
{
    public interface IQuestionBDC : IBDC
    {
        OperationResult<IList<IQuestionDTO>> GetAllQuestions();

        OperationResult<IQuestionDTO> GetQuestionById(int questionId);

        OperationResult<bool> SaveQuestion(IQuestionDTO questionDTO);

        OperationResult<bool> DeleteQuestion(int questionId);
    }
}
