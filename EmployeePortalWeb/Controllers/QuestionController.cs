using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePortalWeb.Models;
using Shared.Functional.DTO;
using Shared.Functional.Facade;
using Shared.Infrastructure.DTO;
using Shared.Infrastructure.Facade;

namespace EmployeePortalWeb.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        [HttpGet]
        public ActionResult Index()
        {
            IQuestionFacade questionFacade = FacadeFactory.Instance.Create<IQuestionFacade>();
            var questionDTOsResult = questionFacade.GetAllQuestions();

            if (questionDTOsResult.IsValid())
            {
                return View(questionDTOsResult.Data);
            }
            else
            {
                return new RedirectResult("Error/");
            }
        }

        [HttpPost]
        public ActionResult SaveQuestion(QuestionVM question)
        {
            if (ModelState.IsValid)
            {
                IQuestionFacade questionFacade = FacadeFactory.Instance.Create<IQuestionFacade>();
                IQuestionDTO questionDTO = DTOFactory.Instance.Create<IQuestionDTO>();

                questionDTO.QuestionId = question.QuestionId;
                questionDTO.Text = question.Text;
                questionDTO.Marks = question.Marks;
                questionDTO.QuestionPaperNo = question.QuestionPaperNo;
                //paperDTO.QuestionCount = paper.QuestionCount;

                var saveResult = questionFacade.SaveQuestion(questionDTO);


                if (saveResult.IsValid())
                {
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            msg = "Saved",
                            questionId = questionDTO.QuestionId
                        }
                    };
                }
                else
                {
                    if (saveResult.HasFailed())
                    {
                        ModelState.AddModelError("Name", saveResult.Message);
                        return PartialView("LoadQuestionForm", question);
                    }
                    else
                    {
                        return new RedirectResult("Error/");
                    }
                }
            }
            else
            {
                return PartialView("LoadQuestionForm", question);
            }
        }

        [HttpPost]
        public ActionResult LoadQuestionForm(int questionId)
        {
            IQuestionFacade questionFacade = FacadeFactory.Instance.Create<IQuestionFacade>();

            QuestionVM questionVM = null;
            if (questionId != -1)
            {
                var questionDTOResult = questionFacade.GetQuestionById(questionId);

                if (questionDTOResult.IsValid())
                {
                    questionVM = new QuestionVM();
                    questionVM.QuestionId = questionDTOResult.Data.QuestionId;
                    questionVM.Text = questionDTOResult.Data.Text;
                    questionVM.Marks = questionDTOResult.Data.Marks;
                    questionVM.QuestionPaperNo = questionDTOResult.Data.QuestionPaperNo;
                }
                else
                {
                    return new RedirectResult("Error/");
                }
            }
            else
            {
                questionVM = new QuestionVM();
                questionVM.QuestionId = -1;
                questionVM.Text = "";
                questionVM.Marks = 1;
                questionVM.QuestionPaperNo = 1;
            }


            return PartialView(questionVM);
        }

        [HttpGet]
        public ActionResult Delete(int questionId)
        {
            IQuestionFacade questionFacade = FacadeFactory.Instance.Create<IQuestionFacade>();
            var deleteResult = questionFacade.DeleteQuestion(questionId);

            if (deleteResult.IsValid())
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        msg = "Deleted",
                        id = questionId
                    }
                };
            }
            else
            {
                return new RedirectResult("Error/");

            }
        }
    }
}