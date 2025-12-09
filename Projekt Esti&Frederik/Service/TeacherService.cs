using Projekt_Esti_Frederik.Service.Interface;
using Projekt_Esti_Frederik.Models;

namespace Projekt_Esti_Frederik.Service
{
    public class TeacherService : ITeacherService
    {
         private readonly ExamPlannerDBContext context;

        //Whas missing this construkter
        public TeacherService(ExamPlannerDBContext context) 
        { 
        this.context = context;
        }

        public void AddTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void DeleteTeacher(int teacherId)
        {
            var existing = context.Teachers.Find(teacherId);

            if (existing == null)
                throw new KeyNotFoundException($"Teacher with ID {teacherId} not found.");

            context.Teachers.Remove(existing);
            context.SaveChanges();
        }

        public IEnumerable<Teacher> GetTeacher()
        {
            return context.Teachers.ToList();
        }

        //We made a mistake, there is no reference between Class and Teacher, a teacher is not even assigned to a class but only to one to several exams.
        //public IEnumerable<Teacher> GetTeacherByClassId(int classId)
        //{
        //    return context.Classes
        //    .Where(c => c.ClassId == classId)
        //    .Join(
        //        context.Teachers,
        //        c => c.TeacherId,
        //        t => t.TeacherId,
        //        (c, t) => t)
        //    .ToList();
        //}

        public IEnumerable<Teacher> GetTeacherByDesignationId(int designationId)
        {
            return context.Designations
          .Where(d => d.DesignationId == designationId)
          .Join(
              context.Teachers,
              d => d.TeacherId,
              t => t.TeacherId,
              (d, t) => t)
          .ToList();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            var existing = context.Teachers.Find(teacher.TeacherId);

            if (existing == null)
                throw new KeyNotFoundException($"Teacher with ID {teacher.TeacherId} not found.");

            context.Entry(existing).CurrentValues.SetValues(teacher);
            context.SaveChanges();
        }
    }
}
