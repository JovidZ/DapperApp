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
        [HttpGet("GetDepartment")]// Указание метода (в данном случаи метод Гет)
        public async Task<List<GetDepartment>> GetDepartments()// создание листа, тип которого береться из папки Домен из класса InsertDepartment класс GetDepartment 
        {
            return await _departmentService.GetDepartments();// возвращаеть нам в виде листа данные
        }
        //Метод Insert данных в базу 
        [HttpPost("InsertDepartment")]
        public async Task<int> InsertDepartment(InsertDepartment department)// создание метода тип ИНТ, тип которого береться из папки Домен из класса InsertDepartment класс InsertDepartment 
        {
            return await _departmentService.InsertDepartment(department);
        }
       // Comment
    }
}
