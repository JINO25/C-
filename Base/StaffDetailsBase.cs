
using Blazor.Models;
using Microsoft.AspNetCore.Components;
namespace Blazor.Base;
public class StaffDetailsBase : ComponentBase
{
    public Employee staff { get; set; } = new Employee();

    [Inject]
    public IStaffService staffRepository { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        staff = await staffRepository.GetEmployee(int.Parse(Id));
    }

}