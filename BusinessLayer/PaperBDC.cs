using Shared.Functional.BDC;
using Shared.Functional.DAC;
using Shared.Functional.DTO;
using Shared.Infrastructure.BDC;
using Shared.Infrastructure.OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PaperBDC:BDCBase, IPaperBDC
    {
        public OperationResult<IList<IPaperDTO>> GetAllPapers()
        {
            try
            {
                IPaperDAC paperDAC = DACFactory.Create<IPaperDAC>();
                IList<IPaperDTO> papersDTOs = paperDAC.GetAllPapers();
                return OperationResult<IList<IPaperDTO>>.CreateSuccessResult(papersDTOs, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<IList<IPaperDTO>>.CreateErrorResult(null, ex.Message);
            }
        }

        public OperationResult<IPaperDTO> GetPaperById(int paperId)
        {
            try
            {
                IPaperDAC paperDAC = DACFactory.Create<IPaperDAC>();
                IPaperDTO paperDTO = paperDAC.GetPaperById(paperId);
                return OperationResult<IPaperDTO>.CreateSuccessResult(paperDTO, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<IPaperDTO>.CreateErrorResult(null, ex.Message);
            }
        }

        public OperationResult<bool> SavePaper(IPaperDTO paperDTO)
        {
            try
            {
                IPaperDAC paperDAC = DACFactory.Create<IPaperDAC>();

                IPaperDTO rnDTO = paperDAC.GetPaperByTitle(paperDTO.Name);

                if (paperDTO.PaperId == -1 && rnDTO != null)
                {
                    return OperationResult<bool>.CreateFailureResult(true, "Name can't be same to another Paper");
                }
                else if (paperDTO.PaperId != -1 && rnDTO != null && rnDTO.PaperId != paperDTO.PaperId)
                {
                    return OperationResult<bool>.CreateFailureResult(true, "Name can't be same to another Paper");
                }


                paperDAC.SavePaper(paperDTO);
                return OperationResult<bool>.CreateSuccessResult(true, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.CreateErrorResult(false, ex.Message);
            }


        }

        public OperationResult<bool> DeletePaper(int paperId)
        {
            try
            {
                IPaperDAC paperDAC = DACFactory.Create<IPaperDAC>();
                bool ans=paperDAC.DeletePaper(paperId);
                if (ans) {
                    return OperationResult<bool>.CreateSuccessResult(true, "Success");
                }
                else
                {
                    return OperationResult<bool>.CreateFailureResult(true, "Can not delete Paper containing questions.");
                }

               

            }
            catch (Exception ex)
            {
                return OperationResult<bool>.CreateErrorResult(false, ex.Message);
            }
        }

        public OperationResult<IList<IQuestionDTO>> GetQuestionsOfPaper(int paperId)
        {
            try
            {
                IPaperDAC paperDAC = DACFactory.Create<IPaperDAC>();
                IList<IQuestionDTO> ans = paperDAC.GetQuestionsOfPaper(paperId);
                return OperationResult<IList<IQuestionDTO>>.CreateSuccessResult(ans, "Success");
            }
            catch (Exception ex)
            {
                return OperationResult<IList<IQuestionDTO>>.CreateErrorResult(null, ex.Message);
            }
        }
    }
}
