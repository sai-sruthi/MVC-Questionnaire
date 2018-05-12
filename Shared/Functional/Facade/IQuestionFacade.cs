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
    public interface IQuestionFacade : IFacade
    {
        OperationResult<IList<IQuestionDTO>> GetAllQuestions();

        OperationResult<IQuestionDTO> GetQuestionById(int questionId);

        OperationResult<bool> SaveQuestion(IQuestionDTO questionDTO);

        OperationResult<bool> DeleteQuestion(int questionId);
    }
}
