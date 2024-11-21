using System.Configuration;
using Blazor.Models;
using Microsoft.AspNetCore.Components;
namespace Blazor.Base;
public class StaffEdit : ComponentBase
{
    public Employee staff { get; set; } = new Employee();

    [Inject]
    public IStaffService staffService { get; set; }

    [Inject]
    public NavigationManager manager { get; set; }

    [Parameter]
    public string id { get; set; }

    protected async override Task OnInitializedAsync()
    {
        staff = await staffService.GetEmployee(int.Parse(id));
    }

    public async Task update()
    {
        Console.WriteLine($"{staff.FirstName} and {staff.LastName} and {staff.Email}");
        await handleUpdate(staff);
    }

    public async Task handleUpdate(Employee employee)
    {
        await staffService.Update(employee);
        manager.NavigateTo("/stafflist");
    }
}