using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Exams
{
    public class InfoExamModel : PageModel
    {
        [BindProperty]
        public Exam exam { get; set; }
        private IExamService context;


        public InfoExamModel(IExamService examService)
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
    }
}
