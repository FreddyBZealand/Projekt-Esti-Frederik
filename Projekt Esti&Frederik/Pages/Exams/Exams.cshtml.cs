using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Pages.Exams
{
    public class ExamModel : PageModel
    {
        public List<Exam> exams { get; set; }

        private IExamService examService;
        private IDesignationService designationService;


        public ExamModel(IExamService examService, IDesignationService designationService)
        {
            exams = new List<Exam>();
            this.examService = examService;
            this.designationService = designationService;
        }

        public void OnGet(int? classId,int? teacherId)
        {
            if (teacherId == null && classId == null)
            {
                exams = examService.GetExam().ToList();
            }

            else if (teacherId != null)
            { 
                IEnumerable<Designation> designations = designationService.GetDesignationByTeacherId((int) teacherId);

                foreach (Designation d in designations)
                {
                    if (d.ExamId != null)
                    {
                        Exam exam = examService.GetExamByExamId((int)d.ExamId);

                        if (exam != null)
                        {
                            exams.Add(exam);
                        }
                    }
                }
            }

            else if (classId != null)
            {
                exams = examService.GetExamByClassId((int)classId).ToList();
            }
        }
    }
}
