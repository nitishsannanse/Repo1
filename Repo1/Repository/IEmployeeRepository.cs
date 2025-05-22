using Repo1.DTO;
using Repo1.Model;
using System.Collections;

namespace Repo1.Repository
{
    public interface IEmployeeRepository 
    {

        //linq lambda used
        Task<IEnumerable<Employee>> getAllEmployee();
        Task<List<string>> OnlyName();

        Task<Employee> getEmployeeById(int id);

        Task<Employee> addEmployee(Employee emp);

        Task<Employee> deleteEmployeeById(int id);
        Task<Employee> updateEmployeeById(int id,Employee emp);

        //store procedure used

        Task<IEnumerable<Employee>> testGetAllData();

        Task<Employee> testEmpById(int id);

        //dto
        
        

         Task<List<EmployeeDTO>> getOnlyNameAndId();
      

    }
}
