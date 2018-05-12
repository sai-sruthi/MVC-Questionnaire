using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Shared.Functional.DAC;
using Shared.Functional.DTO;
using Shared.Infrastructure.DAC;

namespace DAL
{
    public class QuestionDAC : DACBase, IQuestionDAC
    {
        public IList<IQuestionDTO> GetAllQuestions()
        {
            IList<IQuestionDTO> rv = new List<IQuestionDTO>();

            var portalDb = new QuestionnaireEntities();
            var questions = portalDb.Questions.ToList();

            foreach (var question in questions)
            {
                IQuestionDTO questionDTO = DTOFactory.Create<IQuestionDTO>();

                questionDTO.QuestionId = question.Id;
                questionDTO.Text = question.Text;
                questionDTO.Marks = question.Marks;
                questionDTO.QuestionPaperNo = question.QuestionPaperNo;
                rv.Add(questionDTO);
            }

            return rv;
        }

        public IQuestionDTO GetQuestionById(int questionId)
        {
            IQuestionDTO rv = DTOFactory.Create<IQuestionDTO>();

            var portalDb = new QuestionnaireEntities();
            var question = portalDb.Questions.SingleOrDefault(n => n.Id == questionId);

            rv.QuestionId = question.Id;
            rv.Text = question.Text;
            rv.Marks = question.Marks;
            rv.QuestionPaperNo = question.QuestionPaperNo;

            return rv;
        }

        public void SaveQuestion(IQuestionDTO questionDTO)
        {
            var portalDb = new QuestionnaireEntities();
            Question questionE = null;

            if (questionDTO.QuestionId == -1)
            {
                questionE = new Question();
                questionE.Text = questionDTO.Text;
                questionE.Marks = questionDTO.Marks;
                questionE.QuestionPaperNo = questionDTO.QuestionPaperNo;

                portalDb.Questions.Add(questionE);
            }
            else
            {
                questionE = portalDb.Questions.SingleOrDefault(n => n.Id == questionDTO.QuestionId);
                questionE.Text = questionDTO.Text;
                questionE.Marks = questionDTO.Marks;
                questionE.QuestionPaperNo = questionDTO.QuestionPaperNo;
            }

            portalDb.SaveChanges();

            questionDTO.QuestionId = questionE.Id;
        }

        public void DeleteQuestion(int questionId)
        {
            var portalDb = new QuestionnaireEntities();
            var questionE = portalDb.Questions.SingleOrDefault(n => n.Id == questionId);
            portalDb.Questions.Remove(questionE);
            portalDb.SaveChanges();
        }
    }
}
