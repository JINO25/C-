
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

    public async Task Update(Employee employee)
    {
        employeesContext.Employees.Update(employee);
        await employeesContext.SaveChangesAsync();
    }

}