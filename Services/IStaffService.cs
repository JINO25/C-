
using Blazor.Models;
public interface IStaffService
{
    Task<Employee> AddEmployee(Employee employee);
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployee(int id);
    Task<Employee> Update(Employee employee);
    Task Delete(int id);
}