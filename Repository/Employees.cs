
using testBlazor;
using testBlazor.Models;

public class Employees : IRepository
{

    public EmployeesContext employeesContext { get; set; }

    public Employees(EmployeesContext employeesContext)
    {
        this.employeesContext = employeesContext;
    }

    public async Task<IEnumerable<Employee>> GetALlEmployees()
    {
        return employeesContext.Employees;
    }

    public async Task<Employee> GetEmployee(int id)
    {
        return (
            from e in employeesContext.Employees
            where e.Id == id
            select e).First();
    }

    public async Task<EmWithDep> GetEmployee2(int id)
    {
        return (
            from e in employeesContext.Employees
            join d in employeesContext.Departments on e.Id equals d.Id
            where e.Id == id
            select new EmWithDep
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                StartingDate = e.StartingDate,
                DepartmentId = d.Id,
                DepartmentName = d.Name
            }).First();
    }

    public async Task Update(Employee employee)
    {
        employeesContext.Employees.Update(employee);
        await employeesContext.SaveChangesAsync();
    }

}