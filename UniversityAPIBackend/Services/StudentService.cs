using UniversityAPIBackend.DataAccess;
using UniversityAPIBackend.Interface;
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

        public async Task<IEnumerable<Student>> FindOlderStudents()
        {
            var result = _context.Students.Where(s => (DateTime.Today.Year - s.Dob.Year) >= 18);
            return result;
        }

        public async Task<IEnumerable<Student>> GetStudentsWithOneCourse()
        {
            return _context.Students.Where(s => s.Courses.Count >= 1);
        }
    }
}
