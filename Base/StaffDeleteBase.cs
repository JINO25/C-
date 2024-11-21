

using Microsoft.AspNetCore.Components;
namespace Blazor.Base;
public class StaffDeleteBase : ComponentBase
{
    [Inject]
    public IStaffService staffRepository { get; set; }

    [Inject]
    public NavigationManager navigationManager { get; set; }

    [Parameter]
    public string id { get; set; }

    public async Task delete()
    {
        await staffRepository.Delete(int.Parse(id));
        navigationManager.NavigateTo("/stafflist");
    }
}