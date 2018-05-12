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
    public class PaperDAC : DACBase, IPaperDAC
    {
        public IList<IPaperDTO> GetAllPapers()
        {
            IList<IPaperDTO> rv = new List<IPaperDTO>();

            var portalDb = new QuestionnaireEntities();
            var papers = portalDb.QuestionPapers.ToList();

            foreach (var paper in papers)
            {
                IPaperDTO paperDTO = DTOFactory.Create<IPaperDTO>();

                paperDTO.PaperId = paper.Id;
                paperDTO.Name = paper.Name;
                paperDTO.Description = paper.Description;
                paperDTO.Duration = paper.Duration;
                paperDTO.QuestionCount = paper.Questions.Count;
                rv.Add(paperDTO);
            }

            return rv;
        }

        public IPaperDTO GetPaperById(int paperId)
        {
            IPaperDTO rv = DTOFactory.Create<IPaperDTO>();

            var portalDb = new QuestionnaireEntities();
            var paper = portalDb.QuestionPapers.SingleOrDefault(n => n.Id == paperId);

            rv.PaperId = paper.Id;
            rv.Name = paper.Name;
            rv.Description = paper.Description;
            rv.Duration = paper.Duration;
            rv.QuestionCount = paper.Questions.Count;
            return rv;
        }

        public void SavePaper(IPaperDTO paperDTO)
        {
            var portalDb = new QuestionnaireEntities();
            QuestionPaper paperE = null;

            if (paperDTO.PaperId == -1)
            {
                paperE = new QuestionPaper();
                paperE.Name = paperDTO.Name;
                paperE.Description = paperDTO.Description;
                paperE.Duration = paperDTO.Duration;
                portalDb.QuestionPapers.Add(paperE);
            }
            else
            {
                paperE = portalDb.QuestionPapers.SingleOrDefault(n => n.Id == paperDTO.PaperId);
                paperE.Name = paperDTO.Name;
                paperE.Description = paperDTO.Description;
                paperE.Duration = paperDTO.Duration;
            }

            portalDb.SaveChanges();

            paperDTO.PaperId = paperE.Id;
        }

        public bool DeletePaper(int paperId)
        {
            var portalDb = new QuestionnaireEntities();
            var paperE = portalDb.QuestionPapers.SingleOrDefault(n => n.Id == paperId);
            bool rv = false;
            if (paperE.Questions.Count == 0)
            {
                portalDb.QuestionPapers.Remove(paperE);
                rv = true;
            }

            portalDb.SaveChanges();

            return rv;
        }

        public IPaperDTO GetPaperByTitle(string title)
        {
            IPaperDTO rv = DTOFactory.Create<IPaperDTO>();

            var portalDb = new QuestionnaireEntities();
            var paper = portalDb.QuestionPapers.FirstOrDefault(n => n.Name.Equals(title));

            if (paper != null)
            {
                rv.PaperId = paper.Id;
                rv.Name = paper.Name;
                rv.Description = paper.Description;
                rv.Duration = paper.Duration;
                rv.QuestionCount = paper.Questions.Count;
               
            }
            else
            {
                rv = null;
            }

            return rv;
        }

        public IList<IQuestionDTO> GetQuestionsOfPaper(int paperId) {

            IList<IQuestionDTO> questionsOfPaper = new List<IQuestionDTO>();

            var portalDb = new QuestionnaireEntities();
            var paper = portalDb.QuestionPapers.SingleOrDefault(n => n.Id == paperId);

            ICollection<Question> questions = paper.Questions;

            foreach (var question in questions) {
                IQuestionDTO questionDTO = DTOFactory.Create<IQuestionDTO>();
                questionDTO.QuestionId = question.Id;
                questionDTO.Text = question.Text;
                questionDTO.Marks = question.Marks;

                questionsOfPaper.Add(questionDTO);
            
            }
            return questionsOfPaper;
        
        }
    }

}
