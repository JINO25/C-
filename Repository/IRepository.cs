
using testBlazor;
using testBlazor.Models;

public interface IRepository
{
    Task<IEnumerable<Employee>> GetALlEmployees();
    Task<Employee> GetEmployee(int id);
    Task<EmWithDep> GetEmployee2(int id);
    Task Update(Employee employee);
}