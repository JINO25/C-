

using Microsoft.EntityFrameworkCore;
using StaffApi.DTO;
using StaffApi.Models;

public class StaffRepository : IStaffRepository
{
    private readonly StaffsContext staffsContext;

    public StaffRepository(StaffsContext staffsContext)
    {
        this.staffsContext = staffsContext;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await staffsContext.Employees.ToListAsync();
    }

    public async Task<Employee> GetEmployee(int employeeId)
    {
        return await staffsContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }

    public async Task<EmployeeDTO> GetEmployee2(int employeeId)
    {
        // return await staffsContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        return (
            from e in staffsContext.Employees
            join d in staffsContext.Departments on e.DepartmentId equals d.DepartmentId
            join g in staffsContext.Genders on e.GenderId equals g.GenderId
            where e.EmployeeId == employeeId
            select new EmployeeDTO
            {
                Id = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                date = e.DateofBirth,
                DepartmentId = e.DepartmentId,
                GenderId = e.GenderId,
                DepartmentName = d.DepartmentName,
                Gender = g.GenderDescription
            }
        ).First();
    }



    public async Task<Employee> AddEmployee(Employee employee)
    {
        var result = await staffsContext.Employees.AddAsync(employee);
        await staffsContext.SaveChangesAsync();
        return result.Entity;
    }


    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var result = await staffsContext.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (result != null)
        {
            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Email = employee.Email;
            result.DateofBirth = employee.DateofBirth;
            result.Gender = employee.Gender;
            result.DepartmentId = employee.DepartmentId;
            await staffsContext.SaveChangesAsync();
            return result;
        }

        return null;
    }

    public async Task<Employee> DeleteEmployee(int employeeId)
    {
        var result = await staffsContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        if (result != null)
        {
            staffsContext.Employees.Remove(result);
            await staffsContext.SaveChangesAsync();
            return result;
        }

        return null;
    }

}