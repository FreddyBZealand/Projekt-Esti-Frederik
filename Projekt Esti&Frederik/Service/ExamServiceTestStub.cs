using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Service
{
    public class ExamServiceTestStub : IExamService
    {
        public void AddExam(Exam exam)
        {

        }

        public void DeleteExam(int examId)
        {

        }

        public IEnumerable<Exam> GetExam()
        {
        return new List<Exam>
            {
                new Exam { ExamId = 1, ExamName = "Math Exam", EstimatedNumberStudents = 30, TypeOfExam = "F", Supervision = true, TypeOfSupervisor = "Internal", ExamSubmissionDate = new DateOnly(2024, 5, 1), ExamDate = new DateOnly(2024, 5, 15), ExamStartTime = new TimeOnly(9, 0), ExamEndTime = new TimeOnly(12, 0), ReExamSubmissionDate = new DateOnly(2024, 6, 1), ReExamDate = new DateOnly(2024, 6, 15), ReExamStartTime = new TimeOnly(9, 0), ReExamEndTime = new TimeOnly(12, 0) }
            };
        }

        public IEnumerable<Exam> GetExamByClassId(int classId)
        {
            return new List<Exam>
            {
                new Exam { ExamId = 1, ExamName = "Math Exam", EstimatedNumberStudents = 30, TypeOfExam = "F", Supervision = true, TypeOfSupervisor = "Internal", ExamSubmissionDate = new DateOnly(2024, 5, 1), ExamDate = new DateOnly(2024, 5, 15), ExamStartTime = new TimeOnly(9, 0), ExamEndTime = new TimeOnly(12, 0), ReExamSubmissionDate = new DateOnly(2024, 6, 1), ReExamDate = new DateOnly(2024, 6, 15), ReExamStartTime = new TimeOnly(9, 0), ReExamEndTime = new TimeOnly(12, 0) }
            };
        }

        public IEnumerable<Exam> GetExamByDesignationId(int designationId)
        {
            return new List<Exam>
            {
                new Exam { ExamId = 1, ExamName = "Math Exam", EstimatedNumberStudents = 30, TypeOfExam = "F", Supervision = true, TypeOfSupervisor = "Internal", ExamSubmissionDate = new DateOnly(2024, 5, 1), ExamDate = new DateOnly(2024, 5, 15), ExamStartTime = new TimeOnly(9, 0), ExamEndTime = new TimeOnly(12, 0), ReExamSubmissionDate = new DateOnly(2024, 6, 1), ReExamDate = new DateOnly(2024, 6, 15), ReExamStartTime = new TimeOnly(9, 0), ReExamEndTime = new TimeOnly(12, 0) }
            };
        }

        public Exam? GetExamByExamId(int examId)
        {
            return new Exam { ExamId = 1, ExamName = "Math Exam", EstimatedNumberStudents = 30, TypeOfExam = "F", Supervision = true, TypeOfSupervisor = "Internal", ExamSubmissionDate = new DateOnly(2024, 5, 1), ExamDate = new DateOnly(2024, 5, 15), ExamStartTime = new TimeOnly(9, 0), ExamEndTime = new TimeOnly(12, 0), ReExamSubmissionDate = new DateOnly(2024, 6, 1), ReExamDate = new DateOnly(2024, 6, 15), ReExamStartTime = new TimeOnly(9, 0), ReExamEndTime = new TimeOnly(12, 0) };
        }

        public void UpdateExam(Exam exam)
        {

        }
    }
}
