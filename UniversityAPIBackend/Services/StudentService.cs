using UniversityAPIBackend.DataAccess;
using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.Services
{
    public class StudentService : IStudentService
    {
        private readonly UniversityDBContext _context;
        public StudentService(UniversityDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetStudentWithCourses()
        {
            throw new NotImplementedException();
        }
        public  IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public IEnumerable<Student> GetStudentWithNoCourses()
        {
            throw new NotImplementedException();
        }
    }
}
