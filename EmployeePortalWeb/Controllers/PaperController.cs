using EmployeePortalWeb.Models;
using Shared.Functional.DTO;
using Shared.Functional.Facade;
using Shared.Infrastructure.DTO;
using Shared.Infrastructure.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortalWeb.Controllers
{
    public class PaperController : Controller
    {
        // GET: Paper
        [HttpGet]
        public ActionResult Index()
        {
            IPaperFacade paperFacade = FacadeFactory.Instance.Create<IPaperFacade>();
            var paperDTOsResult = paperFacade.GetAllPapers();

            if (paperDTOsResult.IsValid())
            {
                return View(paperDTOsResult.Data);
            }
            else
            {
                return new RedirectResult("Error/");
            }
        }

        [HttpPost]
        public ActionResult SavePaper(PaperVM paper)
        {
            if (ModelState.IsValid)
            {
                IPaperFacade paperFacade = FacadeFactory.Instance.Create<IPaperFacade>();
                IPaperDTO paperDTO = DTOFactory.Instance.Create<IPaperDTO>();

                paperDTO.PaperId = paper.PaperId;
                paperDTO.Name = paper.Name;
                paperDTO.Description = paper.Description;
                paperDTO.Duration = paper.Duration;
                //paperDTO.QuestionCount = paper.QuestionCount;

                var saveResult = paperFacade.SavePaper(paperDTO);


                if (saveResult.IsValid())
                {
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new
                        {
                            msg = "Saved",
                            paperId = paperDTO.PaperId
                        }
                    };
                }
                else
                {
                    if (saveResult.HasFailed())
                    {
                        ModelState.AddModelError("Name", saveResult.Message);
                        return PartialView("LoadPaperForm", paper);
                    }
                    else
                    {
                        return new RedirectResult("Error/");
                    }
                }
            }
            else
            {
                return PartialView("LoadPaperForm", paper);
            }
        }

        [HttpPost]
        public ActionResult LoadPaperForm(int paperId)
        {
            IPaperFacade paperFacade = FacadeFactory.Instance.Create<IPaperFacade>();

            PaperVM paperVM = null;
            if (paperId != -1)
            {
                var paperDTOResult = paperFacade.GetPaperById(paperId);

                if (paperDTOResult.IsValid())
                {
                    paperVM = new PaperVM();
                    paperVM.PaperId = paperDTOResult.Data.PaperId;
                    paperVM.Name = paperDTOResult.Data.Name;
                    paperVM.Description = paperDTOResult.Data.Description;
                    paperVM.Duration = paperDTOResult.Data.Duration;
                }
                else
                {
                    return new RedirectResult("Error/");
                }
            }
            else
            {
                paperVM = new PaperVM();
                paperVM.PaperId = -1;
                paperVM.Name = "";
                paperVM.Description = "";
                paperVM.Duration = 1;
            }

            return PartialView(paperVM);
        }

        [HttpGet]
        public ActionResult Delete(int paperId)
        {
            IPaperFacade paperFacade = FacadeFactory.Instance.Create<IPaperFacade>();
            var deleteResult = paperFacade.DeletePaper(paperId);

            if (deleteResult.IsValid())
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        msg = "Deleted",
                        id = paperId
                    }
                };
            }
            else
            {
                if (deleteResult.HasFailed())
                {
                    return null;
                    
                }
                else
                {
                    return new RedirectResult("Error/");
                }
            }
        }

        [HttpGet]

        public ActionResult Details(int id) {

            IPaperFacade paperFacade = FacadeFactory.Instance.Create<IPaperFacade>();

            PaperDetailsVM paperDetails=null;

            var questionsOfPaper = paperFacade.GetQuestionsOfPaper(id);
            var paper = paperFacade.GetPaperById(id);
            if (paper.IsValid() && questionsOfPaper.IsValid()) {

                paperDetails = new PaperDetailsVM();
                paperDetails.PaperId = id;
                paperDetails.Name = paper.Data.Name;
                paperDetails.Description = paper.Data.Description;
                paperDetails.Duration = paper.Data.Duration;
                paperDetails.Questions = new List<QuestionVM>();
                foreach (var question in questionsOfPaper.Data) {
                    QuestionVM questionVM = new QuestionVM();
                    questionVM.QuestionId = question.QuestionId;
                    questionVM.Text = question.Text;
                    questionVM.Marks = question.Marks;
                    questionVM.QuestionPaperNo = id;

                    paperDetails.Questions.Add(questionVM);
                }
            }
            return View(paperDetails);
        }

    }
}