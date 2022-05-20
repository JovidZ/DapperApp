using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using Domain;
using System.Data.Common;

namespace Service
{
    public class ManagerService
    {
        private string connectionString = "Server = 127.0.0.1; Port =5432;Database = DataGitHub; User Id=postgres; Password = root;";

        private NpgsqlConnection _connection;

        public ManagerService()
        {
            _connection = new NpgsqlConnection(connectionString);

        }

        public async Task<List<Department_ManagerUser>> GetManagers()
        {
            using (var con = _connection)
            {
                var sql = " select e.Id as ManagerId, concat(e.FirstName,' ',e.LastName) as ManagerFullName , " +
                    " d.Id as DepartmentId, d.Name as DepartmentName, dm.FromDate, dm.ToDate " +
                    " from Department_Manager as  dm " +
                    " join Employee as e on e.Id = dm.EmployeeId " +
                    " join Department as d on d.Id = dm.DepartmentId ";
                var list = await _connection.QueryAsync<Department_ManagerUser>(sql);
                return list.ToList();
            }
        }


        public async Task<int> InsertManager(DepartmentMeng User)
        {
            using (_connection)
            {
                var sql = $" Insert into Department_Manager(EmployeeId,DepartmentId,FromDate,ToDate) " +
                    $" values({User.EmployeeId},{User.DepartmentId},'{User.FromDate}','{User.ToDate}') ";
                var insert = await _connection.ExecuteAsync(sql);
                return insert;

            }
        }
    }
    
}
