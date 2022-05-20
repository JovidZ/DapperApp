using Microsoft.AspNetCore.Mvc;
using Domain;
using Service;
namespace GitHubProj.Controllers
    
{
    [ApiController]// Объязательно нужно указать
    [Route("api/[controller]")]// Объязательно нужно указать

    public class DepartmentController : ControllerBase//Объязательно нужно указать что класс унаследуеться от КонтроллБасе класс
    {
        private DepartmentService _departmentService;// Поля тип, которого являться класс от наших сервисов в (DepartmentService)

        public DepartmentController (DepartmentService departmentService)//Конструктор для инициализации полии 
        {
            _departmentService = departmentService;
        }
        // Метод получения из базы данных информации
        [HttpGet("GetDepartments")]
        public async Task<List<DepartmentId>> GetDepartments()
        {
            return await _departmentService.GetDepartments();
        }
        // Метод получения из базы данных по уникальному идентификатору 
        [HttpGet("GetDepartmentById")]
        public async Task<DepartmentId> GetDepartmentById(int Id)
        {
            return await _departmentService.GetDepartmentById(Id);

        }
        // Метод инсерта в базу данных информации
        [HttpPost("InsertDepartment")]

        public async Task<int> InsertDepartment(Department department)
        {
            return await _departmentService.InsertDepartment(department);
        }
        // Метод Обновления данных в базы данных
        [HttpPut("UpdateDepartment")]
        public async Task<int> UpdateDepartment(Department department, int Id)
        {
            return await _departmentService.UpdateDepartment(department, Id);
        }
    }
}
