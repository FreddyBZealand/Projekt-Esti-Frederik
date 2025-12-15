using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Service
{
    public class TeacherServiceTestStub : ITeacherService
    {
        public void AddTeacher(Teacher teacher)
        {
        }

        public void DeleteTeacher(int teacherId)
        {
        }

        public IEnumerable<Teacher> GetTeacher()
        {
        
            return new List<Teacher>
            {
                new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe" ,Initials="bla", Email = "blabla@shit.com" } 
            };

        }

        public IEnumerable<Teacher> GetTeacherByClassId(int classId)
        {
            return new List<Teacher>
            {
                new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe" ,Initials="bla", Email = "blabla@shit.com" }
            };
        }

        public IEnumerable<Teacher> GetTeacherByDesignationId(int designationId)
        {
            return new List<Teacher>
            {
                new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe" ,Initials="bla", Email = "blabla@shit.com" }
            };
        }

        public void UpdateTeacher(Teacher teacher)
        { }

        Teacher? ITeacherService.GetTeacherById(int teacherId)
        {
            return new Teacher { TeacherId = 1, FirstName = "John", LastName = "Doe", Initials = "bla", Email = "..." };
        }
    }
}
