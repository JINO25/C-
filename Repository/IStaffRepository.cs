
using Blazor.Models;

public interface IStaffRepository
{
    Task<IEnumerable<Employee>> GetAllEmployee();
    Task<Employee> GetEmployee(int id);

}