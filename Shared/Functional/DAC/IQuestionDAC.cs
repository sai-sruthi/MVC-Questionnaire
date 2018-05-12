using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Functional.DTO;
using Shared.Infrastructure.DAC;

namespace Shared.Functional.DAC
{
    public interface IQuestionDAC : IDAC
    {
        IList<IQuestionDTO> GetAllQuestions();

        IQuestionDTO GetQuestionById(int questionId);

        void SaveQuestion(IQuestionDTO questionDTO);

        void DeleteQuestion(int questionId);
    }
}
