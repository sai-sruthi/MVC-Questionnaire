using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Functional.BDC;
using Shared.Functional.DAC;
using Shared.Functional.DTO;
using Shared.Infrastructure.BDC;
using Shared.Infrastructure.OperationResult;

namespace BusinessLayer
{
    public class QuestionBDC : BDCBase, IQuestionBDC
    {
        public OperationResult<IList<IQuestionDTO>> GetAllQuestions()
        {
            try
            {
                IQuestionDAC questionDAC = DACFactory.Create<IQuestionDAC>();
                IList<IQuestionDTO> questionDTOs = questionDAC.GetAllQuestions();
                return OperationResult<IList<IQuestionDTO>>.CreateSuccessResult(questionDTOs, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<IList<IQuestionDTO>>.CreateErrorResult(null, ex.Message);
            }
        }

        public OperationResult<IQuestionDTO> GetQuestionById(int questionId)
        {
            try
            {
                IQuestionDAC questionDAC = DACFactory.Create<IQuestionDAC>();
                IQuestionDTO questionDTO = questionDAC.GetQuestionById(questionId);
                return OperationResult<IQuestionDTO>.CreateSuccessResult(questionDTO, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<IQuestionDTO>.CreateErrorResult(null, ex.Message);
            }
        }


        public OperationResult<bool> SaveQuestion(IQuestionDTO questionDTO)
        {
            try
            {
                IQuestionDAC questionDAC = DACFactory.Create<IQuestionDAC>();

                questionDAC.SaveQuestion(questionDTO);
                return OperationResult<bool>.CreateSuccessResult(true, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.CreateErrorResult(false, ex.Message);
            }

        }

        public OperationResult<bool> DeleteQuestion(int questionId)
        {
            try
            {
                IQuestionDAC questionDAC = DACFactory.Create<IQuestionDAC>();
                questionDAC.DeleteQuestion(questionId);
                return OperationResult<bool>.CreateSuccessResult(true, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.CreateErrorResult(false, ex.Message);
            }
        }

    }
}

