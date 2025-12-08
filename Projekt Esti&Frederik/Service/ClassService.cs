using Projekt_Esti_Frederik.Service.Interface;
using Projekt_Esti_Frederik.Models;

namespace Projekt_Esti_Frederik.Service
{
    public class ClassService : IClassService
    {
        ExamPlannerDBContext context;

        public ClassService(ExamPlannerDBContext cont)
        {
            context = cont;
        }

        public void AddClass(Class theClass)
        {
            context.Classes.Add(theClass);
            context.SaveChanges();
        }

        public void DeleteClass(int classId)
        {
            var existing = context.Classes.Find(classId);

            if (existing != null) 
                throw new KeyNotFoundException($"Class with ID {classId} not found.");
            context.Classes.Remove(existing);
            context.SaveChanges();
        }

        public IEnumerable<Class> GetClass()
        {
            return context.Classes.ToList();
        }

        public IEnumerable<Class> GetClassByStudentId(int studentId)
        {
            return context.Classes
                .Where(c => c.Students.Any(s => s.StudentId == studentId))
            .ToList();
        }

        public IEnumerable<Class> GetClassByTeacherId(int teacherId)
        {
            return context.Classes
          .Where(c => c.TeacherId == teacherId)
          .ToList();
        }

        public void UpdateClass(Class theClass)
        {
            var existing = context.Classes.Find(theClass.ClassId);

            if (existing == null)
                throw new KeyNotFoundException($"Class with ID {theClass.ClassId} not found.");

            context.Entry(existing).CurrentValues.SetValues(theClass);

            context.SaveChanges();
        }
    }
}
