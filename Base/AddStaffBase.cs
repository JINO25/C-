

using Blazor.Models;
using Microsoft.AspNetCore.Components;
namespace Blazor.Base;
public class AddStaffBase : ComponentBase
{
    public Employee staff = new Employee();

    [Inject]
    public IStaffService staffService { get; set; }

    [Inject]
    public NavigationManager navigationManager { get; set; }

    public async Task submit()
    {
        var rs = await staffService.AddEmployee(staff);
        if (rs != null)
        {
            navigationManager.NavigateTo("/stafflist");
        }
        else
        {
            Console.WriteLine(rs);
        }
    }

}