using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Functional.BDC;
using Shared.Functional.DTO;
using Shared.Functional.Facade;
using Shared.Infrastructure.Facade;
using Shared.Infrastructure.OperationResult;

namespace BusinessFacade
{
    public class QuestionFacade : FacadeBase, IQuestionFacade
    {
        public OperationResult<IList<IQuestionDTO>> GetAllQuestions()
        {
            IQuestionBDC questionBDC = BDCFactory.Create<IQuestionBDC>();
            return questionBDC.GetAllQuestions();
        }

        public OperationResult<IQuestionDTO> GetQuestionById(int questionId)
        {
            IQuestionBDC questionBDC = BDCFactory.Create<IQuestionBDC>();
            return questionBDC.GetQuestionById(questionId);
        }

        public OperationResult<bool> SaveQuestion(IQuestionDTO questionId)
        {
            IQuestionBDC questionBDC = BDCFactory.Create<IQuestionBDC>();
            return questionBDC.SaveQuestion(questionId);
        }

        public OperationResult<bool> DeleteQuestion(int questionId)
        {
            IQuestionBDC questionBDC = BDCFactory.Create<IQuestionBDC>();
            return questionBDC.DeleteQuestion(questionId);
        }
    }
}
