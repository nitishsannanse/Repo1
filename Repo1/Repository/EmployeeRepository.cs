using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repo1.DTO;
using Repo1.Model;

namespace Repo1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> getAllEmployee()
        {
            var list = await _context.Employee.ToListAsync();
            return list;
        }

        

        public async Task<Employee> getEmployeeById(int id)
        {
            var emp = await _context.Employee.Where(e => e.eId == id).FirstOrDefaultAsync();
            return emp;
        }
        public async Task<Employee> addEmployee(Employee emp)
        {
            _context.Employee.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> deleteEmployeeById(int id)
        {
            var emp = await _context.Employee.Where(e => e.eId == id).FirstOrDefaultAsync();
            _context.Employee.Remove(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> updateEmployeeById(int id, Employee emp)
        {
            var exemp = await _context.Employee.Where(e => e.eId == id).FirstOrDefaultAsync();

            exemp.eName = emp.eName;
            exemp.eEmail = emp.eEmail;
            exemp.eMobile = emp.eMobile;

            await _context.SaveChangesAsync();
            return emp;
        }


        //for store procedure

        public async Task<IEnumerable<Employee>> testGetAllData()
        {
            var list = await _context.Employee.FromSqlRaw("EXEC getAllData").ToListAsync();
            return list;
        }

        public async Task<Employee> testEmpById(int id)
        {
            var param = new SqlParameter("@id", id);
            var emp = _context.Employee
                            .FromSqlRaw("EXEC getEmpByID @id", param)
                            .AsEnumerable()   // 🔹 Important for non-composable SP
                            .FirstOrDefault();
            return emp;
        }



        //with DTO-data object tranfer
        
        public async Task<List<EmployeeDTO>> getOnlyNameAndId()
        {
            var empList = await _context.Employee
                                        .Select(e => new EmployeeDTO
                                        {
                                            eId = e.eId,
                                            eName = e.eName
                                        })
                                        .ToListAsync();

            return empList;
        }

        public async Task<List<string>> OnlyName()
        {
            var empName= await _context.Employee.Select(e=>e.eName).ToListAsync();
            return empName;
        }
    }
}
