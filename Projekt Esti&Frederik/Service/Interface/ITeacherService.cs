using Projekt_Esti_Frederik.Models;

namespace Projekt_Esti_Frederik.Service.Interface
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetTeacher();
        IEnumerable<Teacher> GetTeacherByClassId(int classId);
        IEnumerable<Teacher> GetTeacherByDesignationId(int designationId);

        void AddTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(int teacherId);
    }
}
