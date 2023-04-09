using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>>FindOlderStudents();
        Task<IEnumerable<Student>> GetStudentsWithOneCourse();
    }
}
