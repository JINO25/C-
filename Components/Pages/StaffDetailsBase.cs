
using Blazor.Models;
using Microsoft.AspNetCore.Components;

public class StaffDetailsBase : ComponentBase
{
    public Employee staff { get; set; } = new Employee();

    [Inject]
    public IStaffRepository staffRepository { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        staff = await staffRepository.GetEmployee(int.Parse(Id));
    }

}