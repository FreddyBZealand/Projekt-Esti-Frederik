using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Exams
{
    public class CreateExamModel : PageModel
    {
        [BindProperty]
        public Exam exam { get; set; }
        private IExamService examService;
        private readonly ExamPlannerDBContext dBContext;
        public List<SelectListItem> classOptions { get; set; }

        public CreateExamModel(IExamService examService, ExamPlannerDBContext dBContext)
        {
            this.examService = examService;
            this.dBContext = dBContext;
            exam = new Exam();
            //I added the folowing code so when we create an new exam it automatikly go tho the date of creating:
            exam.ExamSubmissionDate = DateOnly.FromDateTime(DateTime.Now);
            exam.ExamDate = DateOnly.FromDateTime(DateTime.Now);
            exam.ReExamSubmissionDate = DateOnly.FromDateTime(DateTime.Now);
            exam.ReExamDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public void OnGet()
        {
            classOptions = dBContext?.Classes
                .AsNoTracking()
                .Select(c => new SelectListItem
                {
                    Value = c.ClassId.ToString(),
                    Text = c.ClassName
                })
                .ToList() ?? new List<SelectListItem>();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                classOptions = dBContext?.Classes
                    .AsNoTracking()
                    .Select(c => new SelectListItem
                    {
                        Value = c.ClassId.ToString(),
                        Text = c.ClassName
                    })
                    .ToList() ?? new List<SelectListItem>();

                return Page();
            }

            examService?.AddExam(exam);
            return RedirectToPage("Exams");
        }
    }
}
