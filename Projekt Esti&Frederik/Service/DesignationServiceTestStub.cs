using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Service
{
    public class DesignationServiceTestStub : IDesignationService
    {
        public void AddDesignation(Designation designation)
        {

        }

        public void DeleteDesignation(int designationId)
        {

        }

        public IEnumerable<Designation> GetDesignation()
        {
        
            return new List<Designation>
            {
                new Designation { DesignationId = 1, 
                    Exam =  new Exam { ExamId = 1, ExamName = "Math Exam", EstimatedNumberStudents = 30, TypeOfExam = "F", Supervision = true, TypeOfSupervisor = "Internal", ExamSubmissionDate = new DateOnly(2024, 5, 1), ExamDate = new DateOnly(2024, 5, 15), ExamStartTime = new TimeOnly(9, 0), ExamEndTime = new TimeOnly(12, 0), ReExamSubmissionDate = new DateOnly(2024, 6, 1), ReExamDate = new DateOnly(2024, 6, 15), ReExamStartTime = new TimeOnly(9, 0), ReExamEndTime = new TimeOnly(12, 0) },
                    DesignationRole = "C", ExamId =1,Teacher = new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe" ,Initials="bla", Email = "blabla@shit.com" }, TeacherId =1}
            };
        }

        public IEnumerable<Designation> GetDesignationStudent(int StudentId)
        {
            return new List<Designation>
            {
                new Designation { DesignationId = 1, Exam = new Exam { ExamId = 1, ExamName = "Math Exam", EstimatedNumberStudents = 30, TypeOfExam = "F", Supervision = true, TypeOfSupervisor = "Internal", ExamSubmissionDate = new DateOnly(2024, 5, 1), ExamDate = new DateOnly(2024, 5, 15), ExamStartTime = new TimeOnly(9, 0), ExamEndTime = new TimeOnly(12, 0), ReExamSubmissionDate = new DateOnly(2024, 6, 1), ReExamDate = new DateOnly(2024, 6, 15), ReExamStartTime = new TimeOnly(9, 0), ReExamEndTime = new TimeOnly(12, 0) }, DesignationRole = "C", ExamId =1,Teacher = new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe" ,Initials="bla", Email = "blabla@shit.com" }, TeacherId =1}
            };
        }

        public IEnumerable<Designation> GetDesignationByTeacherId(int TeacherId)
        {
            return new List<Designation>
            {
                new Designation { DesignationId = 1, Exam = new Exam { ExamId = 1, ExamName = "Math Exam", EstimatedNumberStudents = 30, TypeOfExam = "F", Supervision = true, TypeOfSupervisor = "Internal", ExamSubmissionDate = new DateOnly(2024, 5, 1), ExamDate = new DateOnly(2024, 5, 15), ExamStartTime = new TimeOnly(9, 0), ExamEndTime = new TimeOnly(12, 0), ReExamSubmissionDate = new DateOnly(2024, 6, 1), ReExamDate = new DateOnly(2024, 6, 15), ReExamStartTime = new TimeOnly(9, 0), ReExamEndTime = new TimeOnly(12, 0) }, DesignationRole = "C", ExamId =1,Teacher = new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe" ,Initials="bla", Email = "blabla@shit.com" }, TeacherId =1}
            };
        }

        public void UpdateDesignation(Designation designation)
        {

        }

        public IEnumerable<Designation> GetDesignationByExamId(int examId)
        {
            throw new NotImplementedException();
        }
    }
}
