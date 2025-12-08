using Projekt_Esti_Frederik.Service.Interface;
using Projekt_Esti_Frederik.Models;

namespace Projekt_Esti_Frederik.Service
{
    public class DesignationService : IDesignationService
    {
        ExamPlannerDBContext context;
        public void AddDesignation(Designation designation)
        {
            context.Designations.Add(designation);
            context.SaveChanges();
        }

        public void DeleteDesignation(int designationId)
        {
            var existing = context.Designations.Find(designationId);

            if (existing == null)
                throw new KeyNotFoundException($"Designation with ID {designationId} not found.");

            context.Designations.Remove(existing);
            context.SaveChanges();
        }

        public IEnumerable<Designation> GetDesignation()
        {
            return context.Designations.ToList();
        }

        public IEnumerable<Designation> GetDesignationStudent(int studentId)
        {
            return context.Designations
            .Where(d => d.StudentId == studentId)
            .ToList();
        }

        public IEnumerable<Designation> GetDesignationTeacher(int teacherId)
        {
            return context.Designations
            .Where(d => d.TeacherId == teacherId)
            .ToList();
        }

        public void UpdateDesignation(Designation designation)
        {
            var existing = context.Designations.Find(designation.DesignationId);

            if (existing == null)
                throw new KeyNotFoundException(
                    $"Designation with ID {designation.DesignationId} not found."
                );

            context.Entry(existing).CurrentValues.SetValues(designation);
            context.SaveChanges();
        }
    }
}

