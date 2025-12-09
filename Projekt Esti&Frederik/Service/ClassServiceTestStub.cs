using Projekt_Esti_Frederik.Models;
using Projekt_Esti_Frederik.Service.Interface;

namespace Projekt_Esti_Frederik.Service
{
    public class ClassServiceTestStub : IClassService
    {
        public void AddClass(Class theClass)
        {
            
        }

        public void DeleteClass(int classId)
        {
            
        }

        public IEnumerable<Class> GetClass()
        {
            return new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Mathematics" },
                new Class { ClassId = 2, ClassName = "Science" },
                new Class { ClassId = 3, ClassName = "History" }
            };
        }

        public IEnumerable<Class> GetClassByStudentId(int studentId)
        {
            return new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Mathematics" },
                new Class { ClassId = 2, ClassName = "Science" }
            };
        }

        public IEnumerable<Class> GetClassByTeacherId(int teacherId)
        {
            return new List<Class>
            {
                new Class { ClassId = 2, ClassName = "Science" },
                new Class { ClassId = 3, ClassName = "History" }
            };
        }

        public void UpdateClass(Class theClass)
        {
            
        }
    }
}
