using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using Domain; 

namespace Service
{
    public class EmployeeService
    {
        private string connectionString = "Server = 127.0.0.1; Port =5432;Database = DataGitHub; User Id=postgres; Password = root;";

        private NpgsqlConnection _connection;

        public EmployeeService()
        {
            _connection = new NpgsqlConnection(connectionString);

        }

        public async Task<List<EmployeeId>> GetEmployees()
        {
            using (_connection)
            {
                var sql = " select e.Id, concat(e.FirstName,' ',e.LastName) as FullName, d.Id as DepartmentId, d.Name as DepartmentName " +
                    " from Employee e " +
                    " join Department_Employee as de on de.EmployeeId=e.Id " +
                    " join Department as d on d.Id = de.DepartmentId ";
                var list = await _connection.QueryAsync<EmployeeId>(sql);
                return list.ToList();
            }
        }

        public async Task<EmployeeId> GetEmployeeById(int Id)
        {
            using (_connection)
            {
                var sql = $" select e.Id, concat(e.FirstName,' ',e.LastName) as FullName, d.Id as DepartmentId, d.Name as DepartmentName " +
                    $" from Employee e" +
                    $" join Department_Employee as de on de.EmployeeId=e.Id " +
                    $" join Department as d on d.Id = de.DepartmentId " +
                    $"  Where E.Id={Id} ";

                var getById = await _connection.QuerySingleAsync<EmployeeId>(sql);
                return getById;

            }
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
            using (_connection)
            {
                var sql = $" Insert into Employee(firstName,lastName,birthDate,gender,hireDate) " +
                    $" values('{employee.firstName}', " +
                    $" '{employee.lastName}', " +
                    $" '{employee.birthDate}', " +
                    $" '{employee.gender}', " +
                    $" '{employee.hireDate}') ";
                var insert = await _connection.ExecuteAsync(sql);
                return insert;

            }
        }

        public async Task<int> UpdateEmployee(Employee employee, int Id)
        {
            using (_connection)
            {
                var sql = $" Update Employee " +
                    $" Set " +
                    $" FirstName='{employee.firstName}', " +
                    $" LastName='{employee.lastName}', " +
                    $" BirthDate='{employee.birthDate}', " +
                    $" Gender='{employee.gender}', " +
                    $" HireDate='{employee.hireDate}' " +
                    $" Where Id={Id} ";
                var update = await _connection.ExecuteAsync(sql);
                return update;
            }
        }


    }
}
