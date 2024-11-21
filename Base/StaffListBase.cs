
using System.Runtime.InteropServices;
using Blazor.Models;
using Microsoft.AspNetCore.Components;
namespace Blazor.Base;
public class StaffListBase : ComponentBase
{
    [Inject]
    public IStaffService staffRepository { get; set; }

    public IEnumerable<Employee> staffs { get; set; }

    protected override async Task OnInitializedAsync()
    {
        staffs = await staffRepository.GetAllEmployees();
    }


}