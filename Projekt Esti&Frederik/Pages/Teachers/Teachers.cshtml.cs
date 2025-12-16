using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Teachers
{
    public class TeatcherModel : PageModel
    {
        public IEnumerable<Teacher> teacherService { get; set; }
        private ITeacherService context;

        public TeatcherModel(ITeacherService teacherService)
        {
            this.teacherService = new List<Teacher>();
            context = teacherService;
        }

        public void OnGet()
        {
            teacherService = context.GetTeacher();
        }
    }
}
