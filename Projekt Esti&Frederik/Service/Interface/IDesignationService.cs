using Projekt_Esti_Frederik.Models;

namespace Projekt_Esti_Frederik.Service.Interface
{
    public interface IDesignationService
    {
        IEnumerable<Designation> GetDesignation();


        //Designation can only be feteched by TeacherId or ExamId. we made a mistake :)
        //IEnumerable<Designation> GetDesignationStudent(int StudentId);
        IEnumerable<Designation> GetDesignationTeacher(int TeacherId);

        void AddDesignation(Designation designation);
        void UpdateDesignation(Designation designation);
        void DeleteDesignation(int designationId);


    }
}
