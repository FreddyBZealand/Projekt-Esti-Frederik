using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Classes
{
    public class CreateClassModel : PageModel
    {
        [BindProperty]
        public Class TheClass { get; set; }

        private IExamService examService;
        private IClassService classService;
        public IEnumerable<Class> classes { get; set; }

        public CreateClassModel(IClassService classService, IExamService examService)
        {
            this.classService = classService;
            TheClass = new Class();
            this.examService = examService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (TheClass.ClassName == null)
            {
                ModelState.AddModelError(string.Empty, "Class name missing. Even imaginary classes need names.");
                return Page();
            }

            classService.AddClass(TheClass);
            return RedirectToPage("Classes");
        }  
    }
}
