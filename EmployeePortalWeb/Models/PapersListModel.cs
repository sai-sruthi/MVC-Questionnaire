using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using Shared.Functional.DTO;
using Shared.Functional.Facade;
using Shared.Infrastructure.DTO;
using Shared.Infrastructure.Facade;

namespace EmployeePortalWeb.Models
{
    public class PapersListModel
    {
        public List<SelectListItem> PaperCode { get; set; }

        public static List<SelectListItem> PaperCodeList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            IPaperFacade paperFacade = FacadeFactory.Instance.Create<IPaperFacade>();
            var paperDTOsResult = paperFacade.GetAllPapers();
            if (paperDTOsResult.IsValid())
            {
                foreach (var paperDTO in paperDTOsResult.Data)
                {
                    list.Add(new SelectListItem { Text = paperDTO.Name, Value = paperDTO.PaperId.ToString() });

                }
            }
            return list;
        }
    }

}