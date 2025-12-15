using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;
using Projekt_Esti_Frederik.Service;

namespace Projekt_Esti_Frederik.Pages.Teachers
{
    public class CreateTeacherModel : PageModel
    {
        [BindProperty]
        public Teacher TheTeacher { get; set; }
        private ITeacherService teacherService;
        public IEnumerable<Teacher> teachers { get; set; }

        public CreateTeacherModel(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
            TheTeacher = new Teacher();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (TheTeacher.FirstName == null)
            {
                ModelState.AddModelError(string.Empty, "No first name? This teacher is trying to be a secret agent.");
                return Page();
            }

            if (TheTeacher.LastName == null)
            {
                ModelState.AddModelError(string.Empty, "No last name? This teacher is really committed to the secret?agent lifestyle.");
                return Page();
            }

            if (TheTeacher.Initials == null)
            {
                ModelState.AddModelError(string.Empty, "Initials required — teachers can’t just go by ‘that one.’");
                return Page();
            }

            if (TheTeacher.Email == null)
            {
                ModelState.AddModelError(string.Empty, "We need an email. Carrier pigeons are not supported.");
                return Page();
            }

            teacherService.AddTeacher(TheTeacher);
            return RedirectToPage("Teachers");
        }
    }
}
