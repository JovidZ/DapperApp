namespace Service;
using Npgsql;
using Dapper;
using Domain;

public class DepartmentService
{
    private string connectionString = "Server = 127.0.0.1; Port =5432;Database = DataGitHub; User Id=postgres; Password = root;";

    private NpgsqlConnection _connection;
   
    public DepartmentService()
    {
        _connection = new NpgsqlConnection(connectionString);

    }


     public async  Task<List<DepartmentId>> GetDepartments()
        {
            using (_connection)
            {
                var sql = " select d.Id  , d.Name , e.Id as ManagerId , concat(E.FirstName,'  ',E.LastName) as ManagerFullName " +
                          " from Department d " +
                          " join Department_Employee as de on de.DepartmentId=d.Id " +
                          " join Employee as e on E.Id = de.EmployeeId ";

                var list =await _connection.QueryAsync<DepartmentId>(sql);
                return list.ToList();
            }
        }

        public async Task<DepartmentId> GetDepartmentById(int Id)
        {
            using (_connection)
            {
                var sql = $" select d.Id , d.Name , e.Id as ManagerId , concat(e.FirstName,'  ',e.LastName) as ManagerFullName " +
                          $" from Department d " +
                          $" join Department_Employee as de on de.DepartmentId=d.Id " +
                          $" join Employee as e on e.Id = de.EmployeeId " +
                          $" Where d.Id={Id} ";
                var getById= await _connection.QuerySingleAsync<DepartmentId>(sql);
                return getById;

            }
        }

        public async Task<int> InsertDepartment(Department department)
        {
            using (_connection)
            {
                var sql = $" Insert into  Department(Name) values('{department.Name}')  ";
                var insert =await _connection.ExecuteAsync(sql);

                return insert;
            }
        }
        public async Task<int> UpdateDepartment(Department department,int Id)
        {
            using (_connection)
            {
                var sql = $" Update Department Set Name='{department.Name}'" +
                    $" Where Id={Id} ";
                var update =await _connection.ExecuteAsync(sql);

                return update;
            }
        }

}
