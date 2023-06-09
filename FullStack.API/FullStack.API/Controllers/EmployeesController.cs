using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullStackDbContext.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await _fullStackDbContext.Employees.AddAsync(employeeRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(employeeRequest);


        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var Employee = await _fullStackDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeRequest)
        {
            var Employee = await _fullStackDbContext.Employees.FindAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }
            Employee.Name = updateEmployeeRequest.Name;
            Employee.Email = updateEmployeeRequest.Email;
            Employee.Phone = updateEmployeeRequest.Phone;
            Employee.Salary = updateEmployeeRequest.Salary;
            Employee.Departement = updateEmployeeRequest.Departement;
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(Employee);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var Employee = await _fullStackDbContext.Employees.FindAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }


            _fullStackDbContext.Remove(Employee);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(Employee);
        }
    }

   
   
    
}
   
    

   


   

