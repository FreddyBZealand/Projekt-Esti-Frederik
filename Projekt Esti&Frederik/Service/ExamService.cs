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
            context.Exams.Add(exam);
            context.SaveChanges();
        }

        public void DeleteExam(int examId)
        {
            var existing = context.Exams.Find(examId);

            if (existing == null)
                throw new KeyNotFoundException($"Exam with ID {examId} not found.");

            context.Exams.Remove(existing);
            context.SaveChanges();
        }

        public IEnumerable<Exam> GetExam()
        {
            return context.Exams.ToList();
        }

        public IEnumerable<Exam> GetExamByClassId(int classId)
        {
            return context.Exams
            .Where(e => e.ClassId == classId)
            .ToList();
        }

        public IEnumerable<Exam> GetExamByDesignationId(int designationId)
        {
            return context.Exams
           .Where(e => e.DesignationId == designationId)
           .ToList();
        }

        public void UpdateExam(Exam exam)
        {
            var existing = context.Exams.Find(exam.ExamId);

            if (existing == null)
                throw new KeyNotFoundException($"Exam with ID {exam.ExamId} not found.");

            context.Entry(existing).CurrentValues.SetValues(exam);
            context.SaveChanges();
        }
    }
}
