using Projekt_Esti_Frederik.Models;

namespace Projekt_Esti_Frederik.Service.Interface
{
    public interface IClassService
    {
        IEnumerable<Class> GetClass();
        Class? GetClassById(int classId);

        //We made a mistake, there is no reference to Teacher or Student in ER diagram
        //IEnumerable<Class> GetClassByTeacherId(int teacherId);
        //IEnumerable<Class> GetClassByStudentId(int studentId);

        void AddClass(Class theClass);
        void UpdateClass(Class theClass);
        void DeleteClass(int classId);
    }
}
