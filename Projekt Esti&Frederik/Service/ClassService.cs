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
            throw new NotImplementedException();
        }

        public void DeleteClass(int classId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetClass()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetClassByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetClassByTeacherId(int teacherId)
        {
            throw new NotImplementedException();
        }

        public void UpdateClass(Class theClass)
        {
            throw new NotImplementedException();
        }
    }
}
