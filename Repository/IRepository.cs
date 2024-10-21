
using testBlazor.Models;

public interface IRepository
{
    Task<IEnumerable<Employee>> GetALlEmployees();
    Task<Employee> GetEmployee(int id);
    Task Update(Employee employee);
}