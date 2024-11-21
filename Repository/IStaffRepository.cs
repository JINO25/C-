using StaffApi.DTO;

namespace StaffApi.Models;
public interface IStaffRepository
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployee(int employeeId);
    Task<EmployeeDTO> GetEmployee2(int employeeId);

    Task<Employee> AddEmployee(Employee employee);

    Task<Employee> UpdateEmployee(Employee employee);
    Task<Employee> DeleteEmployee(int employeeId);
}