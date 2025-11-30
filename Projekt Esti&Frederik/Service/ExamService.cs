using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Service
{
    public class ExamService : IExamService
    {
        ExamPlannerDBContext context;

        public ExamService(ExamPlannerDBContext cont)
        {
            context = cont;
        }

        public void AddExam(Exam exam)
        {
            throw new NotImplementedException();
        }

        public void DeleteExam(int examId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExam()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExamByClassId(int classId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> GetExamByDesignationId(int designationId)
        {
            throw new NotImplementedException();
        }

        public void UpdateExam(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
