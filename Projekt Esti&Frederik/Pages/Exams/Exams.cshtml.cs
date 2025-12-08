using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Exams
{
    public class ExamModel : PageModel
    {
        public Exam exam { get; set; }

        public IEnumerable<Exam> examService { get; set; }
        private IExamService context;

        public ExamModel(IExamService examService)
        {
           this.examService = new List<Exam>();
            context = examService;
        }

        public void OnGet()
        {
            examService = context.GetExam();
        }
    }
}
