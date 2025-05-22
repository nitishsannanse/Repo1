using Microsoft.EntityFrameworkCore;
using Repo1.Model;

namespace Repo1.Repository
{
    public class Student2Repository : IStudent2Repository
    {
        private  readonly EmployeeDbContext _context;

        public Student2Repository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student2>> AllStudents()
        {
            var students = new List<Student2>
            { 
                new Student2 {Id=101, Name="AAA"},
                new Student2 {Id=102, Name="BBB" }
            };
             students.ToList();
            return students;
        }

        public  async Task<Student2> getStudentById(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            return stud;
        }
    }
}
