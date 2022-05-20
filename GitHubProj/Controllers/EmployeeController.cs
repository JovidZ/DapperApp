using Microsoft.AspNetCore.Mvc;
using Domain;
using Service;
using Npgsql;
using Dapper;

namespace GitHubProj.Controllers
{
    [ApiController]// Объязательно нужно указать
    [Route("api/[controller]")]// Объязательно нужно указать
    public class EmployeeController : ControllerBase
    {
        private EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet("GetEmployees")]
        public async Task<List<EmployeeId>> GetEmployees()
        {
            return await employeeService.GetEmployees();
        }

        [HttpGet("GetEmployeeById")]
        public async Task<EmployeeId> GetEmployeeById(int Id)
        {
            return await employeeService.GetEmployeeById(Id);
        }

        [HttpPost("InsertEmployee")]
        public async Task<int> InsertEmployee(Employee employee)
        {
            return await employeeService.InsertEmployee(employee);
        }


        [HttpPut("UpdateEmployee")]
        public async Task<int> UpdateEmployee(Employee employee, int Id)
        {
            return await employeeService.UpdateEmployee(employee, Id);
        }
    }
}
