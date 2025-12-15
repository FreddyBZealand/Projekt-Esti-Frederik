using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Classes
{
    public class DeleteClassModel : PageModel
    {
        [BindProperty]
        public Class TheClass { get; set; }
        private IClassService classService;
        private IDesignationService designationService;
        private IExamService examService;

        public DeleteClassModel(IClassService classService, IDesignationService designationService, IExamService examService)
        {
            this.classService = classService;
            this.designationService = designationService;
            this.examService = examService;
        }

        public void OnGet(int id)
        {
            Class c = classService.GetClassById(id);
            if (c is not null)
            {
                TheClass = c;
            }

            else
            {
                TheClass = new Class();
            }
        }

        public IActionResult OnPost()
        {
            if (TheClass is not null)
            {
                foreach (Exam exam in examService.GetExamByClassId(TheClass.ClassId))
                {
                    foreach (Designation designation in designationService.GetDesignationByExamId(exam.ExamId))
                    {
                        designationService.DeleteDesignation(designation.DesignationId);
                    }

                    examService.DeleteExam(exam.ExamId);
                }

                Class c = classService.GetClassById(TheClass.ClassId);
                if (c is not null)
                {
                    classService.DeleteClass(c.ClassId);
                }
            }
            return RedirectToPage("./Classes");
        }
    }
}
