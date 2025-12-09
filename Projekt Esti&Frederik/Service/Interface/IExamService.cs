using Projekt_Esti_Frederik.Models;

namespace Projekt_Esti_Frederik.Service.Interface
{
    public interface IExamService
    {
        IEnumerable<Exam> GetExam();
        IEnumerable<Exam> GetExamByClassId(int classId);
        //IEnumerable<Exam> GetExamByDesignationId(int designationId);

        void AddExam(Exam exam);
        void UpdateExam(Exam exam);
        void DeleteExam(int examId);
    }
}
