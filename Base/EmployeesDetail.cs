
using Microsoft.AspNetCore.Components;
using testBlazor.Models;

namespace testBlazor.Base
{
    public class EmployeesDetail : ComponentBase
    {
        // [Inject]
        // public IRepository repository { get; set; }

        // public Employee employee { get; set; } = new Employee();

        // [Parameter]
        // public string id { get; set; }

        // protected override async Task OnInitializedAsync()
        // {
        //     employee = await repository.GetEmployee(int.Parse(id));
        // }

        [Inject]
        public IRepository repository { get; set; }

        public EmWithDep employee { get; set; } = new EmWithDep();

        [Parameter]
        public string id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employee = await repository.GetEmployee2(int.Parse(id));
        }
    }
}