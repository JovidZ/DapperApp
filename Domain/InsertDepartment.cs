namespace Domain;
public class InsertDepartment// this class For insert data 
{
    public int Id { get; set; }
    public string? Name { get; set; }

}
public class GetDepartment// this class For Get data
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int ManagerId { get; set; }
    public string? ManagerFullName { get; set; }
}
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ManagerId { get; set; }
    public string ManagerFullName { get; set; }
}
