using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Exams
{
    public class CreateExamModel : PageModel
    {
        [BindProperty]
        public Exam exam { get; set; }
        private IExamService examService;
        private IClassService classService;
        public List<SelectListItem> classOptions { get; set; }

        // Constructor: sets default exam dates and loads class options.
        public CreateExamModel(IExamService examService, IClassService classService)
        {
            this.examService = examService;
            this.classService = classService;
            exam = new Exam();

            exam.ExamSubmissionDate = DateOnly.FromDateTime(DateTime.Now);
            exam.ExamDate = DateOnly.FromDateTime(DateTime.Now);
            exam.ReExamSubmissionDate = DateOnly.FromDateTime(DateTime.Now);
            exam.ReExamDate = DateOnly.FromDateTime(DateTime.Now);
            classOptions = classService.GetClass()
                .Select(c => new SelectListItem
                {
                    Value = c.ClassId.ToString(),
                    Text = c.ClassName
                })
                .ToList() ?? new List<SelectListItem>();
        }

        // Detects date/time overlaps between a new exam (or re-exam) and existing exams for the same class.
        private bool checkExamTimeOverlap(Exam newExam) {
            if (newExam.ClassId == null) 
            {
                return false;
            }

            foreach (Exam exsistingExam in examService.GetExamByClassId((int)newExam.ClassId))
            {
                //Check if exam dates are the same, if they are check if the times overlap
                if (newExam.ExamDate == exsistingExam.ExamDate)
                {
                    if (checkTimeOverlap(newExam.ExamStartTime, newExam.ExamEndTime, exsistingExam.ExamStartTime, exsistingExam.ExamEndTime))
                    {
                        return true;
                    }
                }

                //Check if re-exam dates are the same, if they are check if the times overlap
                if (newExam.ReExamDate == exsistingExam.ReExamDate)
                {
                    if (checkTimeOverlap(newExam.ReExamStartTime, newExam.ReExamEndTime, exsistingExam.ReExamStartTime, exsistingExam.ReExamEndTime))
                    {
                        return true;
                    }
                }

                //Check if exam date and re-exam date are the same, if they are check if the times overlap
                if (newExam.ReExamDate == exsistingExam.ExamDate)
                {
                    if (checkTimeOverlap(newExam.ReExamStartTime, newExam.ReExamEndTime, exsistingExam.ExamStartTime, exsistingExam.ExamEndTime))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Checks whether two time intervals overlap.
        private bool checkTimeOverlap(TimeOnly start1, TimeOnly end1, TimeOnly start2, TimeOnly end2) 
        {
            return (start1 < end2) && (start2 < end1);
        }

        public void OnGet()
        {

        }

        // The final boss of validation before an exam is allowed to exist.
        public IActionResult OnPost()
        {
            if (exam.ExamName == null) 
            { 
                ModelState.AddModelError(string.Empty, "Oh nah nah what's the exam name, ooh nah nah what's the exam name.  ♫ ♫ ♫ ♫");
                return Page();
            }

            if (exam.TypeOfExam == null)
            {
                ModelState.AddModelError(string.Empty, "is it a girl, is it a boy, no it is Non‑binary. type of exam atleast.");
                return Page();
            }

            if (exam.TypeOfSupervisor == null)
            {
                ModelState.AddModelError(string.Empty, "is it a girl, is it a boy, no it is Non‑binary. type of supervisor atleast.");
                return Page();
            }

            if (exam.ClassId == null)
            {
                ModelState.AddModelError(string.Empty, "No Class, i dont think the students mind, but it is against the requirements.");
                return Page();
            }

            if (exam.EstimatedNumberStudents == 0) 
            {
                ModelState.AddModelError(string.Empty, "The exam has to have some students right ? ");
                return Page();
            }

            if (exam.ExamSubmissionDate == DateOnly.FromDateTime(DateTime.Now)) 
            { 
                ModelState.AddModelError(string.Empty, "Seriously.. The submission date cannot be today. give the students a chance :P");
                return Page();
            }

            if (exam.ExamDate == DateOnly.FromDateTime(DateTime.Now))
            {
                ModelState.AddModelError(string.Empty, "Seriously.. The exam date cannot be today. give the students a chance :P");
                return Page();
            }

            if (exam.ExamStartTime == new TimeOnly()) 
            {
                ModelState.AddModelError(string.Empty, "Someone hasnt changed the start time of the exam. i will not allow 00:00 as a time :P");
                return Page();
            }

            if (exam.ExamEndTime == new TimeOnly())
            {
                ModelState.AddModelError(string.Empty, "Someone hasnt changed the end time of the exam. i will not allow 00:00 as a time :P");
                return Page();
            }

            if (exam.ReExamSubmissionDate == DateOnly.FromDateTime(DateTime.Now))
            {
                ModelState.AddModelError(string.Empty, "Seriously.. The re-submission date cannot be today. give the students a chance :P");
                return Page();
            }

            if (exam.ReExamDate == DateOnly.FromDateTime(DateTime.Now))
            {
                ModelState.AddModelError(string.Empty, "Seriously.. The re-exam date cannot be today. give the students a chance :P ");
                return Page();
            }

            if (exam.ReExamStartTime == new TimeOnly())
            {
                ModelState.AddModelError(string.Empty, "Someone hasnt changed the start time of the re-exam. i will not allow 00:00 as a time :P");
                return Page();
            }

            if (exam.ReExamEndTime == new TimeOnly())
            {
                ModelState.AddModelError(string.Empty, "Someone hasnt changed the end time of the re-exam. i will not allow 00:00 as a time :P");
                return Page();
            }

            if (checkExamTimeOverlap(exam)) 
            {
                ModelState.AddModelError(string.Empty, "The exam times overlap with an existing exam for the selected class.");
                return Page();
            }

            if (exam.ExamStartTime >= exam.ExamEndTime) 
            {
                ModelState.AddModelError(string.Empty, "PANIC there is no time durration for the exam, either it is negative or non exsistent.");
                return Page();
            }

            if (exam.ReExamStartTime >= exam.ReExamEndTime)
            {
                ModelState.AddModelError(string.Empty, "PANIC there is no time durration for the re-exam, either it is negative or non exsistent.");
                return Page();
            }

            examService.AddExam(exam);
            return RedirectToPage("Exams");
        }
    }
}
