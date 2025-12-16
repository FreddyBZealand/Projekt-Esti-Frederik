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
            Exam existing = context.Exams.Find(examId);

            if (existing == null)
            {
                throw new KeyNotFoundException($"Exam with ID {examId} not found.");
            }

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

        public Exam? GetExamByExamId(int examId)
        {
            return context.Exams.Where(e => e.ExamId == examId).FirstOrDefault();
        }


        //We made a mistake, because there can be multiple designations for one exam, it is not possible to get exam by designation id, because the exam table does not have designation id as foreign key
        //public IEnumerable<Exam> GetExamByDesignationId(int designationId)
        //{
        //    return examService.Exams
        //   .Where(e => e.DesignationId == designationId)
        //   .ToList();
        //}

        public void UpdateExam(Exam exam)
        {
            Exam existing = context.Exams.Find(exam.ExamId);

            if (existing == null)
                throw new KeyNotFoundException($"Exam with ID {exam.ExamId} not found.");

            context.Entry(existing).CurrentValues.SetValues(exam);
            context.SaveChanges();
        }
    }
}
