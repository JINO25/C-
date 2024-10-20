
using Blazor.Models;

public class StaffRepository : IStaffRepository
{
    public StaffsContext staffsContext;

    public StaffRepository(StaffsContext staffsContext)
    {
        this.staffsContext = staffsContext;
    }
    public async Task<IEnumerable<Employee>> GetAllEmployee()
    {
        return staffsContext.Employees;
    }

    public async Task<Employee> GetEmployee(int id)
    {
        return (
            from employee in staffsContext.Employees
            where employee.EmployeeId == id
            select employee).First();

    }
}