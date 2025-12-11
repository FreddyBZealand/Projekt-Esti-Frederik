using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Classes
{
    public class ClassesModel : PageModel
    {
        public IEnumerable<Class> classService { get; set; }
        private IClassService context;
        private IDesignationService designationService;

        public ClassesModel(IClassService classService, IDesignationService designationService)
        {
            this.classService = new List<Class>();
            context = classService;
            this.designationService = designationService;
        }

        public void OnGet()
        {
            classService = context.GetClass();
        }
    }
}
