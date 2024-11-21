

using System.Net.Http.Json;
using Blazor.Models;

public class StaffService : IStaffService
{
    private readonly HttpClient http;

    public StaffService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var rs = await http.PostAsJsonAsync<Employee>("api/staff", employee);
        rs.EnsureSuccessStatusCode();
        return await rs.Content.ReadFromJsonAsync<Employee>();
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await http.GetFromJsonAsync<Employee[]>("api/staff");
    }

    public async Task<Employee> GetEmployee(int id)
    {
        return await http.GetFromJsonAsync<Employee>($"api/staff/{id}");
    }

    public async Task<Employee> Update(Employee employee)
    {
        var res = await http.PutAsJsonAsync($"api/staff", employee);
        res.EnsureSuccessStatusCode();
        return await res.Content.ReadFromJsonAsync<Employee>();
    }

    public async Task Delete(int id)
    {
        await http.DeleteAsync($"api/staff/{id}");
    }

}