using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models; 
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Exams
{
    public class DeleteExamModel : PageModel
    {
        [BindProperty]
        public Exam exam { get; set; } 
        private IExamService examService;
        private IDesignationService designationService;

        public DeleteExamModel(IExamService examService, IDesignationService designationService)
        {
            this.examService = examService;
            this.designationService = designationService;
        }

        public void OnGet(int id)
        {
            Exam e = examService.GetExamByExamId(id);
            if (e is not null)
            {
                exam = e;
            }

            else
            {
                exam = new Exam();
            }
        }

        public IActionResult OnPost()
        {
            if (exam is not null)
            {
                foreach (Designation designation in designationService.GetDesignationByExamId(exam.ExamId)) 
                {
                    designationService.DeleteDesignation(designation.DesignationId);
                }

                Exam ex = examService.GetExamByExamId(exam.ExamId);
                if (ex is not null)
                {
                    examService.DeleteExam(ex.ExamId);
                }
            }

            return RedirectToPage("./Exams");
        }
    }
}
