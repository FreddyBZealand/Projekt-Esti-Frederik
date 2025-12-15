using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;
using Projekt_Esti_Frederik.Service;


namespace Projekt_Esti_Frederik.Pages.Teachers
{
    public class DeleteTeacherModel : PageModel
    {
        [BindProperty]
        public Teacher teacher { get; set; }
        private ITeacherService teacherService;
        private IDesignationService designationService;

        public DeleteTeacherModel(ITeacherService teacherService, IDesignationService designationService)
        {
            this.teacherService = teacherService;
            this.designationService = designationService;
        }

        public void OnGet(int id)
        {
            Teacher t = teacherService.GetTeacherById(id);
            if (t is not null)
            {
                teacher = t;
            }
            else
            {
                teacher = new Teacher();
            }
        }

        public IActionResult OnPost()
        {
            if (teacher is not null)
            {
                foreach (Designation designation in designationService.GetDesignationByTeacherId(teacher.TeacherId))
                {
                    designationService.DeleteDesignation(designation.DesignationId);
                }

                Teacher t = teacherService.GetTeacherById(teacher.TeacherId);
                if (t is not null)
                {
                    teacherService.DeleteTeacher(t.TeacherId);
                }
            }

            return RedirectToPage("./Teachers");
        }
    }
}
