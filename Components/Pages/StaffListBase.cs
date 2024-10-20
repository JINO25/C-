
using System.Runtime.InteropServices;
using Blazor.Models;
using Microsoft.AspNetCore.Components;

public class StaffListBase : ComponentBase
{
    [Inject]
    public IStaffRepository staffRepository { get; set; }

    public IEnumerable<Employee> staffs { get; set; }

    protected override async Task OnInitializedAsync()
    {
        staffs = await staffRepository.GetAllEmployee();
    }


}