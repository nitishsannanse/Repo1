using Repo1.Model;

namespace Repo1.Repository
{
    public interface IStudent2Repository
    {

        Task<IEnumerable<Student2>> AllStudents();

        Task<Student2> getStudentById(int id);
    }
}
