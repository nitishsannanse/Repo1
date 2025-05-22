using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Repo1.DTO;
using Repo1.Model;
using Repo1.Repository;

namespace Repo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly IStudent2Repository _studentRepo;
        public EmployeeController(IEmployeeRepository empRepo,IStudent2Repository studentRepo) 
        {
            _empRepo = empRepo;
            _studentRepo= studentRepo;
        }


        //get all employees 
        [HttpGet("getAllEmployee")]
        public async Task<IActionResult> getAllEmployees()
        {
            return Ok(await _empRepo.getAllEmployee());
        }

        //for practice only name list

        [HttpGet("OnlyName")]
        public async Task<IActionResult> OnlyName()
        {
          
           return Ok(await _empRepo.OnlyName()); 
        }

        //get all employees by id

        [HttpGet("getEmployeeById/{id}")]
        public async Task<IActionResult> getEmployeeById(int id)
        {
            return Ok(await _empRepo.getEmployeeById(id));
        }

        //add new employee
        [HttpPost("addEmployee")]
        public async Task<IActionResult> addEmployee(Employee emp)
        {
            return Ok(await _empRepo.addEmployee(emp));
        }


        //delte employee

        [HttpDelete("deleteEmployeeById/{id}")]
        public async Task<IActionResult> deleteEmployeeById(int id)
        {
            return Ok(await _empRepo.deleteEmployeeById(id));
        }

        //upadee employee 
        [HttpPut("updateEmployeeById/{id}")]

        public async Task<IActionResult> updateEmployeeById(int id, Employee emp)
        {
            
            await _empRepo.updateEmployeeById(id,emp);
            return NoContent();
        }
        /* store procedure using methods--- */

        //test for store procedures
        [HttpGet("testGetAllData")]
        public async Task<IActionResult> testGetAllData()
        {
            return Ok(await _empRepo.testGetAllData());
        }

        //test for get element by id
        [HttpGet("testGetElementByID/{id}")]

        public async Task<IActionResult> testGetElementById(int id)
        {
            return Ok(await _empRepo.testEmpById(id));
        }

        //dto practice ****DTO***
        [HttpGet("getOnlyNameAndId")]
        public async Task<IActionResult> getOnlyNameAndId()
        {
            return Ok( await _empRepo.getOnlyNameAndId());
        }

        //inset data DTO


        //separete student repo practice with separete 
        //for all student lit
        [HttpGet("getAllStudent")]
        public async Task<IActionResult> getAllStudent([FromServices] IStudent2Repository mStudentRepo)
        {
            var list = await mStudentRepo.AllStudents();
            return Ok(list);
        }

        //getstudentby id
        [HttpGet("getStudentById/{id}")]
        public async Task<IActionResult> getStudentById(int id)
        {
            var stud =_studentRepo.getStudentById(id);
            Console.Write("first change from local");
            Console.Write("second change from Feature new branch");
            Console.Write("Third feature from Feature branch to test conflicts");
            return Ok(stud);
        }

    }
}
