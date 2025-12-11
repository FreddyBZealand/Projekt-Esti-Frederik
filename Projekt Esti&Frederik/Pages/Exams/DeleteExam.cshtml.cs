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
        private IExamService context;

        public DeleteExamModel(IExamService examService)
        {
            context = examService;
        }

        public void OnGet(int id)
        {
            Exam e = context.GetExamByExamId(id);
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
                var ex = context.GetExamByExamId(exam.ExamId);
                if (ex is not null)
                {
                    context.DeleteExam(ex.ExamId);
                }
            }

            return RedirectToPage("./Exams");
        }
    }
}
