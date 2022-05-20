using Microsoft.AspNetCore.Mvc;
using Dapper;
using Npgsql;
using Domain;
using Service; 

namespace GitHubProj.Controllers
{
    [ApiController]// Объязательно нужно указать
    [Route("api/[controller]")]// Объязательно нужно указать
    public class ManagerController : ControllerBase
    {
        private ManagerService managerService;

        public ManagerController(ManagerService managerService)
        {
            this.managerService = managerService;

        }

        [HttpGet("GetManagers")]
        public async Task<List<Department_ManagerUser>> GetManagers()
        {
            return await managerService.GetManagers();
        }

        [HttpPost("InsertManager")]
        public async Task<int> InsertManager(DepartmentMeng User)
        {
            return await managerService.InsertManager(User);
        }
    }
}
