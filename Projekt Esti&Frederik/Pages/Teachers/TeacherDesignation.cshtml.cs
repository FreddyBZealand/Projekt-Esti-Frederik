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
        


        public TeacherDesignationModel(ITeacherService teacherService, IExamService examService)
        {
            this.teacherService = teacherService;
            this.examService = examService;            
        }

        public void OnGet(int examId)
        {
            teachers = teacherService.GetTeacher();            
        }
    }
}
