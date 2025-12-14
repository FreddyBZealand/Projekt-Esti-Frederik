using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Teachers
{
    public class TeacherDesignationModel : PageModel
    {
        public IEnumerable<Teacher> teachers { get; set; }
        public ITeacherService teacherService;
        public IExamService examService;
        public IDesignationService designationService;
        public int examId;

        public TeacherDesignationModel(ITeacherService teacherService, IExamService examService, IDesignationService designationService)
        {
            this.teacherService = teacherService;
            this.examService = examService;
            this.designationService = designationService;
        }

        public void OnGet(int examId)
        {
            teachers = teacherService.GetTeacher();            
            this.examId = examId;
        }

        public IActionResult OnPost(int teacherId, int examId, string TypeId)
        {
            Designation designation = new Designation
            {
                ExamId = examId,
                TeacherId = teacherId,
            };

            if (TypeId == "1")
            {
                designation.DesignationRole = "Examiner";
            }
            else if (TypeId == "2")
            {
                designation.DesignationRole = "Internal censor";
            }
            
            designationService.AddDesignation(designation);
            return RedirectToPage("/Exams/Exams");
        }
    }
}
