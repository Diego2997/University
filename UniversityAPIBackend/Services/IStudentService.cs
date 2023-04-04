using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudentWithCourses();
        IEnumerable<Student> GetStudentWithNoCourses();
        IEnumerable<Student> GetAll();
    }
}
