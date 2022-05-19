namespace Service;
using Npgsql;
using Dapper;
using Domain;

public class DepartmentService
{
    private string connectionString = "Server = 127.0.0.1; Port =5432;Database = DataGitHub; User Id=postgres; Password = root;";

    private NpgsqlConnection _connection;
    private object _departmentService;

    public DepartmentService()
    {
        _connection = new NpgsqlConnection(connectionString);

    }


    public async Task<List<GetDepartment>> GetDepartments()
    {
        using (_connection)
        {
            var sql = "select d.id as Id, d.name as Name, e.id as ManagerId, concat(e.firstname, ' ', e.lastname) as  ManagerFullName from department d join employee e on d.id = e.id";
            var res = await _connection.QueryAsync<GetDepartment>(sql);
            return res.ToList();
        }
    }
    public async Task <int> InsertDepartment(InsertDepartment department)
    {
        using (_connection)
        {
            var sql = $"insert into department (name) values ('{department.Name}')";
            var res = await _connection.ExecuteAsync(sql);
            return res;
        }
    }

}
